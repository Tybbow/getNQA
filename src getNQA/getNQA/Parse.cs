using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Globalization;
using getNQAstruct;
using getNQApattern;
using getNQAfile;
using getNQA;
using getNQAcheck;
using getNQAFunc;

namespace getNQAParse
{
	public static class ft_parse
	{

		public static bool Parse(string parse, int verbose)
		{
			string[] entrys = { null };

			parse = parse.Replace("\n  ---- More ----\r", "");
			parse = parse.Replace("\n---- More ----\r", "");
			if (parse.Contains("NQA entry"))
			{
				entrys = parse.Split(new[] { "NQA entry" }, StringSplitOptions.None);
				ft_function.displayColor("info", string.Format("{0} NQA Entry found !", (entrys.Length - 1)));
				Regex rgx = new Regex(@"tag \w+");
				foreach(string entry in entrys)
				{
					Match match = rgx.Match(entry);
					if (match.Success)
					{
						MainClass.mentry = match.Value.Replace("tag ", "");
						ft_function.displayColor("green", string.Format("Parsing for : {0}", MainClass.mentry));
						if (verbose == 1)
							Console.WriteLine(entry);
						if (verbose == 2)
							ft_function.stringToHex(entry);
						groupBY(entry);
					}
				}
			}
			else
			{
				if (verbose == 1)
					Console.WriteLine(parse);
				if (verbose == 2)
					ft_function.stringToHex(parse);
				groupBY(parse);
			}
			return (true);
		}

		private static void groupBY(string parse)
		{
			int error = 0;
			List<ft_struct.elementudp> listudp = new List<ft_struct.elementudp>() { };
			List<ft_struct.elementicmp> listicmp = new List<ft_struct.elementicmp>() { };
			List<ft_struct.elementtcp> listtcp = new List<ft_struct.elementtcp>() { };
			List<ft_struct.tmp> listtmp = new List<ft_struct.tmp>() { };
			CultureInfo provider = CultureInfo.InvariantCulture;

			Regex rgx = new Regex(ft_pattern.sondeudp());
			Match match = rgx.Match(parse);
			if (match.Success)
			{
				error = 1;
				ft_function.displayColor("green", "Fetching Measure udp...");
				MatchCollection mc = rgx.Matches(parse);
				addparse(mc, listtmp, "udp");
				addlist.addudp(mc, listudp);
				ft_file.writeFileudp(listudp, listtmp);
			}

			rgx = new Regex(ft_pattern.sondeicmp());
			match = rgx.Match(parse);
			if (match.Success)
			{
				error = 1;
				ft_function.displayColor("green", "Fetching Measure icmp...");
				MatchCollection mc = rgx.Matches(parse);
				addparse(mc, listtmp, "icmp");
				addlist.addicmp(mc, listicmp);
				ft_file.writeFileicmp(listicmp, listtmp);
			}

			rgx = new Regex(ft_pattern.sondetcp());
			match = rgx.Match(parse);
			if (match.Success)
			{
				error = 1;
				ft_function.displayColor("green", "Fetching Measure tcp...");
				MatchCollection mc = rgx.Matches(parse);
				addparse(mc, listtmp, "tcp");
				addlist.addtcp(mc, listtcp);
				ft_file.writeFiletcp(listtcp, listtmp);
			}
			if (error == 0)
			{
				ft_function.displayColor("red", "No data retreving...n");
				ft_function.displayColor("info", "Trying option --verbose for display the result command");
			}
		}

		private static void addparse(MatchCollection mc, List<ft_struct.tmp> listtmp, string sonde)
		{
			
			string names = findname(sonde);
			Hashtable hash = new Hashtable();
			DateTime result;
			foreach (Match m in mc)
			{
				string foundmatch = m.Groups["IP"].Value;
				if (hash.Contains(foundmatch) == false)
				{
					if (!string.IsNullOrEmpty(foundmatch))
						ft_function.displayColor("yellow", "IP Address found : " + foundmatch);
					string date = "1/1/1970";
					string path = ft_check.checkpath(MainClass.path, foundmatch, sonde);
					int numtime = 0;
					if (ft_file.fileexist(path))
					{
						ft_function.displayColor("green", "File " + path + " Read for merge.");
						date = ft_file.readlastline(path);
						numtime = ft_file.readlastlinenum(path);
					}
					else
					{
						ft_function.displayColor("green", "File doesn't exist, create a new file : " + path);
						ft_file.writebegin(path, names);
					}
					hash.Add(foundmatch, string.Empty);
					if (!DateTime.TryParse(date, out result))
						date = "1/1/1970"; 

					listtmp.Add(new ft_struct.tmp()
					{
						elIP = foundmatch,
						elTime = DateTime.Parse(date),
						path = path,
						numtime = numtime,
					});
				}
			}
		}


		private static string findname(string sonde)
		{
			if (sonde == "udp")
				return beginToStringUDP();
			if (sonde == "icmp")
				return beginToStringICMP();
			if (sonde == "tcp")
				return beginToStringTCP();
			return "nok";
		}
		private static string beginToStringUDP()
		{
			return "Number;IP;Time;Lifetime;Sendoptime;Recetime" +
				";Min;Avr;Max;PacketLost;FailsTimeOut;PctTimeOut" +
				";FailsDisconnect;FailsNoConnect;FailsSeqError;FailsInterError" +
				";FailsOtherError;PacketLate;RTTnumber;MinPosSD;MaxPosSD" +
				";AvrPosSD;MinPosDS;MaxPosDS;AvrPosDS;MinNegSD;MaxNegSD;AvrNegSD" +
				";MinNegDS;MaxNegDS;AvrNegDS;MinSDdelay;MaxSDdelay;AvrSDdelay" +
				";MinDSDelay;MaxDSDelay;AvrDSDelay;PacketSDLost;PacketDSLost;PacketUnkLost" +
				";PctPacketSDLost;PctPacketDSLost;PctPacketUnkLost";
		}

		private static string beginToStringICMP()
		{
			return "Number;IP;Time;Lifetime;Sendoptime;Recetime" +
				";Min;Avr;Max;PacketLost;FailsTimeOut;FailsInterError" +
				";FailsOtherError";
		}

		private static string beginToStringTCP()
		{
			return "Number;IP;Time;Lifetime;Sendoptime;Recetime" +
				";Min;Avr;Max;PacketLost;FailsTimeOut" +
				";FailsDisconnect;FailsNoConnect;FailsInterError;FailsOtherError";
		}
	}
}

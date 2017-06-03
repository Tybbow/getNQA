using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
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
		public static bool Parse(string parse)
		{
			parse = parse.Replace("\n  ---- More ----\r", "");
			groupBY(parse);
			return (true);
		}

		private static void groupBY(string parse)
		{
			List<ft_struct.elementtest> listudp = new List<ft_struct.elementtest>() { };
			List<ft_struct.elementicmp> listicmp = new List<ft_struct.elementicmp>() { };
			List<ft_struct.elementtcp> listtcp = new List<ft_struct.elementtcp>() { };
			List<ft_struct.tmp> listtmp = new List<ft_struct.tmp>() { };
			CultureInfo provider = CultureInfo.InvariantCulture;

			Regex rgx = new Regex(ft_pattern.sondeudp());
			Match match = rgx.Match(parse);
			if (match.Success)
			{
				Console.WriteLine("OK");
				MatchCollection mc = rgx.Matches(parse);
				addparse(mc, listtmp, "udp");
				addlist.addtest(mc, listudp);
				//ft_file.writeFileudp(listudp, listtmp);
			}

			//rgx = new Regex(ft_pattern.sondeicmp());
			//match = rgx.Match(parse);
			//if (match.Success)
			//{
			//	MatchCollection mc = rgx.Matches(parse);
			//	addparse(mc, listtmp, "icmp");
			//	addlist.addicmp(mc, listicmp);
			//	ft_file.writeFileicmp(listicmp, listtmp);
			//}

			//rgx = new Regex(ft_pattern.sondetcp());
			//match = rgx.Match(parse);
			//if (match.Success)
			//{
			//	MatchCollection mc = rgx.Matches(parse);
			//	addparse(mc, listtmp, "tcp");
			//	addlist.addtcp(mc, listtcp);
			//	ft_file.writeFiletcp(listtcp, listtmp);
			//}

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
					ft_function.displayColor("yellow", "Find Measure for : " + sonde);
					if (!string.IsNullOrEmpty(foundmatch))
						ft_function.displayColor("yellow", "IP Address found : " + foundmatch);
					string date = "1/1/1970";
					string path = ft_check.checkpath(MainClass.path, foundmatch, sonde);
					int numtime = 0;
					if (ft_file.fileexist(path))
					{
						ft_function.displayColor("green", "\tFile " + path + " Read for merge.");
						date = ft_file.readlastline(path);
						numtime = ft_file.readlastlinenum(path);
					}
					else
					{
						ft_function.displayColor("green", "File doesn't exist, create a new file : " + path);
						ft_file.writebegin(path, names);
					}
					Console.WriteLine();
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
				";Min;Max;Avr;PacketLost;FailsTimeOut" +
				";FailsDisconnect;FailsNoConnect;FailsSeqError;FailsInterError" +
				";FailsOtherError;PacketLate;RTTnumber;MinPosSD;MaxPosSD" +
				";AvrPosSD;MinPosDS;MaxPosDS;AvrPosDS;MinNegSD;MaxNegSD;AvrNegSD" +
				";MinNegDS;MaxNegDS;AvrNegDS;MinSDdelay;MaxSDdelay;AvrSDdelay" +
				";MinDSDelay;MaxDSDelay;AvrDSDelay;PacketSDLost;PacketDSLost;PacketUnkLost";
		}

		private static string beginToStringICMP()
		{
			return "Number;IP;Time;Lifetime;Sendoptime;Recetime" +
				";Min;Max;Avr;PacketLost;FailsTimeOut;FailsInterError" +
				";FailsOtherError";
		}

		private static string beginToStringTCP()
		{
			return "Number;IP;Time;Lifetime;Sendoptime;Recetime" +
				";Min;Max;Avr;PacketLost;FailsTimeOut" +
				";FailsDisconnect;FailsNoConnect;FailsInterError;FailsOtherError";
		}
	}
}

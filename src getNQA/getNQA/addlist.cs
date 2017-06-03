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

namespace getNQA
{
	public class addlist
	{
		public addlist()
		{
		}

		public static void addtest(MatchCollection mc, List<ft_struct.elementtest> list)
		{
			Console.WriteLine("test ok");
			Console.WriteLine(mc[0].Groups["Number"].Value);
			Console.WriteLine("test2 ok");
			foreach (Match m in mc)
			{
				Console.WriteLine(m.Groups["Number"].Value);
				Console.WriteLine(m.Groups["IP"].Value);
				list.Add(new ft_struct.elementtest()
				{
					elNumber = tryInt(m.Groups["Number"].Value),
					elIP = m.Groups["IP"].Value
				});
			}
			//list.Sort(delegate (ft_struct.elementtest x, ft_struct.elementtest y)
			//{
			//	return x.elTime.CompareTo(y.elTime);
			//});
		}

		public static void addudp(MatchCollection mc, List<ft_struct.elementudp> list)
		{
			foreach (Match m in mc)
			{
				string date = m.Groups["Starttime"].Value;
				list.Add(new ft_struct.elementudp()
				{
					elNumber = Int32.Parse(m.Groups["Number"].Value),
					elIP = m.Groups["IP"].Value,
					elTime = DateTime.ParseExact(date.Substring(0, date.IndexOf('.', 0)),
												 "yyyy-MM-dd HH:mm:ss", new CultureInfo("fr-FR")),
					elLifetime = Int32.Parse(m.Groups["Lifetime"].Value),
					elSendoptime = Int32.Parse(m.Groups["Sendoptime"].Value),
					elRecetime = Int32.Parse(m.Groups["Recetime"].Value),
					elMin = Int32.Parse(m.Groups["Min"].Value),
					elMax = Int32.Parse(m.Groups["Max"].Value),
					elAvr = Int32.Parse(m.Groups["Avr"].Value),
					elPacketLost = Int32.Parse(m.Groups["PacketLost"].Value),
					elFailsTimeOut = Int32.Parse(m.Groups["FailsTimeOut"].Value),
					//elFailsDisconnect = Int32.Parse(m.Groups["FailsDisconnect"].Value),
					//elFailsNoConnect = Int32.Parse(m.Groups["FailsNoConnect"].Value),
					elFailsSeqError = Int32.Parse(m.Groups["FailsSeqError"].Value),
					elFailsInterError = Int32.Parse(m.Groups["FailsInterError"].Value),
					elFailsOtherError = Int32.Parse(m.Groups["FailsOtherError"].Value),
					elPacketLate = Int32.Parse(m.Groups["PacketLate"].Value),
					elRTTnumber = Int32.Parse(m.Groups["RTTnumber"].Value),
					elMinPosSD = Int32.Parse(m.Groups["MinPosSD"].Value),
					elMaxPosSD = Int32.Parse(m.Groups["MaxPosSD"].Value),
					elAvrPosSD = Int32.Parse(m.Groups["AvrPosSD"].Value),
					elMinPosDS = Int32.Parse(m.Groups["MinPosDS"].Value),
					elMaxPosDS = Int32.Parse(m.Groups["MaxPosDS"].Value),
					elAvrPosDS = Int32.Parse(m.Groups["AvrPosDS"].Value),
					elMinNegSD = Int32.Parse(m.Groups["MinNegSD"].Value),
					elMaxNegSD = Int32.Parse(m.Groups["MaxNegSD"].Value),
					elAvrNegSD = Int32.Parse(m.Groups["AvrNegSD"].Value),
					elMinNegDS = Int32.Parse(m.Groups["MinNegDS"].Value),
					elMaxNegDS = Int32.Parse(m.Groups["MaxNegDS"].Value),
					elAvrNegDS = Int32.Parse(m.Groups["AvrNegDS"].Value),
					elMinSDdelay = Int32.Parse(m.Groups["MinSDdelay"].Value),
					elMaxSDdelay = Int32.Parse(m.Groups["MaxSDdelay"].Value),
					elSumSDDelay = Int32.Parse(m.Groups["SumSDDelay"].Value),
					elAvrSDDelay = avrSum(Int32.Parse(m.Groups["SumSDDelay"].Value), Int32.Parse(m.Groups["Recetime"].Value)),
					elMinDSdelay = Int32.Parse(m.Groups["MinDSdelay"].Value),
					elMaxDSdelay = Int32.Parse(m.Groups["MaxDSdelay"].Value),
					elSumDSDelay = Int32.Parse(m.Groups["SumDSDelay"].Value),
					elAvrDSDelay = avrSum(Int32.Parse(m.Groups["SumDSDelay"].Value), Int32.Parse(m.Groups["Recetime"].Value)),
					elPacketSDLost = Int32.Parse(m.Groups["PacketSDLost"].Value),
					elPacketDSLost = Int32.Parse(m.Groups["PacketDSLost"].Value),
					elPacketUnkLost = Int32.Parse(m.Groups["PacketUnkLost"].Value)
				});
			}
			list.Sort(delegate (ft_struct.elementudp x, ft_struct.elementudp y)
			{
				return x.elTime.CompareTo(y.elTime);
			});
		}

		public static void addicmp(MatchCollection mc, List<ft_struct.elementicmp> list)
		{
			foreach (Match m in mc)
			{
				string date = m.Groups["Starttime"].Value;
				list.Add(new ft_struct.elementicmp()
				{
					elNumber = Int32.Parse(m.Groups["Number"].Value),
					elIP = m.Groups["IP"].Value,
					elTime = DateTime.ParseExact(date.Substring(0, date.IndexOf('.', 0)),
												 "yyyy-MM-dd HH:mm:ss", new CultureInfo("fr-FR")),
					elLifetime = Int32.Parse(m.Groups["Lifetime"].Value),
					elSendoptime = Int32.Parse(m.Groups["Sendoptime"].Value),
					elRecetime = Int32.Parse(m.Groups["Recetime"].Value),
					elMin = Int32.Parse(m.Groups["Min"].Value),
					elMax = Int32.Parse(m.Groups["Max"].Value),
					elAvr = Int32.Parse(m.Groups["Avr"].Value),
					elPacketLost = Int32.Parse(m.Groups["PacketLost"].Value),
					elFailsTimeOut = Int32.Parse(m.Groups["FailsTimeOut"].Value),
					elFailsDisconnect = Int32.Parse(m.Groups["FailsDisconnect"].Value),
					elFailsNoConnect = Int32.Parse(m.Groups["FailsNoConnect"].Value),
					elFailsInterError = Int32.Parse(m.Groups["FailsInterError"].Value),
					elFailsOtherError = Int32.Parse(m.Groups["FailsOtherError"].Value),
					elPacketLate = Int32.Parse(m.Groups["PacketLate"].Value)
				});
			}
			list.Sort(delegate (ft_struct.elementicmp x, ft_struct.elementicmp y)
			{
				return x.elTime.CompareTo(y.elTime);
			});
		}

		public static void addtcp(MatchCollection mc, List<ft_struct.elementtcp> list)
		{
			foreach (Match m in mc)
			{
				string date = m.Groups["Starttime"].Value;
				list.Add(new ft_struct.elementtcp()
				{
					elNumber = Int32.Parse(m.Groups["Number"].Value),
					elIP = m.Groups["IP"].Value,
					elTime = DateTime.ParseExact(date.Substring(0, date.IndexOf('.', 0)),
												 "yyyy-MM-dd HH:mm:ss", new CultureInfo("fr-FR")),
					elLifetime = Int32.Parse(m.Groups["Lifetime"].Value),
					elSendoptime = Int32.Parse(m.Groups["Sendoptime"].Value),
					elRecetime = Int32.Parse(m.Groups["Recetime"].Value),
					elMin = Int32.Parse(m.Groups["Min"].Value),
					elMax = Int32.Parse(m.Groups["Max"].Value),
					elAvr = Int32.Parse(m.Groups["Avr"].Value),
					elPacketLost = Int32.Parse(m.Groups["PacketLost"].Value),
					elFailsTimeOut = Int32.Parse(m.Groups["FailsTimeOut"].Value),
					elFailsDisconnect = Int32.Parse(m.Groups["FailsDisconnect"].Value),
					elFailsNoConnect = Int32.Parse(m.Groups["FailsNoConnect"].Value),
					elFailsInterError = Int32.Parse(m.Groups["FailsInterError"].Value),
					elFailsOtherError = Int32.Parse(m.Groups["FailsOtherError"].Value)
				});
			}

			list.Sort(delegate (ft_struct.elementtcp x, ft_struct.elementtcp y)
			{
				return x.elTime.CompareTo(y.elTime);
			});
		}
		private static int avrSum(int a, int b)
		{
			int tmp;
			if (a == 0 || b == 0)
				tmp = 0;
			else
				tmp = a / b;
			return (tmp);
		}

		private static int tryInt(string test)
		{
			int result = 0;
			Int32.TryParse(test, out result);
			return result;
		}

	}
}

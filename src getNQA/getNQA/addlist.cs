using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using getNQAstruct;

namespace getNQA
{
	public class addlist
	{
		public addlist()
		{
		}

		public static void addudp(MatchCollection mc, List<ft_struct.elementudp> list)
		{
			foreach (Match m in mc)
			{
				string date = m.Groups["Starttime"].Value;
				list.Add(new ft_struct.elementudp()
				{
					elNumber = tryInt(m.Groups["Number"].Value),
					elIP = m.Groups["IP"].Value,
					elTime = DateTime.ParseExact(date.Substring(0, date.IndexOf('.', 0)),
												 "yyyy-MM-dd HH:mm:ss", new CultureInfo("fr-FR")),
					elLifetime = tryInt(m.Groups["Lifetime"].Value),
					elSendoptime = tryInt(m.Groups["Sendoptime"].Value),
					elRecetime = tryInt(m.Groups["Recetime"].Value),
					elMin = tryInt(m.Groups["Min"].Value),
					elMax = tryInt(m.Groups["Max"].Value),
					elAvr = tryInt(m.Groups["Avr"].Value),
					elPacketLost = tryInt(m.Groups["PacketLost"].Value),
					elFailsTimeOut = tryInt(m.Groups["FailsTimeOut"].Value),
					elFailsDisconnect = tryInt(m.Groups["FailsDisconnect"].Value),
					elFailsNoConnect = tryInt(m.Groups["FailsNoConnect"].Value),
					elFailsSeqError = tryInt(m.Groups["FailsSeqError"].Value),
					elFailsInterError = tryInt(m.Groups["FailsInterError"].Value),
					elFailsOtherError = tryInt(m.Groups["FailsOtherError"].Value),
					elPacketLate = tryInt(m.Groups["PacketLate"].Value),
					elRTTnumber = tryInt(m.Groups["RTTnumber"].Value),
					elMinPosSD = tryInt(m.Groups["MinPosSD"].Value),
					elMaxPosSD = tryInt(m.Groups["MaxPosSD"].Value),
					elAvrPosSD = tryInt(m.Groups["AvrPosSD"].Value),
					elMinPosDS = tryInt(m.Groups["MinPosDS"].Value),
					elMaxPosDS = tryInt(m.Groups["MaxPosDS"].Value),
					elAvrPosDS = tryInt(m.Groups["AvrPosDS"].Value),
					elMinNegSD = tryInt(m.Groups["MinNegSD"].Value),
					elMaxNegSD = tryInt(m.Groups["MaxNegSD"].Value),
					elAvrNegSD = tryInt(m.Groups["AvrNegSD"].Value),
					elMinNegDS = tryInt(m.Groups["MinNegDS"].Value),
					elMaxNegDS = tryInt(m.Groups["MaxNegDS"].Value),
					elAvrNegDS = tryInt(m.Groups["AvrNegDS"].Value),
					elMinSDdelay = tryInt(m.Groups["MinSDdelay"].Value),
					elMaxSDdelay = tryInt(m.Groups["MaxSDdelay"].Value),
					elSumSDDelay = tryInt(m.Groups["SumSDDelay"].Value),
					elAvrSDDelay = avrSum(tryInt(m.Groups["SumSDDelay"].Value), tryInt(m.Groups["Recetime"].Value)),
					elMinDSdelay = tryInt(m.Groups["MinDSdelay"].Value),
					elMaxDSdelay = tryInt(m.Groups["MaxDSdelay"].Value),
					elSumDSDelay = tryInt(m.Groups["SumDSDelay"].Value),
					elAvrDSDelay = avrSum(tryInt(m.Groups["SumDSDelay"].Value), tryInt(m.Groups["Recetime"].Value)),
					elPacketSDLost = tryInt(m.Groups["PacketSDLost"].Value),
					elPacketDSLost = tryInt(m.Groups["PacketDSLost"].Value),
					elPacketUnkLost = tryInt(m.Groups["PacketUnkLost"].Value)
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
					elNumber = tryInt(m.Groups["Number"].Value),
					elIP = m.Groups["IP"].Value,
					elTime = DateTime.ParseExact(date.Substring(0, date.IndexOf('.', 0)),
												 "yyyy-MM-dd HH:mm:ss", new CultureInfo("fr-FR")),
					elLifetime = tryInt(m.Groups["Lifetime"].Value),
					elSendoptime = tryInt(m.Groups["Sendoptime"].Value),
					elRecetime = tryInt(m.Groups["Recetime"].Value),
					elMin = tryInt(m.Groups["Min"].Value),
					elMax = tryInt(m.Groups["Max"].Value),
					elAvr = tryInt(m.Groups["Avr"].Value),
					elPacketLost = tryInt(m.Groups["PacketLost"].Value),
					elFailsTimeOut = tryInt(m.Groups["FailsTimeOut"].Value),
					elFailsDisconnect = tryInt(m.Groups["FailsDisconnect"].Value),
					elFailsNoConnect = tryInt(m.Groups["FailsNoConnect"].Value),
					elFailsInterError = tryInt(m.Groups["FailsInterError"].Value),
					elFailsOtherError = tryInt(m.Groups["FailsOtherError"].Value),
					elPacketLate = tryInt(m.Groups["PacketLate"].Value)
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
					elNumber = tryInt(m.Groups["Number"].Value),
					elIP = m.Groups["IP"].Value,
					elTime = DateTime.ParseExact(date.Substring(0, date.IndexOf('.', 0)),
												 "yyyy-MM-dd HH:mm:ss", new CultureInfo("fr-FR")),
					elLifetime = tryInt(m.Groups["Lifetime"].Value),
					elSendoptime = tryInt(m.Groups["Sendoptime"].Value),
					elRecetime = tryInt(m.Groups["Recetime"].Value),
					elMin = tryInt(m.Groups["Min"].Value),
					elMax = tryInt(m.Groups["Max"].Value),
					elAvr = tryInt(m.Groups["Avr"].Value),
					elPacketLost = tryInt(m.Groups["PacketLost"].Value),
					elFailsTimeOut = tryInt(m.Groups["FailsTimeOut"].Value),
					elFailsDisconnect = tryInt(m.Groups["FailsDisconnect"].Value),
					elFailsNoConnect = tryInt(m.Groups["FailsNoConnect"].Value),
					elFailsInterError = tryInt(m.Groups["FailsInterError"].Value),
					elFailsOtherError = tryInt(m.Groups["FailsOtherError"].Value)
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

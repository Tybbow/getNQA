namespace getNQApattern
{
	public static class ft_pattern
	{
		public static string sondeudp()
		{
			return @". : (?<Number>\d+)" +
				@"((?!.{1,4}\n\s.+ Destination IP address: \d+.\d+.\d+.\d+)|(?:.{1,4}\n\s.+ Destination IP address: (?<IP>\d+.\d+.\d+.\d+)))" +
				@".{1,4}\n\s.+ Start time: (?<Starttime>\d+-\d+-\d+ \d+:\d+:\d+.\d)" +
				@".{1,4}\n\s.+ Life time: (?<Lifetime>\d+).+" +
				@".{1,4}\n\s.+ Send operation times: (?<Sendoptime>\d+).+ Receive response times: (?<Recetime>\d+)" +
				@".{1,4}\n\s.+ Min/Max/Average round trip time: (?<Min>\d+)\/(?<Max>\d+)\/(?<Avr>\d+)" +
				@".{1,4}\n\s.+\n\s.+\n\s.+ (Packet loss in test|Packet loss ratio): (?<PacketLost>\d+)\%" +
				@"((?!.{1,4}\n\s.+ Failures due to timeout: \d+)|(?:.{1,4}\n\s.+ Failures due to timeout: (?<FailsTimeOut>\d+)))" +
				@"((?!.{1,4}\n\s.+ Failures due to disconnect: \d+)|(?:.{1,4}\n\s.+ Failures due to disconnect: (?<FailsDisconnect>\d+)))" +
				@"((?!.{1,4}\n\s.+ Failures due to no connection: \d+)|(?:.{1,4}\n\s.+ Failures due to no connection: (?<FailsNoConnect>\d+)))" +
				@"((?!.{1,4}\n\s.+ Failures due to sequence error: \d+)|(?:.{1,4}\n\s.+ Failures due to sequence error: (?<FailsSeqError>\d+)))" +
				@".{1,4}\n\s.+ Failures due to internal error: (?<FailsInterError>\d+)" +
				@".{1,4}\n\s.+ Failures due to other errors: (?<FailsOtherError>\d+)" +
				@"((?!.{1,4}\n\s.+ Packets out of sequence: \d+)|(?:.{1,4}\n\s.+ Packets out of sequence: (?<FailsSeqError>\d+)))" +
				@".{1,4}\n\s.+ (Packets|Packet\(s\)) arrived late: (?<PacketLate>\d+)" +
				@".{1,4}\n\s.+\n\s.+ RTT number: (?<RTTnumber>\d+)" +
				@".{1,4}\n\s.+ Min positive SD: (?<MinPosSD>\d+).+ Min positive DS: (?<MinPosDS>\d+)" +
				@".{1,4}\n\s.+ Max positive SD: (?<MaxPosSD>\d+).+ Max positive DS: (?<MaxPosDS>\d+)" +
				@".{1,4}\n\s.+\n\s.+\n\s.+ Positive SD average: (?<AvrPosSD>\d+).+ Positive DS average: (?<AvrPosDS>\d+)" +
				@".{1,4}\n.+\n.+ Min negative SD: (?<MinNegSD>\d+).+ Min negative DS: (?<MinNegDS>\d+)" +
				@".{1,4}\n\s.+ Max negative SD: (?<MaxNegSD>\d+).+ Max negative DS: (?<MaxNegDS>\d+)" +
				@".{1,4}\n\s.+\n\s.+\n\s.+ Negative SD average: (?<AvrNegSD>\d+).+ Negative DS average: (?<AvrNegDS>\d+)" +
				@".{1,4}\n\s.+\n\s.+\n\s.+ Max SD delay: (?<MaxSDdelay>\d+).+ Max DS delay: (?<MaxDSdelay>\d+)" +
				@".{1,4}\n\s.+ Min SD delay: (?<MinSDdelay>\d+).+ Min DS delay: (?<MinDSdelay>\d+)" +
				@".{1,4}\n\s.+\n\s.+ Sum of SD delay: (?<SumSDDelay>\d+).+ Sum of DS delay: (?<SumDSDelay>\d+)" +
				@".{1,4}\n\s.+\n\s.+ SD lost (packets|packet\(s\)): (?<PacketSDLost>\d+).+ DS lost (packets|packet\(s\)): (?<PacketDSLost>\d+)" +
				@".{1,4}\n\s.+ Lost (packets|packet\(s\)) for unknown reason: (?<PacketUnkLost>\d+)";
		}

		public static string sondeicmp()
		{
			return @". : (?<Number>\d+)\s\n.*address: (?<IP>\d+.\d+.\d+.\d+)" +
				@"((?!\s\n.+ Destination IP address: \d+.\d+.\d+.\d+)|(?:\s\n.+ Destination IP address: (?<IP>\d+.\d+.\d+.\d+)))" +
				@"\s\n.+ Start time: (?<Starttime>\d+-\d+-\d+ \d+:\d+:\d+.\d)" +
				@"\s\n.+ Life time: (?<Lifetime>\d+).+" +
				@"\s\n.+ Send operation times: (?<Sendoptime>\d+).+ Receive response times: (?<Recetime>\d+)" +
				@"\s\n.+ Min/Max/Average round trip time: (?<Min>\d+)\/(?<Max>\d+)\/(?<Avr>\d+)" +
				@"\s\n.+\s\n.+\s\n.+ (Packet loss in test|Packet loss ratio): (?<PacketLost>\d+)\%" +
				@"((?!\s\n.+ Failures due to timeout: \d+)|(?:\s\n.+ Failures due to timeout: (?<FailsTimeOut>\d+)))" +
				@"((?!\s\n.+ Failures due to disconnect: \d+)|(?:\s\n.+ Failures due to disconnect: (?<FailsDisconnect>\d+)))" +
				@"((?!\s\n.+ Failures due to no connection: \d+)|(?:\s\n.+ Failures due to no connection: (?<FailsNoConnect>\d+)))" +
				@"((?!\s\n.+ Failures due to sequence error: \d+)|(?:\s\n.+ Failures due to sequence error: (?<FailsSeqError>\d+)))" +
				@"\s\n.+ Failures due to internal error: (?<FailsInterError>\d+)" +
				@"\s\n.+ Failures due to other errors: (?<FailsOtherError>\d+)" +
				@"((?!\s\n.+ Packets out of sequence: \d+)|(?:\s\n.+ Packets out of sequence: (?<FailsSeqError>\d+)))" +
				@"\s\n.+ (Packets|Packet\(s\)) arrived late: (?<PacketLate>\d+)" +
				@"\s\n.+ NO";
		}

		public static string sondetcp()
		{
			return @". : (?<Number>\d+)" +
				@"\s\n.+ Start time: (?<Starttime>\d+-\d+-\d+ \d+:\d+:\d+.\d)" +
				@"\s\n.+ Life time: (?<Lifetime>\d+).+" +
				@"\s\n.+ Send operation times: (?<Sendoptime>\d+).+ Receive response times: (?<Recetime>\d+)" +
				@"\s\n.+ Min/Max/Average round trip time: (?<Min>\d+)\/(?<Max>\d+)\/(?<Avr>\d+)" +
				@"\s\n.+\s\n.+\s\n.+ Packet loss ratio: (?<PacketLost>\d+)\%" +
				@"\s\n.+ Failures due to timeout: (?<FailsTimeOut>\d+)" +
				@"\s\n.+ Failures due to disconnect: (?<FailsDisconnect>\d+)" +
				@"\s\n.+ Failures due to no connection: (?<FailsNoConnect>\d+)" +
				@"\s\n.+ Failures due to internal error: (?<FailsInterError>\d+)" +
				@"\s\n.+ Failures due to other errors: (?<FailsOtherError>\d+)";
		}

		public static string sondeall()
		{
			return @". : (?<Number>\d+)" +
				@"\s\n.+ Start time: (?<Starttime>\d+-\d+-\d+ \d+:\d+:\d+.\d)" +
				@"\s\n.+ Life time: (?<Lifetime>\d+).+" +
				@"\s\n.+ Send operation times: (?<Sendoptime>\d+).+ Receive response times: (?<Recetime>\d+)" +
				@"\s\n.+ Min/Max/Average round trip time: (?<Min>\d+)\/(?<Max>\d+)\/(?<Avr>\d+)" +
				@"\s\n.+\s\n.+\s\n.+ (Packet loss in test|Packet loss ratio): (?<PacketLost>\d+)\%" +
				@"\s\n.+ Failures due to timeout: (?<FailsTimeOut>\d+)" +
				@"\s\n.+ Failures due to disconnect: (?<FailsDisconnect>\d+)" +
				@"\s\n.+ Failures due to no connection: (?<FailsNoConnect>\d+)" +
				@"\s\n.+ Failures due to sequence error: (?<FailsSeqError>\d+)" +
				@"\s\n.+ Failures due to internal error: (?<FailsInterError>\d+)" +
				@"\s\n.+ Failures due to other errors: (?<FailsOtherError>\d+)" +
				@"\s\n.+ Packet\(s\) arrived late: (?<PacketLate>\d+)" +
				@"\s\n.+\s\n.+ RTT number: (?<RTTnumber>\d+)" +
				@"\s\n.+ Min positive SD: (?<MinPosSD>\d+).+ Min positive DS: (?<MinPosDS>\d+)" +
				@"\s\n.+ Max positive SD: (?<MaxPosSD>\d+).+ Max positive DS: (?<MaxPosDS>\d+)" +
				@"\s\n.+\s\n.+\s\n.+ Positive SD average: (?<AvrPosSD>\d+).+ Positive DS average: (?<AvrPosDS>\d+)" +
				@"\s\n.+\s\n.+ Min negative SD: (?<MinNegSD>\d+).+ Min negative DS: (?<MinNegDS>\d+)" +
				@"\s\n.+ Max negative SD: (?<MaxNegSD>\d+).+ Max negative DS: (?<MaxNegDS>\d+)" +
				@"\s\n.+\s\n.+\s\n.+ Negative SD average: (?<AvrNegSD>\d+).+ Negative DS average: (?<AvrNegDS>\d+)" +
				@"\s\n.+\s\n.+\s\n.+ Max SD delay: (?<MaxSDdelay>\d+).+ Max DS delay: (?<MaxDSdelay>\d+)" +
				@"\s\n.+ Min SD delay: (?<MinSDdelay>\d+).+ Min DS delay: (?<MinDSdelay>\d+)" +
				@"\s\n.+\s\n.+ Sum of SD delay: (?<SumSDDelay>\d+).+ Sum of DS delay: (?<SumDSDelay>\d+)" +
				@"\s\n.+\s\n.+ SD lost packet\(s\): (?<PacketSDLost>\d+).+ DS lost packet\(s\): (?<PacketDSLost>\d+)" +
				@"\s\n.+ Lost packet\(s\) for unknown reason: (?<PacketUnkLost>\d+)";
		}
	}
}

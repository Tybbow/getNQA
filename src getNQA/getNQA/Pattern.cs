namespace getNQApattern
{
	public static class ft_pattern
	{
		public static string sondeudp()
		{
			return @". : (?<Number>\d+)" +
				@"((?!\s\n.+ Destination IP address: \d+.\d+.\d+.\d+)|(?:\s\n.+ Destination IP address: (?<IP>\d+.\d+.\d+.\d+)))";
		//		@"(?:\s\n.+ Destination IP address: (?<IP>\d+.\d+.\d+.\d+))|(?!\s\n.+ Destination IP address: (?<IP>\d+.\d+.\d+.\d+))";
		//		@"\s\n.+ Start time: (?<Starttime>\d+-\d+-\d+ \d+:\d+:\d+.\d)" +
		//		@"\s\n.+ Life time: (?<Lifetime>\d+).+" +
		//		@"\s\n.+ Send operation times: (?<Sendoptime>\d+).+ Receive response times: (?<Recetime>\d+)" +
		//		@"\s\n.+ Min/Max/Average round trip time: (?<Min>\d+)\/(?<Max>\d+)\/(?<Avr>\d+)" +
		//		@"\s\n.+\s\n.+\s\n.+ (Packet loss in test|Packet loss ratio): (?<PacketLost>\d+)\%" +
		//		@"(?:\s\n.+ Failures due to timeout: (?<FailsTimeOut>\d+))|(?!\s\n.+ Failures due to timeout: (?<FailsTimeOut>\d+))" +
		//		@"(?:\s\n.+ Failures due to disconnect: (?<FailsDisconnect>\d+))|(?!\s\n.+ Failures due to disconnect: (?<FailsDisconnect>\d+))" +
		//		@"(?:\s\n.+ Failures due to no connection: (?<FailsNoConnect>\d+))|(?!\s\n.+ Failures due to no connection: (?<FailsNoConnect>\d+))" +
		//		@"(?:\s\n.+ Failures due to sequence error: (?<FailsSeqError>\d+))|(?!\s\n.+ Failures due to sequence error: (?<FailsSeqError>\d+))" +
		//		@"\s\n.+ Failures due to internal error: (?<FailsInterError>\d+)|" +
		//		@"\s\n.+ Failures due to other errors: (?<FailsOtherError>\d+)" +
		//		@"(?:\s\n.+ Packets out of sequence: (?<FailsSeqError>\d+))|" +
		//		@"\s\n.+ (Packets|Packet\(s\)) arrived late: (?<PacketLate>\d+)" +
		//		@"\s\n.+\s\n.+ RTT number: (?<RTTnumber>\d+)" +
		//		@"\s\n.+ Min positive SD: (?<MinPosSD>\d+).+ Min positive DS: (?<MinPosDS>\d+)" +
		//		@"\s\n.+ Max positive SD: (?<MaxPosSD>\d+).+ Max positive DS: (?<MaxPosDS>\d+)" +
		//		@"\s\n.+\s\n.+\s\n.+ Positive SD average: (?<AvrPosSD>\d+).+ Positive DS average: (?<AvrPosDS>\d+)" +
		//		@"\s\n.+\s\n.+ Min negative SD: (?<MinNegSD>\d+).+ Min negative DS: (?<MinNegDS>\d+)" +
		//		@"\s\n.+ Max negative SD: (?<MaxNegSD>\d+).+ Max negative DS: (?<MaxNegDS>\d+)" +
		//		@"\s\n.+\s\n.+\s\n.+ Negative SD average: (?<AvrNegSD>\d+).+ Negative DS average: (?<AvrNegDS>\d+)" +
		//		@"\s\n.+\s\n.+\s\n.+ Max SD delay: (?<MaxSDdelay>\d+).+ Max DS delay: (?<MaxDSdelay>\d+)" +
		//		@"\s\n.+ Min SD delay: (?<MinSDdelay>\d+).+ Min DS delay: (?<MinDSdelay>\d+)" +
		//		@"\s\n.+\s\n.+ Sum of SD delay: (?<SumSDDelay>\d+).+ Sum of DS delay: (?<SumDSDelay>\d+)" +
		//		@"\s\n.+\s\n.+ SD lost packets: (?<PacketSDLost>\d+).+ DS lost packets: (?<PacketDSLost>\d+)" +
		//		@"\s\n.+ Lost (packets|Packet\(s\)) for unknown reason: (?<PacketUnkLost>\d+)";
		}

		public static string testRegex()
		{
			return "Merde";
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

		public static string sondeicmp()
		{
			return @". : (?<Number>\d+)\s\n.*address: (?<IP>\d+.\d+.\d+.\d+)" +
				@"\s\n.+ Start time: (?<Starttime>\d+-\d+-\d+ \d+:\d+:\d+.\d)" +
				@"\s\n.+ Life time: (?<Lifetime>\d+).+" +
				@"\s\n.+ Send operation times: (?<Sendoptime>\d+).+ Receive response times: (?<Recetime>\d+)" +
				@"\s\n.+ Min/Max/Average round trip time: (?<Min>\d+)\/(?<Max>\d+)\/(?<Avr>\d+)" +
				@"\s\n.+\s\n.+\s\n.+ Packet loss in test: (?<PacketLost>\d+)\%" +
				@"\s\n.+ Failures due to timeout: (?<FailsTimeOut>\d+)" +
				@"\s\n.+ Failures due to disconnect: (?<FailsDisconnect>\d+)" +
				@"\s\n.+ Failures due to no connection: (?<FailsNoConnect>\d+)" +
				@"\s\n.+ Failures due to sequence error: (?<FailsSeqError>\d+)" +
				@"\s\n.+ Failures due to internal error: (?<FailsInterError>\d+)" +
				@"\s\n.+ Failures due to other errors: (?<FailsOtherError>\d+)" +
				@"\s\n.+ Packet\(s\) arrived late: (?<PacketLate>\d+)" +
				@"\s\n.+ NO";
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

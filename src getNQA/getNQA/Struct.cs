using System;

namespace getNQAstruct
{
	public static class ft_struct
	{

		public class elementtest : IEquatable<elementtest>, IComparable<elementtest>
		{
			public int elNumber { get; set; }
			public string elIP { get; set; }
			//public DateTime elTime { get; set; }
			//public int elLifetime { get; set; }
			//public int elSendoptime { get; set; }
			//public int elRecetime { get; set; }
			//public int elMin { get; set; }
			//public int elMax { get; set; }
			//public int elAvr { get; set; }
			//public int elPacketLost { get; set; }
			//public int elFailsTimeOut { get; set; }
			//public int elFailsDisconnect { get; set; }
			//public int elFailsNoConnect { get; set; }
			//public int elFailsInterError { get; set; }
			//public int elFailsOtherError { get; set; }
			//public int elPacketLate { get; set; }

			public override string ToString()
			{
				return elNumber + ";" + elIP + ";";

				//return elNumber + ";" + elIP + ";" + elTime + ";" + elLifetime + ";" + elSendoptime + ";" + elRecetime
				//	+ ";" + elMin + ";" + elMax + ";" + elAvr + ";" + elPacketLost + ";" + elFailsTimeOut
				//+ ";" + elFailsDisconnect + ";" + elFailsNoConnect + ";" + elFailsInterError + ";" + elFailsOtherError
				//+ ";" + elPacketLate;
			}

			public override bool Equals(object obj)
			{
				if (obj == null) return false;
				elementtest objAselement = obj as elementtest;
				if (objAselement == null) return false;
				else return Equals(objAselement);
			}

			// Default comparer for element type.
			public int CompareTo(elementtest compareelement)
			{
				// A null value means that this object is greater.
				if (compareelement == null)
					return 1;
				else
					return this.elNumber.CompareTo(compareelement.elNumber);
			}

			public override int GetHashCode()
			{
				return elNumber;
			}

			public bool Equals(elementtest other)
			{
				if (other == null) return false;
				return (this.elNumber.Equals(other.elNumber));
			}

		}

		public class elementudp : IEquatable<elementudp>, IComparable<elementudp>
		{
			public int elNumber { get; set; }
			public string elIP { get; set; }
			public DateTime elTime { get; set; }
			public int elLifetime { get; set; }
			public int elSendoptime { get; set; }
			public int elRecetime { get; set; }
			public int elMin { get; set; }
			public int elMax { get; set; }
			public int elAvr { get; set; }
			public int elPacketLost { get; set; }
			public int elFailsTimeOut { get; set; }
			public int elFailsDisconnect { get; set; }
			public int elFailsNoConnect { get; set; }
			public int elFailsSeqError { get; set; }
			public int elFailsInterError { get; set; }
			public int elFailsOtherError { get; set; }
			public int elPacketLate { get; set; }
			public int elRTTnumber { get; set; }
			public int elMinPosSD { get; set; }
			public int elMinPosDS { get; set; }
			public int elMaxPosSD { get; set; }
			public int elMaxPosDS { get; set; }
			public int elAvrPosSD { get; set; }
			public int elAvrPosDS { get; set; }
			public int elMinNegSD { get; set; }
			public int elMinNegDS { get; set; }
			public int elMaxNegSD { get; set; }
			public int elMaxNegDS { get; set; }
			public int elAvrNegSD { get; set; }
			public int elAvrNegDS { get; set; }
			public int elMaxSDdelay { get; set; }
			public int elMaxDSdelay { get; set; }
			public int elMinSDdelay { get; set; }
			public int elMinDSdelay { get; set; }
			public int elSumSDDelay { get; set; }
			public int elAvrSDDelay { get; set; }
			public int elSumDSDelay { get; set; }
			public int elAvrDSDelay { get; set; }
			public int elPacketSDLost { get; set; }
			public int elPacketDSLost { get; set; }
			public int elPacketUnkLost { get; set; }

			public override string ToString()
			{
				return elNumber +  ";" + elIP + ";" + elTime +  ";" + elLifetime +  ";" + elSendoptime +  ";" + elRecetime
					 	+  ";" + elMin +  ";" + elMax +  ";" + elAvr +  ";" + elPacketLost +  ";" + elFailsTimeOut
						+  ";" + elFailsDisconnect +  ";" + elFailsNoConnect +  ";" + elFailsSeqError +  ";" + elFailsInterError
					 	+  ";" + elFailsOtherError +  ";" + elPacketLate +  ";" + elRTTnumber +  ";" + elMinPosSD +  ";" + elMaxPosSD
						+  ";" + elAvrPosSD +  ";" + elMinPosDS +  ";" + elMaxPosDS +  ";" + elAvrPosDS +  ";" + elMinNegSD +  ";" + elMaxNegSD +  ";" + elAvrNegSD
						+  ";" + elMinNegDS +  ";" + elMaxNegDS +  ";" + elAvrNegDS +  ";" + elMinSDdelay +  ";" + elMaxSDdelay +  ";" + elAvrSDDelay
						+  ";" + elMinDSdelay +  ";" + elMaxDSdelay + ";" + elAvrDSDelay +  ";" + elPacketSDLost +  ";" + elPacketDSLost +  ";" + elPacketUnkLost;
			}

			public override bool Equals(object obj)
			{
				if (obj == null) return false;
				elementudp objAselement = obj as elementudp;
				if (objAselement == null) return false;
				else return Equals(objAselement);
			}

			// Default comparer for element type.
			public int CompareTo(elementudp compareelement)
			{
				// A null value means that this object is greater.
				if (compareelement == null)
					return 1;
				else
					return this.elNumber.CompareTo(compareelement.elNumber);
			}

			public override int GetHashCode()
			{
				return elNumber;
			}

			public bool Equals(elementudp other)
			{
				if (other == null) return false;
				return (this.elNumber.Equals(other.elNumber));
			}

		}

		public class elementicmp : IEquatable<elementicmp>, IComparable<elementicmp>
		{
			public int elNumber { get; set; }
			public string elIP { get; set; }
			public DateTime elTime { get; set; }
			public int elLifetime { get; set; }
			public int elSendoptime { get; set; }
			public int elRecetime { get; set; }
			public int elMin { get; set; }
			public int elMax { get; set; }
			public int elAvr { get; set; }
			public int elPacketLost { get; set; }
			public int elFailsTimeOut { get; set; }
			public int elFailsDisconnect { get; set; }
			public int elFailsNoConnect { get; set; }
			public int elFailsInterError { get; set; }
			public int elFailsOtherError { get; set; }
			public int elPacketLate { get; set; }

			public override string ToString()
			{
				return elNumber + ";" + elIP + ";" + elTime + ";" + elLifetime + ";" + elSendoptime + ";" + elRecetime
					 	+ ";" + elMin + ";" + elMax + ";" + elAvr + ";" + elPacketLost + ";" + elFailsTimeOut
						+ ";" + elFailsDisconnect + ";" + elFailsNoConnect + ";" + elFailsInterError + ";" + elFailsOtherError
						+ ";" + elPacketLate;
			}

			public override bool Equals(object obj)
			{
				if (obj == null) return false;
				elementicmp objAselement = obj as elementicmp;
				if (objAselement == null) return false;
				else return Equals(objAselement);
			}

			// Default comparer for element type.
			public int CompareTo(elementicmp compareelement)
			{
				// A null value means that this object is greater.
				if (compareelement == null)
					return 1;
				else
					return this.elNumber.CompareTo(compareelement.elNumber);
			}

			public override int GetHashCode()
			{
				return elNumber;
			}

			public bool Equals(elementicmp other)
			{
				if (other == null) return false;
				return (this.elNumber.Equals(other.elNumber));
			}

		}

		public class elementtcp : IEquatable<elementtcp>, IComparable<elementtcp>
		{
			public int elNumber { get; set; }
			public string elIP { get; set; }
			public DateTime elTime { get; set; }
			public int elLifetime { get; set; }
			public int elSendoptime { get; set; }
			public int elRecetime { get; set; }
			public int elMin { get; set; }
			public int elMax { get; set; }
			public int elAvr { get; set; }
			public int elPacketLost { get; set; }
			public int elFailsTimeOut { get; set; }
			public int elFailsDisconnect { get; set; }
			public int elFailsNoConnect { get; set; }
			public int elFailsInterError { get; set; }
			public int elFailsOtherError { get; set; }

			public override string ToString()
			{
				return elNumber + ";" + elIP + ";" + elTime + ";" + elLifetime + ";" + elSendoptime + ";" + elRecetime
					 	+ ";" + elMin + ";" + elMax + ";" + elAvr + ";" + elPacketLost + ";" + elFailsTimeOut
						+ ";" + elFailsDisconnect + ";" + elFailsNoConnect + ";" + elFailsInterError + ";" + elFailsOtherError;
			}

			public override bool Equals(object obj)
			{
				if (obj == null) return false;
				elementtcp objAselement = obj as elementtcp;
				if (objAselement == null) return false;
				else return Equals(objAselement);
			}

			// Default comparer for element type.
			public int CompareTo(elementtcp compareelement)
			{
				// A null value means that this object is greater.
				if (compareelement == null)
					return 1;
				else
					return this.elNumber.CompareTo(compareelement.elNumber);
			}

			public override int GetHashCode()
			{
				return elNumber;
			}

			public bool Equals(elementtcp other)
			{
				if (other == null) return false;
				return (this.elNumber.Equals(other.elNumber));
			}

		}

		public class tmp
		{
			public string elIP { get; set; }
			public DateTime elTime { get; set; }
			public string path { get; set; }
			public int numtime { get; set; }

			public override string ToString()
			{
				return elIP + ";" + elTime + ";" + numtime + ";" + path;
			}
		}
	}
}

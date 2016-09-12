using Newtonsoft.Json;
using System.Numerics;
using System;

namespace Openpay.Entities
{

	public class PointsBalance
	{

		private string _pointsType;

		[JsonProperty(PropertyName = "points_type")]
		public String PointsType { 
			get { return _pointsType; }
			set { _pointsType = value; }
		}

		[JsonProperty(PropertyName = "remaining_points")]
		public BigInteger RemainingPoints { get; set; }

		[JsonProperty(PropertyName = "remaining_mxn")]
		public Decimal RemainingMxn { get; set; }

		public PointsType PointsTypeEnum
		{
			get
			{
				return (PointsType)System.Enum.Parse(typeof(PointsType), _pointsType.ToUpper());
			}
		}

	}

}


using System;
using System.Collections.Generic;
using System.Text;

namespace LogoDotnetAssignment.Core.Models
{
	public class BTC
	{
		public int id { get; set; }
		public float? price { get; set; }
		public float? volume_24h { get; set; }
		public float? percent_change_1h { get; set; }
		public float? percent_change_24h { get; set; }
		public float? percent_change_7d { get; set; }
		public float? market_cap { get; set; }
		public DateTime? last_updated { get; set; }
		
	}
}

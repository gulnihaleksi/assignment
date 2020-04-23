using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LogoDotnetAssignment.Core.Models
{
	public class VirtualMoney
	{
		public VirtualMoney()
		{
			qoute = new Collection<BTC>();
		}

		public int id {get; set;}
		public string name { get; set; }
		public string symbol { get; set; }
		public string slug { get; set; }
		public int? num_market_pairs { get; set; }
		public DateTime date_added { get; set; }
		public float? max_supply { get; set; }
		public float? circulating_supply { get; set; }
		public float? total_supply { get; set; }
		public float? cmc_rank { get; set; }
		public DateTime? last_updated { get; set; }
		public ICollection<BTC> qoute { get; set; }
	}
}

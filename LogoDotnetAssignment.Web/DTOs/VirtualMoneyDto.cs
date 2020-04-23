using LogoDotnetAssignment.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Web.DTOs
{
	public class VirtualMoneyDto : Header
	{
		public int id { get; set; }

		[Required(ErrorMessage = "{0} is required.")]
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

	public class Header
	{
		public string token { get; set; }
	}
}

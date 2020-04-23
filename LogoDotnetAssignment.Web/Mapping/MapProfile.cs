using AutoMapper;
using LogoDotnetAssignment.Core.Models;
using LogoDotnetAssignment.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Web.Mapping
{
	public class MapProfile :Profile
	{
		public MapProfile()
		{
			CreateMap<VirtualMoney, VirtualMoneyDto>();
			CreateMap<VirtualMoneyDto, VirtualMoney>();
		}
	}
}

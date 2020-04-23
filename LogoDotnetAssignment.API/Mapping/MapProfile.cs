using AutoMapper;
using LogoDotnetAssignment.API.DTOs;
using LogoDotnetAssignment.Core.Models;

namespace LogoDotnetAssignment.API.Mapping
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

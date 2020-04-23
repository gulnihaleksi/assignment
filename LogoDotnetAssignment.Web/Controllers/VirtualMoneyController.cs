using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LogoDotnetAssignment.Core.Services;
using LogoDotnetAssignment.Web.ApiService;
using LogoDotnetAssignment.Web.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogoDotnetAssignment.Web.Controllers
{
    public class VirtualMoneyController : Controller
    {
		private readonly IVirtualMoneyService _virtualMoneyService;
		private readonly IMapper _mapper;
		private readonly IServiceFactory _serviceFactory;

		public VirtualMoneyController(IVirtualMoneyService virtualMoneyService , IMapper mapper , IServiceFactory serviceFactory)
		{
			_virtualMoneyService = virtualMoneyService;
			_mapper = mapper;
			_serviceFactory = serviceFactory;
		}

        public async Task<IActionResult> Index()
        {
			var JWToken = HttpContext.Session.GetString("JWToken");
			if (JWToken == null)
			{
				string _token = _serviceFactory.GetRun<VirtualMoneyDto>("VirtualMoney/Login").token;
				HttpContext.Session.SetString("JWToken", _token);
			}
			var response = await  _serviceFactory.GetAllRun<VirtualMoneyDto>("VirtualMoney/GetAll");
            return  View(_mapper.Map<IEnumerable<VirtualMoneyDto>>(response));
        }

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(VirtualMoneyDto virtualMoney)
		{
			virtualMoney.token = HttpContext.Session.GetString("JWToken");
			var response = await _serviceFactory.GetPostAsync<VirtualMoneyDto>("VirtualMoney/Save", virtualMoney);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Update(int id)
		{
			var JWToken = HttpContext.Session.GetString("JWToken");
			if (JWToken != null)
			{
				var response = await _serviceFactory.GetPostAsync<VirtualMoneyDto>("VirtualMoney/GetById", new VirtualMoneyDto
				{
					id = id,
					token = JWToken
				});
				return View(_mapper.Map<VirtualMoneyDto>(response));
			}
			else
				return View(null);
		}

		[HttpPost]
		public async Task<IActionResult> Update(VirtualMoneyDto virtualMoney)
		{
			virtualMoney.token = HttpContext.Session.GetString("JWToken");
			var response = await _serviceFactory.GetPostAsync<VirtualMoneyDto>("VirtualMoney/Update", virtualMoney);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var JWToken = HttpContext.Session.GetString("JWToken");
			var response = await _serviceFactory.GetPostAsync<VirtualMoneyDto>("VirtualMoney/Delete", new VirtualMoneyDto
			{
				id = id,
				token = JWToken
			});
			return RedirectToAction("Index");
		}
	}
}
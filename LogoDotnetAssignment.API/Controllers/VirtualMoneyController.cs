using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LogoDotnetAssignment.API.DTOs;
using LogoDotnetAssignment.Core.Models;
using LogoDotnetAssignment.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LogoDotnetAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualMoneyController : ControllerBase
    {
		private readonly IVirtualMoneyService _virtualMoneyService;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public VirtualMoneyController(IVirtualMoneyService virtualMoneyService , IMapper mapper , IConfiguration configuration)
		{
			_virtualMoneyService = virtualMoneyService;
			_mapper = mapper;
			_configuration = configuration;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var virtualMoney = await _virtualMoneyService.GetAll();
			return Ok(_mapper.Map<IEnumerable<VirtualMoneyDto>>(virtualMoney));
		}

		[Authorize]
		[HttpPost("GetById")]
		public async Task<IActionResult> GetById(VirtualMoneyDto request)
		{
			var virtualMoney = await _virtualMoneyService.GetById(request.id);
			return Ok(_mapper.Map<VirtualMoneyDto>(virtualMoney));
		}

		[Authorize]
		[HttpPost("Save")]
		public IActionResult Save(VirtualMoneyDto virtualMoney)
		{
			var newVirtualMoney =  _virtualMoneyService.Add(_mapper.Map<VirtualMoney>(virtualMoney));
			return Created(String.Empty, _mapper.Map<VirtualMoneyDto>(newVirtualMoney));
		}

		[Authorize]
		[HttpPost("Update")]
		public IActionResult Update(VirtualMoneyDto virtualMoney)
		{
			var newVirtualMoney = _virtualMoneyService.Update(_mapper.Map<VirtualMoney>(virtualMoney));
			return NoContent();
		}

		[Authorize]
		[HttpPost("Delete")]
		public IActionResult Delete(VirtualMoneyDto virtualMoney)
		{
			_virtualMoneyService.Delete(virtualMoney.id);
			return NoContent();
		}

		[HttpGet("Login")]
		public IActionResult Login()
		{
			var token = TokenControl("nihal","ekşi");
			VirtualMoneyDto response = new VirtualMoneyDto
			{
				Token = token
			};
			return Ok(response);
		}

		public string TokenControl(string name, string surname)
		{
			var claimsdata = new[] { new Claim(ClaimTypes.Name, name + surname) };
			string keyValue = _configuration.GetValue<string>("TokenKey:Key").ToString();
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue));
			var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
			var token = new JwtSecurityToken(
				 issuer: "mysite.com",
				 audience: "mysite.com",
				 expires: DateTime.Now.AddMinutes(90),
				 claims: claimsdata,
				 signingCredentials: signInCred
				);
			var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
			return tokenString;
		}

	}
}
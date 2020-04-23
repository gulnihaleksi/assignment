using LogoDotnetAssignment.Core.Repositories;
using LogoDotnetAssignment.Core.Services;
using LogoDotnetAssignment.Core.UnitOfWorks;
using LogoDotnetAssignment.Data;
using LogoDotnetAssignment.Data.Repositories;
using LogoDotnetAssignment.Data.UnitOfWorks;
using LogoDotnetAssignment.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LogoDotnetAssignment.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public void ConfigureServices(IServiceCollection services)
		{
			string dsd = Configuration["TokenKey:Key"].ToString();
			services.AddAutoMapper(typeof(Startup));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString()));
			services.AddScoped(typeof(IReporsitory<>),typeof(Repository<>));
			services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
			services.AddScoped<IVirtualMoneyService , VirtualMoneyService>();
			services.AddScoped<IBTCService, BTCService>();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddSingleton(Configuration);
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = "mysite.com",
					ValidAudience = "mysite.com",
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey:Key"].ToString()))
				};
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseAuthentication();
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}

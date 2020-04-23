using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogoDotnetAssignment.Core.Repositories;
using LogoDotnetAssignment.Core.Services;
using LogoDotnetAssignment.Core.UnitOfWorks;
using LogoDotnetAssignment.Data;
using LogoDotnetAssignment.Data.Repositories;
using LogoDotnetAssignment.Data.UnitOfWorks;
using LogoDotnetAssignment.Service.Services;
using LogoDotnetAssignment.Web.ApiService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogoDotnetAssignment.Web
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => false;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			//services.AddHttpClient<VirtualMoneyApiService>(opt =>
			//{
			//	opt.BaseAddress = new Uri(Configuration["baseUrl"]);
			//});

			services.AddAutoMapper(typeof(Startup));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString()));
			services.AddScoped(typeof(IReporsitory<>), typeof(Repository<>));
			services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
			services.AddScoped<IVirtualMoneyService, VirtualMoneyService>();
			services.AddScoped<IBTCService, BTCService>();
			services.AddScoped<IServiceFactory, ServiceFactory>();
			services.AddSession();
			services.AddSingleton(Configuration);
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseSession();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=VirtualMoney}/{action=Index}/{id?}");
			});
		}
	}
}

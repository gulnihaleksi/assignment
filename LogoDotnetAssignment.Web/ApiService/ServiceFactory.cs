using LogoDotnetAssignment.Web.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Web.ApiService
{
	public class ServiceFactory : IServiceFactory
	{
		private readonly IConfiguration _configuration;
		private readonly string baseAddress;
		public ServiceFactory(IConfiguration configuration)
		{
			_configuration = configuration;
			baseAddress = _configuration.GetValue<string>("baseUrl").ToString();
		}
		
		public async Task<TResponse> GetPostAsync<TResponse>(string endPoint, object request) where TResponse : class, new()
		{
			string keyValue = _configuration.GetValue<string>("baseUrl").ToString();
			TResponse respuonse = new TResponse();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseAddress);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var data = JsonConvert.SerializeObject(request);
				BearerTokenRequestDTO bearerTokenRequest = JsonConvert.DeserializeObject<BearerTokenRequestDTO>(data);
				if (bearerTokenRequest.Token != null)
				{
					client.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerTokenRequest.Token);
				}

				var content = new StringContent(data, Encoding.UTF8, "application/json");
				try
				{
					var result = await client.PostAsync(endPoint, content);
					if (result.IsSuccessStatusCode)
					{
						var response = result.Content.ReadAsAsync<TResponse>().Result;
						return response;
					}
					else
					{
						return null;
					}
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}


		public TResponse GetRun<TResponse>(string endPoint) where TResponse : class, new()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseAddress);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var getResponse = client.GetAsync(endPoint).Result;
				var readString = getResponse.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<TResponse>(readString.Result.ToString());
				return result;
			}
		}

		public async Task<IEnumerable<TResponse>> GetAllRun<TResponse>(string endPoint) where TResponse : class, new()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseAddress);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var getResponse =  client.GetAsync(endPoint).Result;
				var readString = await getResponse.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<IEnumerable<TResponse>>(readString);
				return result;
			}
		}

	}
}
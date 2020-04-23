using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Web.ApiService
{
	public interface IServiceFactory
	{
		Task<TResponse> GetPostAsync<TResponse>(string endPoint, object request) where TResponse : class, new();
		TResponse GetRun<TResponse>(string endPoint) where TResponse : class, new();
		Task<IEnumerable<TResponse>> GetAllRun<TResponse>(string endPoint) where TResponse : class, new();
	}
}
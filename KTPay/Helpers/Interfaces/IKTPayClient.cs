using System.Collections.Generic;
using System.Threading.Tasks;

namespace KTPay.Helpers.Interfaces {
    
    public interface IKTPayClient {
        
        Task<T> GetAsync<T>(string url);
        Task<T> GetAsync<T>(string url, string authorization);
        Task<T> GetAsync<T>(string url, string authorization, Dictionary<string, string> headers);
        Task<string> PostAsync<TRequest>(string url, TRequest request);
        Task<string> PostAsync<TRequest>(string url, TRequest request, string authorization);
        Task<string> PostAsync<TRequest>(string url, TRequest request, string authorization, Dictionary<string, string> headers);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, string authorization);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, string authorization, Dictionary<string, string> headers);
        Task<T> PostAsync<T>(string url, Dictionary<string, string> request);
        Task<T> PostAsync<T>(string url, Dictionary<string, string> request, string authorization);
        Task<T> PostAsync<T>(string url, Dictionary<string, string> request, string authorization, Dictionary<string, string> headers);
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using KTPay.Helpers.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KTPay.Helpers {
    
    public class KTPayClient : IKTPayClient, IDisposable {
        
        private static readonly object _lock = new object();
        private static HttpClient _client;
        private bool _disposed = false;

        private static HttpClient Client {

            get {
                if (_client == null) {
                    lock (_lock) {
                        if (_client == null) {
                            var handler = new HttpClientHandler();
                            handler.SslProtocols = SslProtocols.Tls12;
                            _client = new HttpClient(handler);
                        }
                    }
                }

                return _client;
            }
        }
        
        public async Task<T> GetAsync<T>(string url) {
            
            try {
                
                var request = new HttpRequestMessage {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
                };

                var clientResponse = await Client.SendAsync(request);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<T>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        public async Task<T> GetAsync<T>(string url, string authorization) {
            
            try {
                
                var request = new HttpRequestMessage {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
                };

                if (!string.IsNullOrEmpty(authorization)) {
                    SetAcceptHeader();
                    SetAuthorization(authorization);
                }

                var clientResponse = await Client.SendAsync(request);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<T>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        public async Task<T> GetAsync<T>(string url, string authorization, Dictionary<string, string> headers) {
            
            try {
                
                var request = new HttpRequestMessage {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
                };

                if (!string.IsNullOrEmpty(authorization)) {
                    SetAcceptHeader();
                    SetAuthorization(authorization);
                }

                if (headers != null && headers.Count > 0) {
                    AddHeaders(headers);
                }

                var clientResponse = await Client.SendAsync(request);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<T>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        public async Task<string> PostAsync<TRequest>(string url, TRequest request) {
            
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return await clientResponse.Content.ReadAsStringAsync();
            } catch {
               
                throw;
            }
        }

        public async Task<string> PostAsync<TRequest>(string url, TRequest request, string authorization) {
            
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                if (!string.IsNullOrEmpty(authorization)) {
                    SetAcceptHeader();
                    SetAuthorization(authorization);
                }

                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return await clientResponse.Content.ReadAsStringAsync();
            } catch {
               
                throw;
            }
        }

        public async Task<string> PostAsync<TRequest>(string url, TRequest request, string authorization, Dictionary<string, string> headers) {
            
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                if (!string.IsNullOrEmpty(authorization)) {
                    SetAcceptHeader();
                    SetAuthorization(authorization);
                }

                if (headers != null && headers.Count > 0) {
                    AddHeaders(headers);
                }
                
                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return await clientResponse.Content.ReadAsStringAsync();
            } catch {
               
                throw;
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request) {
            
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<TResponse>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, string authorization) {
            
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                if (!string.IsNullOrEmpty(authorization)) {
                    SetAcceptHeader();
                    SetAuthorization(authorization);
                }

                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<TResponse>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, string authorization, Dictionary<string, string> headers) {
            
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                if (!string.IsNullOrEmpty(authorization)) {
                    SetAcceptHeader();
                    SetAuthorization(authorization);
                }

                if (headers != null && headers.Count > 0) {
                    AddHeaders(headers);
                }
                
                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<TResponse>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        public async Task<T> PostAsync<T>(string url, Dictionary<string, string> request) {
            
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<T>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        public async Task<T> PostAsync<T>(string url, Dictionary<string, string> request, string authorization)
        {
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                if (!string.IsNullOrEmpty(authorization)) {
                    SetAcceptHeader();
                    SetAuthorization(authorization);
                }
                
                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<T>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        public async Task<T> PostAsync<T>(string url, Dictionary<string, string> request, string authorization, Dictionary<string, string> headers) {
            
            try {
                
                var requestMessage = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(
                        JsonConvert.SerializeObject(request, new JsonSerializerSettings() {
                            Formatting = Formatting.None,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }), 
                        Encoding.UTF8, 
                        "application/json")
                };
                
                if (!string.IsNullOrEmpty(authorization)) {
                    SetAcceptHeader();
                    SetAuthorization(authorization);
                }

                if (headers != null && headers.Count > 0) {
                    AddHeaders(headers);
                }
                
                var clientResponse = await Client.SendAsync(requestMessage);
                clientResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<T>(await clientResponse.Content.ReadAsStringAsync());
            } catch {
               
                throw;
            }
        }

        private void SetAcceptHeader() {
            
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void SetAuthorization(string token) {
            
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private void AddHeaders(Dictionary<string, string> headers) {

            foreach (KeyValuePair<string, string> header in headers) {
                Client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public void Dispose() {

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {

            if (!_disposed) {
                if (disposing) {
                    if (_client != null) {
                        _client.Dispose();
                        _client = null;
                    }
                }
                _disposed = true;
            }
        }
    }
}
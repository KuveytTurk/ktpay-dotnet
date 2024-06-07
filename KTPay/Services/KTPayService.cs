using System.Threading.Tasks;
using KTPay.Helpers.Interfaces;
using KTPay.Models.Request;
using KTPay.Models.Response;
using KTPay.Models.Response.Generic;
using KTPay.Services.Interfaces;

namespace KTPay.Services {
    
    public class KTPayService : IKTPayService {
        
        private readonly IKTPayClient _client;
        
        public KTPayService(IKTPayClient client) {
            _client = client;
        }

        public async Task<string> PaymentAsync(string serviceUrl, PaymentRequest paymentRequest) {
            
            var response = await _client.PostAsync(serviceUrl + "/KTPay/Payment", paymentRequest);
            return response;
        }

        public async Task<KTPayResponseResult<ProvisionResponse>> ProvisionAsync(string serviceUrl, ProvisionRequest provisionRequest) {
            
            var response = await _client.PostAsync<ProvisionRequest, KTPayResponseResult<ProvisionResponse>>(serviceUrl + "/KTPay/Provision", provisionRequest);
            return response;
        }

        public async Task<KTPayResponseResult<SaleReversalResponse>> SaleReversalAsync(string serviceUrl, SaleReversalRequest saleReversalRequest) {
            
            var response = await _client.PostAsync<SaleReversalRequest, KTPayResponseResult<SaleReversalResponse>>(serviceUrl + "/KTPay/SaleReversal", saleReversalRequest);
            return response;
        }

        public async Task<KTPayResponseResult<GetTransactionResponse>> GetTransactionAsync(string serviceUrl, GetTransactionRequest getTransactionRequest) {
            
            var response = await _client.PostAsync<GetTransactionRequest, KTPayResponseResult<GetTransactionResponse>>(serviceUrl + "/KTPay/GetTransaction", getTransactionRequest);
            return response;
        }

        public async Task<KTPayResponseResult<GetTransactionsResponse>> GetTransactionsAsync(string serviceUrl, GetTransactionsRequest getTransactionsRequest) {
            
            var response = await _client.PostAsync<GetTransactionsRequest, KTPayResponseResult<GetTransactionsResponse>>(serviceUrl + "/KTPay/GetTransactions", getTransactionsRequest);
            return response;
        }
    }
}
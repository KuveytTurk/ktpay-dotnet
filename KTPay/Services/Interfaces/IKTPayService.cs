using System.Threading.Tasks;
using KTPay.Models.Request;
using KTPay.Models.Response;
using KTPay.Models.Response.Generic;

namespace KTPay.Services.Interfaces {
    
    public interface IKTPayService {
        
        Task<string> PaymentAsync(string serviceUrl, PaymentRequest paymentRequest);
        
        Task<KTPayResponseResult<ProvisionResponse>> ProvisionAsync(string serviceUrl, ProvisionRequest provisionRequest);
        
        Task<KTPayResponseResult<SaleReversalResponse>> SaleReversalAsync(string serviceUrl, SaleReversalRequest saleReversalRequest);
        
        Task<KTPayResponseResult<GetTransactionResponse>> GetTransactionAsync(string serviceUrl, GetTransactionRequest getTransactionRequest);
        
        Task<KTPayResponseResult<GetTransactionsResponse>> GetTransactionsAsync(string serviceUrl, GetTransactionsRequest getTransactionsRequest);
    }
}
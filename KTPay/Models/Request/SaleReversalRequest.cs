using KTPay.Helpers;

namespace KTPay.Models.Request {
    
    public class SaleReversalRequest {
        
        public int Language { get; set; }
        
        public SaleReversalType SaleReversalType { get; set; }

        public int MerchantId { get; set; }

        public int CustomerId { get; set; }

        public string Username { get; set; }

        public string HashData { get; set; }
        
        public int OrderId { get; set; }
        
        public string MerchantOrderId { get; set; }
        
        public string Amount { get; set; }
        
        public void SetHashData(string password) {

            var hashPassword = KTPayHelper.HashPassword(password);
            Amount = SaleReversalType != SaleReversalType.PARTIAL_DRAWBACK || string.IsNullOrEmpty(Amount) ? "0" : Amount;
            var hashStr = MerchantId + MerchantOrderId + Amount + Username + hashPassword;
            HashData = KTPayHelper.ComputeHash(hashStr, hashPassword);
        }
    }
}
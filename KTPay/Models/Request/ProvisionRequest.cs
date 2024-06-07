using KTPay.Helpers;

namespace KTPay.Models.Request {
    
    public class ProvisionRequest {
        
        public int Language { get; set; }

        public int MerchantId { get; set; }

        public int CustomerId { get; set; }

        public string Username { get; set; }

        public string HashData { get; set; }
    
        public int OrderId { get; set; }

        public string MerchantOrderId { get; set; }

        public string Amount { get; set; }

        public string Md { get; set; }
        
        public void SetHashData(string password) {

            var hashPassword = KTPayHelper.HashPassword(password);
            var hashStr = MerchantId + MerchantOrderId + Amount + Username + hashPassword;
            HashData = KTPayHelper.ComputeHash(hashStr, hashPassword);
        }
    }
}
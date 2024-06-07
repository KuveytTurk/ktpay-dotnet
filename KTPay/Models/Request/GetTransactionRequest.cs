using KTPay.Helpers;

namespace KTPay.Models.Request {
    
    public class GetTransactionRequest {
        
        public int Language { get; set; }

        public int MerchantId { get; set; }

        public int CustomerId { get; set; }

        public string Username { get; set; }

        public string HashData { get; set; }

        public int OrderId { get; set; }
        
        public void SetHashData(string password) {

            var hashPassword = KTPayHelper.HashPassword(password);
            var hashStr = MerchantId + Username + hashPassword;
            HashData = KTPayHelper.ComputeHash(hashStr, hashPassword);
        }
    }
}
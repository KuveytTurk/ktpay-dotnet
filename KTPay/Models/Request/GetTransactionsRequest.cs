using System;
using KTPay.Helpers;

namespace KTPay.Models.Request {
    
    public class GetTransactionsRequest {
        
        public int Language { get; set; }

        public int MerchantId { get; set; }

        public int CustomerId { get; set; }

        public string Username { get; set; }

        public string HashData { get; set; }

        public int? OrderId { get; set; }

        public string MerchantOrderId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? OrderStatus { get; set; }
        
        public int? BatchId { get; set; }
        
        public void SetHashData(string password) {

            var hashPassword = KTPayHelper.HashPassword(password);
            var hashStr = MerchantId + MerchantOrderId + Username + hashPassword;
            HashData = KTPayHelper.ComputeHash(hashStr, hashPassword);
        }
    }
}
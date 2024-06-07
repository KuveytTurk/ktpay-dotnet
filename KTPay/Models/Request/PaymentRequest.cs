using System.Collections.Generic;
using KTPay.Helpers;

namespace KTPay.Models.Request {
    
    public class PaymentRequest {
    
        public int PaymentType { get; set; }
        
        public int Language { get; set; }

        public string MerchantOrderId { get; set; }

        public string SuccessUrl { get; set; }

        public string FailUrl { get; set; }

        public int MerchantId { get; set; }

        public int CustomerId { get; set; }

        public string Username { get; set; }

        public string HashData { get; set; }

        public string Amount { get; set; }

        public string Currency { get; set; }

        public int InstallmentCount { get; set; }

        public Customer Customer { get; set; }

        public Card Card { get; set; }

        public InvoiceAddress InvoiceAddress { get; set; }

        public ShippingAddress ShippingAddress { get; set; }

        public List<CartItem> Cart { get; set; }

        public void SetHashData(string password) {

            var hashPassword = KTPayHelper.HashPassword(password);
            var hashStr = MerchantId + MerchantOrderId + Amount + SuccessUrl + FailUrl + Username + hashPassword;
            HashData = KTPayHelper.ComputeHash(hashStr, hashPassword);
        }
    }
}
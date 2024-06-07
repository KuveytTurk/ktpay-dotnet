namespace KTPay.Models.Response {
    
    public class PaymentResponse {
        
        public int OrderId { get; set; }

        public string MD { get; set; }

        public string MerchantOrderId { get; set; }
    }
}
namespace KTPay.Models.Response.Generic {

    public class KTPayResponse {
        
        public bool Success { get; set; }

        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public string BusinessKey { get; set; }

        public long TransactionTime { get; set; }
        
    }
}
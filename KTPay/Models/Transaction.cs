using System;

namespace KTPay.Models {
    
    public class Transaction {
        
        public string OrderStatus { get; set; }

        public DateTime? TransactionTime { get; set; }

        public long? BatchId { get; set; }

        public string ProvisionNumber { get; set; }

        public string RRN { get; set; }

        public string Stan { get; set; }

        public string TransactionStatus { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace KTPay.Models.Response {
    
    public class GetTransactionResponse {
        
        public int? MerchantId { get; set; }

        public string PosTerminalId { get; set; }

        public int? OrderId { get; set; }

        public string MerchantOrderId { get; set; }

        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }

        public string CardType { get; set; }

        public DateTime? TransactionTime { get; set; }

        public int? IsCancellable { get; set; }

        public int? IsRefundable { get; set; }

        public int? IsPartialRefundable { get; set; }

        public string OrderStatus { get; set; }

        public string LastOrderStatus { get; set; }

        public string OrderType { get; set; }

        public string TransactionStatus { get; set; }

        public decimal? FirstAmount { get; set; }

        public decimal? DrawbackAmount { get; set; }

        public decimal? CancelAmount { get; set; }

        public decimal? ClosedAmount { get; set; }

        public string FEC { get; set; }

        public int? InstallmentCount { get; set; }

        public string TransactionSecurity { get; set; }

        public string ResponseCode { get; set; }

        public string ResponseExplain { get; set; }

        public long? BatchId { get; set; }

        public string EndOfDayStatus { get; set; }

        public DateTime? EndOfDayTime { get; set; }

        public string ProvisionNumber { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
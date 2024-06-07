using System.Collections.Generic;

namespace KTPay.Models.Response {
    
    public class GetTransactionsResponse {
        
        public List<Transactions> Transactions { get; set; }
    }
}
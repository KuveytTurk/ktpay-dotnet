using System.Collections.Generic;

namespace KTPay.Models.Response.Generic {

    public class KTPayResponseResults<T> : KTPayResponse where T : class, new() {
        
        public List<T> Results { get; set; }
    }
}
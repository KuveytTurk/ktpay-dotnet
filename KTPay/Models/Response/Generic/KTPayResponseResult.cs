namespace KTPay.Models.Response.Generic {

    public class KTPayResponseResult<T> : KTPayResponse where T : class, new() {
        
        public T Result { get; set; }
    }
}
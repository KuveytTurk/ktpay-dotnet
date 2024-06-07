namespace KTPay.Models {
    
    public sealed class Currency {
    
        private readonly string _value;

        public static readonly Currency TRY = new Currency("0949");
        public static readonly Currency EUR = new Currency("0978");
        public static readonly Currency USD = new Currency("0840");

        private Currency(string value) {
        
            _value = value;
        }
    
        public override string ToString() {
        
            return _value;
        }
    }
}
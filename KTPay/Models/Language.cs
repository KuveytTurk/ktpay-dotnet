namespace KTPay.Models {
    
    public sealed class Language {
    
        private readonly int _value;

        public static readonly Language TR = new Language(1);
        public static readonly Language EN = new Language(2);
        // public static readonly Language DE = new Language(3);
        // public static readonly Language RU = new Language(4);
        // public static readonly Language AR = new Language(5);

        private Language(int value) {
        
            _value = value;
        }

        public int GetValue() {
        
            return _value;
        }
    }
}
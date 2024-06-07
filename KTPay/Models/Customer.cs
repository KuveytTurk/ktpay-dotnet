namespace KTPay.Models {
    
    public class Customer {

        public string FullName { get; set; }
    
        public Phone PhoneNumber { get; set; }
    
        public string Email { get; set; }
    
        public string IdentityNumber { get; set; } // TCKN, VATNumber
    
        public string IpAddress { get; set; }
    }

    public class Phone {

        public string Cc { get; set; }
    
        public string Subscriber { get; set; }
    }
}
namespace KTPay.Models {
    
    public sealed class State {
    
        // City ISO 3166-1 Alpha-2 Codes
        // Ref: https://www.iso.org/obp/ui/#iso:code:3166:TR
        
        private readonly string _value;

        public static readonly State Adana               = new State("01");
        public static readonly State Adiyaman            = new State("02");
        public static readonly State Afyonkarahisar      = new State("03");
        public static readonly State Agri                = new State("04");
        public static readonly State Aksaray             = new State("68");
        public static readonly State Amasya              = new State("05");
        public static readonly State Ankara              = new State("06");
        public static readonly State Antalya             = new State("07");
        public static readonly State Ardahan             = new State("75");
        public static readonly State Artvin              = new State("08");
        public static readonly State Aydin               = new State("09");
        public static readonly State Balikesir           = new State("10");
        public static readonly State Bartin              = new State("74");
        public static readonly State Batman              = new State("72");
        public static readonly State Bayburt             = new State("69");
        public static readonly State Bilecik             = new State("11");
        public static readonly State Bingol              = new State("12");
        public static readonly State Bitlis              = new State("13");
        public static readonly State Bolu                = new State("14");
        public static readonly State Burdur              = new State("15");
        public static readonly State Bursa               = new State("16");
        public static readonly State Canakkale           = new State("17");
        public static readonly State Cankiri             = new State("18");
        public static readonly State Corum               = new State("19");
        public static readonly State Denizli             = new State("20");
        public static readonly State Diyarbakir          = new State("21");
        public static readonly State Duzce               = new State("81");
        public static readonly State Edirne              = new State("22");
        public static readonly State Elazig              = new State("23");
        public static readonly State Erzincan            = new State("24");
        public static readonly State Erzurum             = new State("25");
        public static readonly State Eskisehir           = new State("26");
        public static readonly State Gaziantep           = new State("27");
        public static readonly State Giresun             = new State("28");
        public static readonly State Gumushane           = new State("29");
        public static readonly State Hakkari             = new State("30");
        public static readonly State Hatay               = new State("31");
        public static readonly State Igdir               = new State("76");
        public static readonly State Isparta             = new State("32");
        public static readonly State Istanbul            = new State("34");
        public static readonly State Izmir               = new State("35");
        public static readonly State Kahramanmaras       = new State("46");
        public static readonly State Karabuk             = new State("78");
        public static readonly State Karaman             = new State("70");
        public static readonly State Kars                = new State("36");
        public static readonly State Kastamonu           = new State("37");
        public static readonly State Kayseri             = new State("38");
        public static readonly State Kirikkale           = new State("71");
        public static readonly State Kirklareli          = new State("39");
        public static readonly State Kirsehir            = new State("40");
        public static readonly State Kilis               = new State("79");
        public static readonly State Kocaeli             = new State("41");
        public static readonly State Konya               = new State("42");
        public static readonly State Kutahya             = new State("43");
        public static readonly State Malatya             = new State("44");
        public static readonly State Manisa              = new State("45");
        public static readonly State Mardin              = new State("47");
        public static readonly State Mersin              = new State("33");
        public static readonly State Mugla               = new State("48");
        public static readonly State Mus                 = new State("49");
        public static readonly State Nevsehir            = new State("50");
        public static readonly State Nigde               = new State("51");
        public static readonly State Ordu                = new State("52");
        public static readonly State Osmaniye            = new State("80");
        public static readonly State Rize                = new State("53");
        public static readonly State Sakarya             = new State("54");
        public static readonly State Samsun              = new State("55");
        public static readonly State Siirt               = new State("56");
        public static readonly State Sinop               = new State("57");
        public static readonly State Sivas               = new State("58");
        public static readonly State Sanliurfa           = new State("63");
        public static readonly State Sirnak              = new State("73");
        public static readonly State Tekirdag            = new State("59");
        public static readonly State Tokat               = new State("60");
        public static readonly State Trabzon             = new State("61");
        public static readonly State Tunceli             = new State("62");
        public static readonly State Usak                = new State("64");
        public static readonly State Van                 = new State("65");
        public static readonly State Yalova              = new State("77");
        public static readonly State Yozgat              = new State("66");
        public static readonly State Zonguldak           = new State("67");

        private State(string value) {
            
            _value = value;
        }

        public override string ToString() {
            
            return _value;
        }
    }
}
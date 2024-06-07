namespace KTPay.Models {
    
    public class CartItem {
    
        public string CartItemName { get; set; }
    
        public string CartItemUrl { get; set; }
    
        public int CartItemType { get; set; }
    
        public double Quantity { get; set; }
    
        public string Price { get; set; }
    
        public string TotalAmount { get; set; }
    }
}
namespace KTPay.Web.Helpers;

public class KTPayConfig {
    
    public const string TEST  = "Test";
    public const string PROD  = "Prod";
    
    public string ServiceUrl { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public string MerchantId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
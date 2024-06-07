namespace KTPay.Web.Helpers;

public class CardConfig {
    
    public const string VPOSTest  = "VPOSTest";
    public const string VPOSTest_Installment  = "VPOSTest_Installment";
    
    public string CardHolderName { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public string ExpireMonth { get; set; } = string.Empty;
    public string ExpireYear { get; set; } = string.Empty;
    public string SecurityCode { get; set; } = string.Empty;
    public string ACSPass { get; set; } = string.Empty;
}
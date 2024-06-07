using Microsoft.AspNetCore.Mvc;
using KTPay.Models;
using KTPay.Models.Request;
using KTPay.Models.Response;
using KTPay.Models.Response.Generic;
using KTPay.Services.Interfaces;
using KTPay.Web.Helpers;
using KTPay.Web.Models;

namespace KTPay.Web.Controllers {
    
    public class KTPayController : Controller {
        
        private readonly ILogger<KTPayController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IKTPayService _ktPayService;

        public KTPayController(ILogger<KTPayController> logger, IConfiguration configuration, IKTPayService ktPayService) {
            _logger = logger;
            _configuration = configuration;
            _ktPayService = ktPayService;
        }

        [HttpGet]
        public IActionResult Index() {
            
            return View();
        }

        /// <summary>
        /// 3D Payment
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Payment() {
            
            var envConfig = _configuration.GetSection("KTPayConfig:"+KTPayConfig.TEST).Get<KTPayConfig>() ?? new KTPayConfig();
            var cardConfig = _configuration.GetSection("CardConfig:"+CardConfig.VPOSTest).Get<CardConfig>() ?? new CardConfig();

            var request = new PaymentRequest() {
                PaymentType = 1,
                Language = Language.TR.GetValue(),
                MerchantOrderId = "KTPay-DotNet-" + new Random().NextInt64(),
                SuccessUrl = "http://localhost:3000/KTPay/Success",
                FailUrl = "http://localhost:3000/KTPay/Fail",
                MerchantId = Convert.ToInt32(envConfig.MerchantId),
                CustomerId = Convert.ToInt32(envConfig.CustomerId),
                Username = envConfig.Username,
                Amount = "100",
                Currency = Currency.TRY.ToString(),
                InstallmentCount = 1,
                Customer = new Customer() {
                    FullName = "JOHN DOE",
                    IdentityNumber = "12345678901",
                    Email = "noreply@kuveytturk.com.tr",
                    PhoneNumber = new Phone() {
                        Cc = "90",
                        Subscriber = "5001112233"
                    },
                    IpAddress = "127.0.0.1"
                },
                Card = new Card() {
                    CardHolderName = cardConfig.CardHolderName,
                    CardNumber = cardConfig.CardNumber,
                    ExpireMonth = cardConfig.ExpireMonth,
                    ExpireYear = cardConfig.ExpireYear,
                    SecurityCode = cardConfig.SecurityCode 
                },
                Cart = new List<CartItem>() {
                    new CartItem() {
                        CartItemName = "Product PHYSICAL",
                        CartItemUrl = "https://www.kuveytturk.com.tr",
                        CartItemType = (int)CartItemType.PHYSICAL,
                        Quantity = 1.5,
                        Price = "10",
                        TotalAmount = "15"
                    },
                    new CartItem() {
                        CartItemName = "Product VIRTUAL",
                        CartItemUrl = "https://www.kuveytturk.com.tr",
                        CartItemType = (int)CartItemType.VIRTUAL,
                        Quantity = 1,
                        Price = "85",
                        TotalAmount = "85"
                    }
                },
                InvoiceAddress = new InvoiceAddress() {
                    Company = "XXX LTD.STI.",
                    TaxNumber = "111111111",
                    TaxOffice = "XXXXXXXXX",
                    Address = "ADDRESS",
                    City = "IZMIT",
                    State = State.Kocaeli.ToString(),
                    Country = Country.Turkiye.ToString(),
                    ZipCode = "123456"
                },
                ShippingAddress = new ShippingAddress() {
                    FullName = "JOHN DOE",
                    Address = "ADDRESS",
                    City = "IZMIT",
                    State = State.Kocaeli.ToString(),
                    Country = Country.Turkiye.ToString(),
                    ZipCode = "123456"
                }
            };
            request.SetHashData(envConfig.Password);

            var serviceUrl = envConfig.ServiceUrl;
            var response = await _ktPayService.PaymentAsync(serviceUrl, request);
            if (response == null) {
                
                return Json(new { Error = "PaymentAsyncError", ErrorMessage = "İşleminiz gerçekleştirilemedi."});
            }
            
            return Content(response, "text/html");
        }
        
        /// <summary>
        /// 3D Payment - Installment
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> InstallmentPayment() {
            
            var envConfig = _configuration.GetSection("KTPayConfig:"+KTPayConfig.TEST).Get<KTPayConfig>() ?? new KTPayConfig();
            var cardConfig = _configuration.GetSection("CardConfig:"+CardConfig.VPOSTest_Installment).Get<CardConfig>() ?? new CardConfig();

            var request = new PaymentRequest() {
                PaymentType = 1,
                Language = Language.TR.GetValue(),
                MerchantOrderId = "KTPay-DotNet-" + new Random().NextInt64(),
                SuccessUrl = "http://localhost:3000/KTPay/Success",
                FailUrl = "http://localhost:3000/KTPay/Fail",
                MerchantId = Convert.ToInt32(envConfig.MerchantId),
                CustomerId = Convert.ToInt32(envConfig.CustomerId),
                Username = envConfig.Username,
                Amount = "100",
                Currency = Currency.TRY.ToString(),
                InstallmentCount = 2,
                Customer = new Customer() {
                    FullName = "JOHN DOE",
                    IdentityNumber = "12345678901",
                    Email = "noreply@kuveytturk.com.tr",
                    PhoneNumber = new Phone() {
                        Cc = "90",
                        Subscriber = "5001112233"
                    },
                    IpAddress = "127.0.0.1"
                },
                Card = new Card() {
                    CardHolderName = cardConfig.CardHolderName,
                    CardNumber = cardConfig.CardNumber,
                    ExpireMonth = cardConfig.ExpireMonth,
                    ExpireYear = cardConfig.ExpireYear,
                    SecurityCode = cardConfig.SecurityCode 
                },
                Cart = new List<CartItem>() {
                    new CartItem() {
                        CartItemName = "Product PHYSICAL",
                        CartItemUrl = "https://www.kuveytturk.com.tr",
                        CartItemType = (int)CartItemType.PHYSICAL,
                        Quantity = 1.5,
                        Price = "10",
                        TotalAmount = "15"
                    },
                    new CartItem() {
                        CartItemName = "Product VIRTUAL",
                        CartItemUrl = "https://www.kuveytturk.com.tr",
                        CartItemType = (int)CartItemType.VIRTUAL,
                        Quantity = 1,
                        Price = "85",
                        TotalAmount = "85"
                    }
                },
                InvoiceAddress = new InvoiceAddress() {
                    Company = "XXX LTD.STI.",
                    TaxNumber = "111111111",
                    TaxOffice = "XXXXXXXXX",
                    Address = "ADDRESS",
                    City = "IZMIT",
                    State = State.Kocaeli.ToString(),
                    Country = Country.Turkiye.ToString(),
                    ZipCode = "123456"
                },
                ShippingAddress = new ShippingAddress() {
                    FullName = "JOHN DOE",
                    Address = "ADDRESS",
                    City = "IZMIT",
                    State = State.Kocaeli.ToString(),
                    Country = Country.Turkiye.ToString(),
                    ZipCode = "123456"
                }
            };
            request.SetHashData(envConfig.Password);

            var serviceUrl = envConfig.ServiceUrl;
            var response = await _ktPayService.PaymentAsync(serviceUrl, request);
            if (response == null) {
                
                return Json(new { Error = "InstallmentPaymentAsyncError", ErrorMessage = "İşleminiz gerçekleştirilemedi."});
            }
            
            return Content(response, "text/html");
        }
        
        /// <summary>
        /// 3D Payment - Callback Url(Success)
        /// </summary>
        /// <param name="paymentResponse"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Success([FromForm]KTPayResponseResult<PaymentResponse> paymentResponse) {
            
            var envConfig = _configuration.GetSection("KTPayConfig:"+KTPayConfig.TEST).Get<KTPayConfig>() ?? new KTPayConfig();
            
            if (paymentResponse.Success && paymentResponse.ResponseCode == "00") {
    
                var request = new ProvisionRequest() {
                    Language = Language.TR.GetValue(),
                    MerchantId = Convert.ToInt32(envConfig.MerchantId),
                    CustomerId = Convert.ToInt32(envConfig.CustomerId),
                    Username = envConfig.Username,
                    OrderId = paymentResponse.Result.OrderId,
                    MerchantOrderId = paymentResponse.Result.MerchantOrderId,
                    Amount = "100",
                    Md = paymentResponse.Result.MD
                };
                request.SetHashData(envConfig.Password);
                
                var serviceUrl = envConfig.ServiceUrl;
                var provisionResponse = await _ktPayService.ProvisionAsync(serviceUrl, request);
                if (provisionResponse == null) {
                    return Json(new { Error = "ProvisionAsyncError", ErrorMessage = "İşleminiz gerçekleştirilemedi."});
                }

                if (provisionResponse.Success && provisionResponse.ResponseCode == "00") {
                    
                    return Json(provisionResponse);
                }
    
                return Json(provisionResponse);
            }

            return Json(paymentResponse);
        }
        
        /// <summary>
        /// 3D Payment - Callback Url(Fail)
        /// </summary>
        /// <param name="errorVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Fail([FromForm]ErrorVM errorVM) {
            
            return Json(errorVM);
        }
        
        /// <summary>
        /// 3D Payment - Provision
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Provision() {
            
            var envConfig = _configuration.GetSection("KTPayConfig:"+KTPayConfig.TEST).Get<KTPayConfig>() ?? new KTPayConfig();
            
            var request = new ProvisionRequest() {
                Language = Language.TR.GetValue(),
                MerchantId = Convert.ToInt32(envConfig.MerchantId),
                CustomerId = Convert.ToInt32(envConfig.CustomerId),
                Username = envConfig.Username,
                OrderId = 203418364,
                MerchantOrderId = "KTPay-DotNet-2771838446527563693",
                Amount = "100",
                Md = "V41ORA43CP2rFY+rO+zXe39dCnsSAAOEkLlBOheeO+43M45+U1oWc6p9f0EBMbeu"
            };
            request.SetHashData(envConfig.Password);
            var serviceUrl = envConfig.ServiceUrl;
            
            var provisionAsync = await _ktPayService.ProvisionAsync(serviceUrl, request);
            if (provisionAsync == null) {
                return Json(new { Error = "SaleReversalAsyncError", ErrorMessage = "İşleminiz gerçekleştirilemedi."});
            }

            if (provisionAsync.Success && provisionAsync.ResponseCode == "00") {
                    
                return Json(provisionAsync);
            }
    
            return Json(new { Error = provisionAsync.ResponseCode, ErrorMessage = provisionAsync.ResponseMessage, BK = provisionAsync.BusinessKey});
        }

        /// <summary>
        /// SaleReversal - Cancel, Drawback, Partial Drawback
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SaleReversal() {
            
            var envConfig = _configuration.GetSection("KTPayConfig:"+KTPayConfig.TEST).Get<KTPayConfig>() ?? new KTPayConfig();
            
            SaleReversalRequest request = new SaleReversalRequest() {
                Language = Language.TR.GetValue(),
                SaleReversalType = SaleReversalType.CANCEL, //SaleReversalType.DRAWBACK, SaleReversalType.PARTIAL_DRAWBACK
                MerchantId = Convert.ToInt32(envConfig.MerchantId),
                CustomerId = Convert.ToInt32(envConfig.CustomerId),
                Username = envConfig.Username,
                OrderId = 203418364,
                MerchantOrderId = "KTPay-DotNet-2771838446527563693",
                Amount = "100"
            };
            request.SetHashData(envConfig.Password);
            
            var serviceUrl = envConfig.ServiceUrl;
            var saleReversalAsync = await _ktPayService.SaleReversalAsync(serviceUrl, request);
            if (saleReversalAsync == null) {
                return Json(new { Error = "SaleReversalAsyncError", ErrorMessage = "İşleminiz gerçekleştirilemedi."});
            }

            if (saleReversalAsync.Success && saleReversalAsync.ResponseCode == "00") {
                    
                return Json(saleReversalAsync);
            }
    
            return Json(new { Error = saleReversalAsync.ResponseCode, ErrorMessage = saleReversalAsync.ResponseMessage, BusinessKey = saleReversalAsync.BusinessKey});
        }
        
        /// <summary>
        /// GetTransaction
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTransaction() {
            
            var envConfig = _configuration.GetSection("KTPayConfig:"+KTPayConfig.TEST).Get<KTPayConfig>() ?? new KTPayConfig();
            
            GetTransactionRequest request = new GetTransactionRequest() {
                Language = Language.TR.GetValue(),
                MerchantId = Convert.ToInt32(envConfig.MerchantId),
                CustomerId = Convert.ToInt32(envConfig.CustomerId),
                Username = envConfig.Username,
                OrderId = 203418364
            };
            request.SetHashData(envConfig.Password);
            var serviceUrl = envConfig.ServiceUrl;
            
            var getTransactionAsync = await _ktPayService.GetTransactionAsync(serviceUrl, request);
            if (getTransactionAsync == null) {
                return Json(new { Error = "getTransactionAsyncError", ErrorMessage = "İşleminiz gerçekleştirilemedi."});
            }

            if (getTransactionAsync.Success) {
                    
                return Json(getTransactionAsync);
            }
    
            return Json(new { Error = getTransactionAsync.ResponseCode, ErrorMessage = getTransactionAsync.ResponseMessage, BusinessKey = getTransactionAsync.BusinessKey});
        }
        
        /// <summary>
        /// GetTransactions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTransactions() {
            
            var envConfig = _configuration.GetSection("KTPayConfig:"+KTPayConfig.TEST).Get<KTPayConfig>() ?? new KTPayConfig();

            GetTransactionsRequest request = new GetTransactionsRequest() {
                Language = Language.TR.GetValue(),
                MerchantId = Convert.ToInt32(envConfig.MerchantId),
                CustomerId = Convert.ToInt32(envConfig.CustomerId),
                Username = envConfig.Username,
                OrderId = 203418364, // Opsiyonel filtre
                MerchantOrderId = "KTPay-DotNet-2771838446527563693", // Opsiyonel filtre
                OrderStatus = 6, // Opsiyonel filtre
                BatchId = 548, // Opsiyonel filtre
                StartDate = new DateTime(DateTime.Now.Year, 1, 1), // Opsiyonel filtre
                EndDate = new DateTime(DateTime.Now.Year, 12, 31) // Opsiyonel filtre
            };
            request.SetHashData(envConfig.Password);
            var serviceUrl = envConfig.ServiceUrl;
            
            var getTransactionsAsync = await _ktPayService.GetTransactionsAsync(serviceUrl, request);
            if (getTransactionsAsync == null) {
                return Json(new { Error = "getTransactionAsyncError", ErrorMessage = "İşleminiz gerçekleştirilemedi."});
            }

            if (getTransactionsAsync.Success) {
                    
                return Json(getTransactionsAsync);
            }
    
            return Json(new { Error = getTransactionsAsync.ResponseCode, ErrorMessage = getTransactionsAsync.ResponseMessage, BusinessKey = getTransactionsAsync.BusinessKey});
        }
    }
}
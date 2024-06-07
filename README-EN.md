# ktpay-dotnet

[![.NET Standard Version](https://img.shields.io/badge/.NET%20Standard-2.0-8892BF.svg?style=flat-square)](https://learn.microsoft.com/en-us/dotnet/standard/net-standard/)
[![Minimum .NET Version](https://img.shields.io/badge/.NET-%3E%3D%202.0-8892BF.svg?style=flat-square)](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core/)
[![GitHub Release](https://img.shields.io/github/v/release/kuveytturk/ktpay-dotnet?style=flat-square&color=ff4f00)](https://github.com/kuveytturk/ktpay-dotnet/releases)
[![GitHub License](https://img.shields.io/github/license/kuveytturk/ktpay-dotnet?style=flat-square)](https://github.com/kuveytturk/ktpay-dotnet/blob/main/LICENSE)

This project contains integration infrastructure code developed for Kuveyt Turk Participation Bank Virtual POS services. The codes included in the project must be used to integrate and perform virtual POS transactions for online payment services provided by Kuveyt Turk Participation Bank. Any unauthorized use for different purposes will be detected by the bank, and punitive measures will be applied.

If you any errors, you can contact the [Kuveyt Turk Virtual POS Support](mailto:sanalposdestek@kuveytturk.com.tr) team.

[Türkçe](https://github.com/kuveytturk/ktpay-dotnet/blob/main/README.md)

## Requirements

* **.NET Standart 2.0**
* **.NET Core 8** (for Tests and Web)

## .NET Compatibility

| .NET implementation          | Version support                       	   |
|------------------------------|---------------------------------------------|
| .NET ve .NET Core            | 2.0, 2.1, 2.2, 3.0, 3.1, 5.0, 6.0, 7.0, 8.0 |
| .NET Framework               | 4.6.1, 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1 |
| Mono                         | 5.4, 6.4                              	   |
| Xamarin.iOS                  | 10.14, 12.16                          	   |
| Xamarin.Mac                  | 3.8, 5.16                             	   |
| Xamarin.Android              | 8.0, 10.0                             	   |
| Evrensel Windows Platform    | 10.0.16299, TBD                       	   |
| Unity                        | 2018.1                                	   |

## Installation

 ```bash
# Clone the project files to your local computer.
git clone https://github.com/kuveytturk/ktpay-dotnet.git

# Configure your integration credentials.
nano .\KTPay.Web\appsettings.json

# Navigate to the project directory and start up the project.
cd .\ktpay-dotnet\KTPay.Web\
dotnet watch run
```

## Example Code

### Payment

> Request

```csharp
var request = new PaymentRequest() {
    PaymentType = 1,
    Language = Language.EN.GetValue(),
    MerchantOrderId = "KT TEST",
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
```

> Response

```json
{
  "result": {
    "orderId": 203418364,
    "md": "V41ORA43CP2rFY+rO+zXe39dCnsSAAOEkLlBOheeO+43M45+U1oWc6p9f0EBMbeu",
    "merchantOrderId": "KTPay-DotNet-2771838446527563693"
  },
  "success": true,
  "responseCode": "00",
  "responseMessage": "Kart doğrulandı.",
  "businessKey": 202406079999000000041584825,
  "transactionTime": 1717778734
}
```

### Payment with Installment

> Request

```csharp
var request = new PaymentRequest() {
    PaymentType = 1,
    Language = Language.EN.GetValue(),
    MerchantOrderId = "KT TEST",
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
```

> Response

```json
{
  "result": {
    "orderId": 203418364,
    "md": "V41ORA43CP2rFY+rO+zXe39dCnsSAAOEkLlBOheeO+43M45+U1oWc6p9f0EBMbeu",
    "merchantOrderId": "KTPay-DotNet-2771838446527563693"
  },
  "success": true,
  "responseCode": "00",
  "responseMessage": "Kart doğrulandı.",
  "businessKey": 202406079999000000041584825,
  "transactionTime": 1717778734
}
```

### Payment and Payment with Installment - Provision

> Request

```csharp
var request = new ProvisionRequest() {
    Language = Language.EN.GetValue(),
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    OrderId = 203418364,
    MerchantOrderId = "KTPay-DotNet-2771838446527563693",
    Amount = "100",
    Md = "V41ORA43CP2rFY+rO+zXe39dCnsSAAOEkLlBOheeO+43M45+U1oWc6p9f0EBMbeu"
};
request.SetHashData(envConfig.Password);
```

> Response

```json
{
  "result": {
    "orderId": 203418364,
    "merchantOrderId": "KTPay-DotNet-2771838446527563693"
  },
  "success": true,
  "responseCode": "00",
  "responseMessage": "OTORİZASYON VERİLDİ",
  "businessKey": 202406079999000000041601797,
  "transactionTime": 1717778857
}
```

### Cancel, Drawback and Partial Drawback

> Request

```csharp
var request = new SaleReversalRequest() {
    Language = Language.EN.GetValue(),
    SaleReversalType = SaleReversalType.CANCEL, //SaleReversalType.DRAWBACK, SaleReversalType.PARTIAL_DRAWBACK
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    OrderId = 203418364,
    MerchantOrderId = "KTPay-DotNet-2771838446527563693",
    Amount = "100"
};
request.SetHashData(envConfig.Password);
```

> Response

```json
{
  "result": {
    "orderId": 203418364,
    "merchantOrderId": "KTPay-DotNet-2771838446527563693"
  },
  "success": true,
  "responseCode": "00",
  "responseMessage": "OTORİZASYON VERİLDİ",
  "businessKey": 202406079999000000041752195,
  "transactionTime": 1717779742
}
```

### Find Transaction

> Request

```csharp
var request = new GetTransactionRequest() {
    Language = Language.EN.GetValue(),
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    OrderId = 203418364
};
request.SetHashData(envConfig.Password);
```

> Response

```json
{
  "result": {
    "merchantId": 496,
    "posTerminalId": "VP008759",
    "orderId": 203418364,
    "merchantOrderId": "KTPay-DotNet-2771838446527563693",
    "cardHolderName": "JOHN DOE",
    "cardNumber": "51889619****2544",
    "cardType": "MasterCard",
    "transactionTime": "2024-06-07T16:45:26.313",
    "isCancellable": 0,
    "isRefundable": 0,
    "isPartialRefundable": 0,
    "orderStatus": "Satış (1)",
    "lastOrderStatus": "İptal (6)",
    "orderType": "Peşin (1)",
    "transactionStatus": "Basarılı (1)",
    "firstAmount": 1,
    "drawbackAmount": 0,
    "cancelAmount": 1,
    "closedAmount": 0,
    "fec": "TRY (0949)",
    "installmentCount": 0,
    "transactionSecurity": "3d İşlem (3)",
    "responseCode": "00",
    "responseExplain": "İşlem gerçekleştirildi.",
    "batchId": 548,
    "endOfDayStatus": "Açık (1)",
    "endOfDayTime": null,
    "provisionNumber": "136525",
    "transactions": [
      {
        "orderStatus": "Satış (1)",
        "transactionTime": "2024-06-07T16:47:37.07",
        "batchId": 548,
        "provisionNumber": "136525",
        "rrn": "415916236400",
        "stan": "236400",
        "transactionStatus": "Basarılı (1)"
      },
      {
        "orderStatus": "İptal (6)",
        "transactionTime": "2024-06-07T17:02:19.923",
        "batchId": 548,
        "provisionNumber": "136525",
        "rrn": "415917236401",
        "stan": "236401",
        "transactionStatus": "Basarılı (1)"
      }
    ]
  },
  "success": true,
  "responseCode": "Successfull",
  "responseMessage": "Your transaction has been completed successfully.",
  "businessKey": 202406079999000000041789973,
  "transactionTime": 1717779814
}
```

### List Transactions

> Request

```csharp
var request = new GetTransactionsRequest() {
    Language = Language.EN.GetValue(),
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    OrderId = 203418364, // Optional filter
    MerchantOrderId = "KTPay-DotNet-2771838446527563693", // Optional filter
    OrderStatus = 6, // Optional filter
    BatchId = 548, // Optional filter
    StartDate = new DateTime(DateTime.Now.Year, 1, 1), // Optional filter
    EndDate = new DateTime(DateTime.Now.Year, 12, 31) // Optional filter
};
request.SetHashData(envConfig.Password);
```

> Response

```json
{
  "result": {
    "transactions": [
      {
        "merchantId": 496,
        "posTerminalId": "VP008759",
        "orderId": 203418364,
        "merchantOrderId": "KTPay-DotNet-2771838446527563693",
        "cardHolderName": "JOHN DOE",
        "cardNumber": "51889619****2544",
        "cardType": "MasterCard",
        "transactionTime": "2024-06-07T16:45:26.313",
        "isCancellable": 0,
        "isRefundable": 0,
        "isPartialRefundable": 0,
        "orderStatus": "Satış (1)",
        "lastOrderStatus": "İptal (6)",
        "orderType": "Peşin (1)",
        "transactionStatus": "Basarılı (1)",
        "firstAmount": 1,
        "drawbackAmount": 0,
        "cancelAmount": 1,
        "closedAmount": 0,
        "fec": "TRY (0949)",
        "installmentCount": 0,
        "transactionSecurity": "3d İşlem (3)",
        "responseCode": "00",
        "responseExplain": "İşlem gerçekleştirildi.",
        "batchId": 548,
        "endOfDayStatus": "Açık (1)",
        "endOfDayTime": null,
        "provisionNumber": "136525"
      }
    ]
  },
  "success": true,
  "responseCode": "Successfull",
  "responseMessage": "Your transaction has been completed successfully.",
  "businessKey": 202406079999000000041844672,
  "transactionTime": 1717779917
}
```

## License

This project is licensed under the MIT License. For details, please review the [LICENSE](https://github.com/kuveytturk/ktpay-dotnet/blob/main/LICENSE) file.
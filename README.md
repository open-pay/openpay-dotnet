Openpay.Net [![Build status](https://ci.appveyor.com/api/projects/status?id=1nqfx672p641x792)](https://ci.appveyor.com/project/open-pay-openpay-dotnet)
==============

Openpay .NET Client

This is a client implementing the payment services for Openpay at openpay.mx

Compatibility
-------------

.Net Framework 4.0 or later 

Requirements
------------
Newtonsoft.Json

Installation
----------------
Add a reference to Openpay.dll.

Implementation
--------------

#### Configuration #####

Before use the library will be necessary to set up your Merchant ID and
Private key. Use:

```net
OpenpayAPI openpayAPI = new OpenpayAPI(API_KEY, MERCHANT_ID);
```

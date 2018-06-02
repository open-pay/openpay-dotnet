![Openpay NET](http://www.openpay.mx/img/github/net.jpg)
[![Build status](https://ci.appveyor.com/api/projects/status/o8ivc5myofhx2kxm)](https://ci.appveyor.com/project/mecoronado/openpay-dotnet)

This is a client implementing the payment services for Openpay at openpay.mx


Compatibility
-------------

* .Net Framework 4.5 or later 

Dependencies
------------
* [Newtonsoft.Json](http://james.newtonking.com/json)

Quick Start
----------------
#### Installation #####

It is recommended that you use [NuGet](http://docs.nuget.org) for install this library. Or you can fork the code and build it.

#### Configuration #####

Before use the library will be necessary to set up your Merchant ID and
Private key. Use:

```net
OpenpayAPI openpayAPI = new OpenpayAPI(API_KEY, MERCHANT_ID);
```

#### Sandbox/Production Mode #####

By convenience and security, the sandbox mode is activated by default in the client library. This allows you to test your own code when implementing Openpay, before charging any credit card in production environment. Once you have finished your integration, create OpenpayAPI object like this:

```cs
Boolean production = true;
OpenpayAPI openpayAPI = new OpenpayAPI(API_KEY, MERCHANT_ID, production);
```
or use Production property:
```cs
OpenpayAPI openpayAPI = new OpenpayAPI(API_KEY, MERCHANT_ID);
openpayAPI.Production = true;
```

#### API Services #####

Once configured the library, you can use it to interact with Openpay API services. All the API services are properties of the OpenpayAPI class.

```cs
openpayAPI.CustomerService
openpayAPI.CardService
openpayAPI.BankAccountService
openpayAPI.ChargeService
openpayAPI.TransferService
openpayAPI.PayoutService
openpayAPI.FeeService
openpayAPI.PlanService
openpayAPI.SubscriptionService
```

Each service has methods to **create**, **get**, **update**, **delete** or **list** resources according to the documetation described on http://docs.openpay.mx

Examples
---------
#### Customers #####

**Create a customer**
```cs
Customer customer = new Customer();
customer.Name = "Net Client";
customer.LastName = "C#";
customer.Email = "net@c.com";
customer.Address = new Address();
customer.Address.Line1 = "line 1";
customer.Address.PostalCode = "12355";
customer.Address.City = "Queretaro";
customer.Address.CountryCode = "MX";
customer.Address.State = "Queretaro";

Customer customerCreated = openpayAPI.CustomerService.Create(customer);
```

**Get a customer**
```cs
string customer_id = "adyytoegxm6boiusecxm";
Customer customer = openpayAPI.CustomerService.Get(customer_id);
```   
**Delete a customer**
```cs
string customer_id = "adyytoegxm6boiusecxm";
openpayAPI.CustomerService.Delete(customer.Id);
``` 
**Update a customer**
```cs
string customer_id = "adyytoegxm6boiusecxm";
Customer customer = openpayAPI.CustomerService.Get(customer_id);
customer.Name = "My new name";

customer = openpayAPI.CustomerService.Update(customer);
```

**List customers**
```cs  
SearchParams search = new SearchParams();
search.Limit = 50;

List<Customer> customers = openpayAPI.CustomerService.List(search);
```

#### Charges #####
Create a charge
```cs
string customer_id = "adyytoegxm6boiusecxm";

ChargeRequest request = new ChargeRequest();
request.Method = "card";
request.SourceId = "kwkoqpg6fcvfse8k8mg2";
request.Description = "Testing from .Net";
request.Amount = new Decimal(9.99);

Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
```
Capture a charge
```cs
string customer_id = "adyytoegxm6boiusecxm";

ChargeRequest request = new ChargeRequest();
request.Method = "card";
request.SourceId = "kwkoqpg6fcvfse8k8mg2";
request.Description = "Testing from .Net";
request.Amount = new Decimal(9.99);
request.Capture = false; //false indicate that only we want capture the amount

Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
```
Refund a charge
```cs
string customer_id = "adyytoegxm6boiusecxm";
string charge_id = "ttcg5roe2py2bur38cx2";

Charge chargeRefunded = openpayAPI.ChargeService.Refund(customer_id, charge.Id, "refund desc");
```
Create a charge to be paid by bank transfer
```cs
string customer_id = "adyytoegxm6boiusecxm";

ChargeRequest request = new ChargeRequest();
request.Method = "bank_account";
request.Description = "Testing from .Net [BankAccount]";
request.Amount = new Decimal(9.99);

Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
```
#### Payouts #####

Currently payouts are only allowed to accounts in Mexico.

Payout to bank account
```cs
string customer_id = "adyytoegxm6boiusecxm";
BankAccount bankAccount = new BankAccount();
bankAccount.CLABE = "012298026516924616";
bankAccount.HolderName = "Testing";

PayoutRequest request = new PayoutRequest();
request.Method = "bank_account";
request.BankAccount = bankAccount;
request.Amount = 800.00m;
request.Description = "Payout test";

Payout payout = openpayAPI.PayoutService.Create(customer_id, request);
```
Payout to debit card
```cs
string customer_id = "adyytoegxm6boiusecxm";
Card card = new Card();
card.CardNumber = "4111111111111111";
card.BankCode = "002";
card.HolderName = "Payout User";

PayoutRequest request = new PayoutRequest();
request.Method = "card";
request.Card = card;
request.Amount = 500.00m;
request.Description = "Payout test";

Payout payout = openpayAPI.PayoutService.Create(customer_id, request);
```

#### Subscriptions #####

Create a plan first
```cs
Plan plan = new Plan();
plan.Name = "Tv";
plan.Amount = 99.99m;
plan.RepeatEvery = 1;
plan.RepeatUnit = "month";
plan.StatusAfterRetry = "unpaid";
plan.TrialDays = 0;

Plan planCreated = openpayAPI.PlanService.Create(plan);
```
After you have your plan created, you can subscribe customers to it
```cs
string customer_id = "adyytoegxm6boiusecxm";
Card card = new Card();
card.CardNumber = "5243385358972033";
card.HolderName = "John Doe";
card.Cvv2 = "123";
card.ExpirationMonth = "01";
card.ExpirationYear = "14";

Subscription subscription = new Subscription();
subscription.PlanId = planCreated.Id;
subscription.Card = card;
subscription = openpayAPI.SubscriptionService.Create(customer_id, subscription);
```
Cancel susbscription
```cs
string customer_id = "adyytoegxm6boiusecxm";
openpayAPI.SubscriptionService.Delete(customer_id, subscription.Id);
```

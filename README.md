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

```c#
Boolean production = true;
OpenpayAPI openpayAPI = new OpenpayAPI(API_KEY, MERCHANT_ID, production);
```
or use Production property:
```c#
OpenpayAPI openpayAPI = new OpenpayAPI(API_KEY, MERCHANT_ID);
openpayAPI.Production = true;
```

#### API Services #####

Once configured the library, you can use it to interact with Openpay API services. All the API services are properties of the OpenpayAPI class.

```c#
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

# Implementation
Usage for Mexico
---------
### Customers ####

**Create a customer**
```c#
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
```c#
string customer_id = "adyytoegxm6boiusecxm";
Customer customer = openpayAPI.CustomerService.Get(customer_id);
```   
**Delete a customer**
```c#
string customer_id = "adyytoegxm6boiusecxm";
openpayAPI.CustomerService.Delete(customer.Id);
``` 
**Update a customer**
```c#
string customer_id = "adyytoegxm6boiusecxm";
Customer customer = openpayAPI.CustomerService.Get(customer_id);
customer.Name = "My new name";

customer = openpayAPI.CustomerService.Update(customer);
```

**List customers**
```c#  
SearchParams search = new SearchParams();
search.Limit = 50;

List<Customer> customers = openpayAPI.CustomerService.List(search);
```

### Charges ####
**Create a charge**
```c#
string customer_id = "adyytoegxm6boiusecxm";

ChargeRequest request = new ChargeRequest();
request.Method = "card";
request.SourceId = "kwkoqpg6fcvfse8k8mg2";
request.Description = "Testing from .Net";
request.Amount = new Decimal(9.99);

Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
```
**Capture a charge**
```c#
string customer_id = "adyytoegxm6boiusecxm";

ChargeRequest request = new ChargeRequest();
request.Method = "card";
request.SourceId = "kwkoqpg6fcvfse8k8mg2";
request.Description = "Testing from .Net";
request.Amount = new Decimal(9.99);
request.Capture = false; //false indicate that only we want capture the amount

Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
```
**Refund a charge**
```c#
string customer_id = "adyytoegxm6boiusecxm";
string charge_id = "ttcg5roe2py2bur38cx2";

Charge chargeRefunded = openpayAPI.ChargeService.Refund(customer_id, charge.Id, "refund desc");
```
Or:
```c#
string customer_id = "adyytoegxm6boiusecxm";
string charge_id = "ttcg5roe2py2bur38cx2";
RefundRequest refundRequest = new RefundRequest();
refundRequest.Description = "refund desc";

Charge chargeRefunded = openpayAPI.ChargeService.RefundWithRequest(customer_id, charge.Id, refundRequest);
```
**Create a charge to be paid by bank transfer**
```c#
string customer_id = "adyytoegxm6boiusecxm";

ChargeRequest request = new ChargeRequest();
request.Method = "bank_account";
request.Description = "Testing from .Net [BankAccount]";
request.Amount = new Decimal(9.99);

Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
```
### Payouts ###

Currently payouts are only allowed to accounts in Mexico.

**Payout to bank account**
```c#
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
**Payout to debit card**
```c#
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

### Subscriptions ###

**Create a plan first**
```c#
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
```c#
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
**Cancel susbscription**
```c#
string customer_id = "adyytoegxm6boiusecxm";
openpayAPI.SubscriptionService.Delete(customer_id, subscription.Id);
```
## Usage for Peru
### Charges
####Create a charge
###### Without customer
```c#
ChargeRequest newCharge = new ChargeRequest();
newCharge.Method = "card";
newCharge.SourceId = "SourceId";
newCharge.Amount = 100;
newCharge.Currency = "PEN";
newCharge.Description = "Cargo de prueba";
newCharge.OrderId = "OrderId";
newCharge.DeviceSessionId = "DeviceSessionId";
Customer customer = new Customer();
customer.Name = "Cliente Perú";
customer.LastName = "Vazquez Juarez";
customer.PhoneNumber = "4448936475";
customer.Email = "juan.vazquez@empresa.pe";
newCharge.Customer = customer;

Charge charge = openpayAPI.ChargeService.Create(newCharge);
```
###### With customer
```c#
ChargeRequest newCharge = new ChargeRequest();
newCharge.Method = "card";
newCharge.SourceId = "sourceId";
newCharge.Amount = 100;
newCharge.Currency = "PEN";
newCharge.Description = "Cargo de prueba";
newCharge.OrderId = "OrderId";
newCharge.DeviceSessionId = "DeviceSessionId";

Charge charge = openpayAPI.ChargeService.Create("customerId", newCharge);
```
###### Store charge
```c#
ChargeRequest newCharge = new ChargeRequest();
newCharge.Method = "store";
newCharge.SourceId = null;
newCharge.Amount = 100;
newCharge.Currency = "PEN";
newCharge.Description = "Cargo de prueba";
newCharge.OrderId = "OrderId";
newCharge.DeviceSessionId = null;

Customer customer = new Customer();
customer.Name = "Cliente Perú";
customer.LastName = "Vazquez Juarez";
customer.PhoneNumber = "4448936475";
customer.Email = "juan.vazquez@empresa.pe";

newCharge.Customer = customer;
newCharge.Confirm = "false";
newCharge.RedirectUrl = "www.miempresa.pe";

Charge charge = openpayAPI.ChargeService.Create(newCharge);
```
###### Charge with redirection
```c#
ChargeRequest newCharge = new ChargeRequest();
newCharge.Method = "card";
newCharge.SourceId = null;
newCharge.Amount = 100;
newCharge.Currency = "PEN";
newCharge.Description = "Cargo de prueba";
newCharge.OrderId = "OrderId";
newCharge.DeviceSessionId = null;

Customer customer = new Customer();
customer.Name = "Cliente Perú";
customer.LastName = "Vazquez Juarez";
customer.PhoneNumber = "4448936475";
customer.Email = "juan.vazquez@empresa.pe";

newCharge.Customer = customer;
newCharge.Confirm = "false";
newCharge.RedirectUrl = "www.miempresa.pe";

Charge charge = openpayAPI.ChargeService.Create(newCharge);
```
#### Get a charge
```c#
Charge charge = openpayAPI.ChargeService.Get("ChargeId");
```
#### List charges
```c#
SearchParams searchParams = new SearchParams();
searchParams.Amount = 100;
searchParams.Status = TransactionStatus.FAILED;
List<Charge> charges = openpayAPI.ChargeService.List(searchParams);
```

### Checkouts
#### Create a checkout
###### Without customer
```c#
CheckoutRequest checkoutRequest = new CheckoutRequest();
checkoutRequest.Amount = 100;
checkoutRequest.Description = "Checkout de prueba";
checkoutRequest.OrderId = "OrderId";
checkoutRequest.Currency = "PEN";
checkoutRequest.RedirectUrl = "www.miempresa.com";

Customer customer = new Customer();
customer.Name = "Cliente Perú";
customer.LastName = "Vazquez Juarez";
customer.PhoneNumber = "4448936475";
customer.Email = "juan.vazquez@empresa.pe";

checkoutRequest.Customer = customer;
Checkout checkout = openpayAPI.CheckoutService.Create(checkoutRequest);
```
###### With customer
```c#
CheckoutRequest checkoutRequest = new CheckoutRequest();
checkoutRequest.Amount = 100;
checkoutRequest.Description = "Checkout de prueba";
checkoutRequest.OrderId = "OrderId";
checkoutRequest.Currency = "PEN";
checkoutRequest.RedirectUrl = "www.miempresa.com";
Checkout checkout = openpayAPI.CheckoutService.Create("CustomerId", checkoutRequest);
```
#### List checkouts
```c#
SearchParams searchParams = new SearchParams();
searchParams.Limit = 10;
searchParams.StartDate = "20211001"; //Format yyyymmdd
searchParams.EndDate = "20211011";
List<Checkout> checkouts = openpayAPI.CheckoutService.List(searchParams);
```

#### Update checkout
```c#
Checkout checkout = openpayAPI.CheckoutService.Get("CheckoutId");

UpdateCheckoutRequest newData = new UpdateCheckoutRequest();
newData.ExpirationDate = "2021-10-26 13:43"; //Format: yyyy-mm-dd HH:mm
string newStatus = "available";
Checkout updatedCheckout = openpayAPI.CheckoutService.Update(checkout, newStatus, newData);
```
Allowed statuses:
* available
* 
* 

#### Get checkout
```c#
Checkout checkout = openpayAPI.CheckoutService.Get("CheckoutId");
```
### Customers
#### Create a customer
```c#
Customer customer = new Customer();
customer.Name = "Juanito";
customer.LastName = "De Peru";
customer.Email = "juanito@deperu.com";
customer.RequiresAccount = false;

Address address = new Address();
address.City = "Lima";
address.CountryCode = "PE";
address.PostalCode = "110511";
address.Line1 = "Av 5 de Febrero";
address.Line2 = "Roble 207";
address.Line3 = "col carrillo";
address.State = "Lima";
customer.Address = address;

Customer addedCustomer = openpayAPI.CustomerService.Create(customer);
```
#### Update a customer
```c#
Customer customer = openpayAPI.CustomerService.Get(customer.Id);
string newName = "Juan Ejemplo";
customer.Name = newName;
Customer updatedCustomer = openpayAPI.CustomerService.Update(customer);
```
#### Get a customer
```c#
Customer customer = openpayAPI.CustomerService.Get("CustomerId");
```
#### Delete a customer
```c#
openpayAPI.CustomerService.Delete("CustomerId");
```
#### List clients
```c#
SearchParams searchParams = new SearchParams();
searchParams.CreationLte = DateTime.Now;
List<Customer> customers = openpayAPI.CustomerService.List(searchParams);
```
### Cards
#### Create a card
###### With customer

```c#
Card card = new Card();
card.HolderName = "Juan Perez";
card.CardNumber = "4111111111111111";
card.Cvv2 = "110";
card.ExpirationMonth = "12";
card.ExpirationYear = "21";
Card addedCard = openpayAPI.CardService.Create("CustomerId", card);
```
###### Without customer
```c#
Card card = new Card();
card.HolderName = "Juan Perez";
card.CardNumber = "4111111111111111";
card.Cvv2 = "110";
card.ExpirationMonth = "12";
card.ExpirationYear = "21";
Card addedCard = openpayAPI.CardService.Create(card);
```
###### With Token
```c#
Card card = new Card();
card.DeviceSessionId = "DeviceSessionId";
card.TokenId = "TokenId";
Card addedCard = openpayAPI.CardService.Create(card);
```
#### Get a card
```c#
Card card = openpayAPI.CardService.Get("CardId");
```
#### Delete a card
```c#
openpayAPI.CardService.Delete("CardId");
```
#### List cards
```c#
SearchParams searchParams = new SearchParams();
searchParams.CreationLte = DateTime.Now;
List<Card> cards = openpayAPI.CardService.List(searchParams);
```
### Webhooks
#### Create a webhook
```c#
Webhook newWebhook = new Webhook();
newWebhook.Url = "www.mysite.com";
newWebhook.User = "juanito";
newWebhook.Password = "juanitoPass";
List<String> events = new List<string>
{
    "charge.refunded",
    "charge.failed",
    "charge.cancelled",
    "charge.created",
    "chargeback.accepted"
};
newWebhook.EventTypes = events;
Webhook addedWebhook = openpayAPI.WebhooksService.Create(newWebhook);
```
The allowed values fot the field *event_types* are:
* charge.refunded
* charge.failed
* charge.cancelled
* charge.created
* charge.succeeded
* charge.rescored.to.decline
* subscription.charge.failed
* payout.created
* payout.succeeded
* payout.failed
* transfer.succeeded
* fee.succeeded
* fee.refund.succeeded
* spei.received
* chargeback.created
* chargeback.rejected
* chargeback.accepted
* order.created
* order.activated
* order.payment.received
* order.completed
* order.expired
* order.cancelled
* order.payment.cancelled
#### Get a webhook
```c#
Webhook webhook = openpayAPI.WebhooksService.Get("WebhookId");
```
#### Delete a webhook
```c#
openpayAPI.WebhooksService.Delete("WebhookId");
```
#### List webhooks
```c#
List<Webhook> webhooks = openpayAPI.WebhooksService.List();
```
### Tokens
#### Create a token
```c#
TokenRequest tokenRequest = new TokenRequest();
tokenRequest.CardNumber = "4111111111111111";
tokenRequest.HolderName = "Juan Perez Ramirez";
tokenRequest.ExpirationYear = "21";
tokenRequest.ExpirationMonth = "12";
tokenRequest.Cvv2 = "110";

Address address = new Address();
address.City = "Lima";
address.CountryCode = "PE";
address.PostalCode = "110511";
address.Line1 = "Av 5 de Febrero";
address.Line2 = "Roble 207";
address.Line3 = "col carrillo";
address.State = "Lima";

tokenRequest.Address = address;
Token addedToken = openpayAPI.TokenService.Create(tokenRequest);
```
#### Get a token
```c#
 Token token_ = openpayAPI.TokenService.Get("TokenId");
```


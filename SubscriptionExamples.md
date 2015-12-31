# Introduction #

Official documentation may be found [here](http://code.google.com/apis/checkout/developer/Google_Checkout_Beta_Subscriptions.html).


These samples are also located in the examples folder under post\_cart in a file called SubscriptionExamples.

# Details #

C# example:

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GCheckout;
using GCheckout.Checkout;
using GCheckout.Util;
using System.Diagnostics;

namespace SubscriptionExamples {

  class Program {

    // Methods
    public static void InitialCharge() {

      //http://code.google.com/apis/checkout/developer/Google_Checkout_Beta_Subscriptions.html
      //using an initial charge with a recurring charge using a different item.

      CheckoutShoppingCartRequest cartRequest
        = new CheckoutShoppingCartRequest("123456", "merchantkey", EnvironmentType.Sandbox, "USD", 120);

      //if you are using a web page and it has the Google Checkout button, you would use this syntax.
      //= GCheckoutButton1.CreateRequest()

      ShoppingCartItem initialItem = new ShoppingCartItem();
      ShoppingCartItem recurrentItem = new ShoppingCartItem();

      initialItem.Price = decimal.Zero;
      initialItem.Quantity = 1;
      initialItem.Name = "Item that shows in cart";
      initialItem.Description = "This is the item that shows in the cart";

      recurrentItem.Price = 2M;
      recurrentItem.Quantity = 1;
      recurrentItem.Name = "Item that is charged every month";
      recurrentItem.Description = "Description for item that is charged every month";

      Subscription subscription = new Subscription();
      subscription.Period = GCheckout.AutoGen.DatePeriod.MONTHLY;
      subscription.Type = SubscriptionType.merchant;

      SubscriptionPayment payment = new SubscriptionPayment();
      payment.MaximumCharge = 120M;
      payment.Times = 12;

      subscription.AddSubscriptionPayment(payment);

      //You must set the item that will be charged for every month.
      subscription.RecurrentItem = recurrentItem;

      //you must set the subscription for the item
      initialItem.Subscription = subscription;

      cartRequest.AddItem(initialItem);

      Debug.WriteLine(EncodeHelper.Utf8BytesToString(cartRequest.GetXml()));

      //Send the request to Google
      //GCheckout.Util.GCheckoutResponse resp = cartRequest.Send();

      //Uncommment this line or perform additional actions
      //if (resp.IsGood) {
      //Response.Redirect(resp.RedirectUrl, True)
      //}
      //else{
      //Response.Write("Resp.ResponseXml = " & Resp.ResponseXml & "<br>");
      //Response.Write("Resp.RedirectUrl = " & Resp.RedirectUrl & "<br>");
      //Response.Write("Resp.IsGood = " & Resp.IsGood & "<br>");
      //Response.Write("Resp.ErrorMessage = " & Resp.ErrorMessage & "<br>");      
      //}
    }

    public static void RecurringChargeRightAway() {

      CheckoutShoppingCartRequest cartRequest
        = new CheckoutShoppingCartRequest("123456", "merchantkey", EnvironmentType.Sandbox, "USD", 120);
      //if you are using a web page and it has the Google Checkout button, you would use this syntax.
      //= GCheckoutButton1.CreateRequest()

      Subscription gSubscription = new Subscription();
      SubscriptionPayment maxCharge = new SubscriptionPayment();

      DigitalItem urlDigitalItem = new DigitalItem(new Uri("http://www.url.com/login.aspx"),
        "Congratulations, your account has been created!");

      DigitalItem urlDigitalItemSubscription = new DigitalItem(new Uri("http://www.url.com/login.aspx"),
        "You may now continue to login to your account.");

      ShoppingCartItem gRecurrentItem = new ShoppingCartItem();
      maxCharge.MaximumCharge = 29.99M;

      gRecurrentItem.Name = "Entry Level Plan";
      gRecurrentItem.Description = "Allows for basic stuff. Monthly Subscription:";
      gRecurrentItem.Quantity = 1;
      gRecurrentItem.Price = 29.99M;
      gRecurrentItem.DigitalContent = urlDigitalItemSubscription;
      gRecurrentItem.DigitalContent.Disposition = DisplayDisposition.Pessimistic;

      urlDigitalItem.Disposition = DisplayDisposition.Pessimistic;

      gSubscription.Type = SubscriptionType.google;
      gSubscription.Period = GCheckout.AutoGen.DatePeriod.MONTHLY;
      gSubscription.AddSubscriptionPayment(maxCharge);
      gSubscription.RecurrentItem = gRecurrentItem;

      cartRequest.AddItem("Entry Level Plan", "Allows for basic stuff.", 1, gSubscription);
      cartRequest.AddItem("Entry Level Plan", "First Month:", 29.99M, 1, urlDigitalItem);

      cartRequest.MerchantPrivateData = "UserName:Joe87";

      Debug.WriteLine(EncodeHelper.Utf8BytesToString(cartRequest.GetXml()));

      //Send the request to Google
      //GCheckout.Util.GCheckoutResponse resp = cartRequest.Send();

      //Uncommment this line or perform additional actions
      //if (resp.IsGood) {
      //Response.Redirect(resp.RedirectUrl, True)
      //}
      //else{
      //Response.Write("Resp.ResponseXml = " & Resp.ResponseXml & "<br>");
      //Response.Write("Resp.RedirectUrl = " & Resp.RedirectUrl & "<br>");
      //Response.Write("Resp.IsGood = " & Resp.IsGood & "<br>");
      //Response.Write("Resp.ErrorMessage = " & Resp.ErrorMessage & "<br>");      
      //}

    }

  }
}

```


VB.Net example:

```
Imports GCheckout.Checkout
Imports GCheckout.Util

Module SubscriptionExamples

    Sub InitialCharge()

        'http://code.google.com/apis/checkout/developer/Google_Checkout_Beta_Subscriptions.html
        'using an initial charge with a recurring charge using a different item.

        Dim cartRequest As CheckoutShoppingCartRequest _
                = New CheckoutShoppingCartRequest("123456", "merchantkey", _
                GCheckout.EnvironmentType.Sandbox, "USD", 120) 'GCheckoutButton1.CreateRequest()

        Dim initialItem As New ShoppingCartItem()
        Dim recurrentItem As New ShoppingCartItem()

        initialItem.Price = 0 'do not have an additional charge.
        initialItem.Quantity = 1
        initialItem.Name = "Item that shows in cart"
        initialItem.Description = "This is the item that shows in the cart"

        recurrentItem.Price = 2
        recurrentItem.Quantity = 1
        recurrentItem.Name = "Item that is charged every month"
        recurrentItem.Description = "Description for item that is charged every month"

        Dim subscription As New Subscription()
        subscription.Period = GCheckout.AutoGen.DatePeriod.MONTHLY
        subscription.Type = SubscriptionType.merchant

        Dim payment As New SubscriptionPayment()
        payment.MaximumCharge = 120
        payment.Times = 12

        subscription.AddSubscriptionPayment(payment)

        'You must set the item that will be charged for every month.
        subscription.RecurrentItem = recurrentItem

        'you must set the subscription for the item
        initialItem.Subscription = subscription

        cartRequest.AddItem(initialItem)

        'Debug.WriteLine(EncodeHelper.Utf8BytesToString(cartRequest.GetXml()))

        'Dim resp As GCheckout.Util.GCheckoutResponse = gg.Send()
        'Response.Redirect(resp.RedirectUrl, True)
    End Sub

    Sub RecurringChargeRightAway()
        Dim cartRequest As CheckoutShoppingCartRequest _
            = New CheckoutShoppingCartRequest("123456", "merchantkey", _
            GCheckout.EnvironmentType.Sandbox, "USD", 120) 'GCheckoutButton1.CreateRequest()

        Dim gSubscription As New Subscription
        Dim maxCharge As New SubscriptionPayment
        Dim urlDigitalItem As New DigitalItem(New  _
                                  Uri("http://www.url.com/login.aspx"), _
                                  "Congratulations, your account has been created!")
        Dim urlDigitalItemSubscription As New DigitalItem(New  _
                                  Uri("http://www.url.com/login.aspx"), _
                                  "You may now continue to login to your account.")
        Dim gRecurrentItem As New ShoppingCartItem()
        maxCharge.MaximumCharge = 29.99
        gRecurrentItem.Name = "Entry Level Plan"
        gRecurrentItem.Description = "Allows for basic stuff. Monthly Subscription:"
        gRecurrentItem.Quantity = 1
        gRecurrentItem.Price = 29.99
        gRecurrentItem.DigitalContent = urlDigitalItemSubscription
        gRecurrentItem.DigitalContent.Disposition = DisplayDisposition.Pessimistic

        urlDigitalItem.Disposition = DisplayDisposition.Pessimistic

        gSubscription.Type = SubscriptionType.google
        gSubscription.Period = GCheckout.AutoGen.DatePeriod.MONTHLY
        gSubscription.AddSubscriptionPayment(maxCharge)
        gSubscription.RecurrentItem = gRecurrentItem

        cartRequest.AddItem("Entry Level Plan", "Allows for basic stuff.", 1, gSubscription)
        cartRequest.AddItem("Entry Level Plan", "First Month:", 29.99, 1, urlDigitalItem)

        ' May use this if you want Google to track something with your order   
        cartRequest.MerchantPrivateData = "UserName:Joe87"

        Debug.WriteLine(EncodeHelper.Utf8BytesToString(cartRequest.GetXml()))

        'Dim Resp As GCheckoutResponse = Req.Send
        'If Resp.IsGood Then
        '    Response.Redirect(Resp.RedirectUrl, True)
        'Else
        '    Response.Write("Resp.ResponseXml = " + Resp.ResponseXml + "<br>")
        '    Response.Write("Resp.RedirectUrl = " + Resp.RedirectUrl + "<br>")
        '    Response.Write("Resp.IsGood = " + Resp.IsGood + "<br>")
        '    Response.Write("Resp.ErrorMessage = " + Resp.ErrorMessage + "<br>")
        'End If

    End Sub

End Module

```
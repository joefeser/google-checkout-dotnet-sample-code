# Introduction #

Something that says "welcome and check below for answers to your questions".


## Questions ##

### [Installation](FAQ#Installation.md) ###
  1. What files should I download?
  1. How do I install the DLL file on my web server?
  1. Does GCheckout.dll work in shared environments?
  1. Can I call the library from Visual Basic?

### [Usage](FAQ#Usage.md) ###
  1. I downloaded the files, put GCheckout.dll in my bin directory. Now what?
  1. How do I process notifications sent by Google?
  1. How do I read merchant-private-data from a notification?
  1. How do I use merchant-calculation callbacks?
  1. How do I read merchant-private-data in merchant-calculation callbacks?

### [Troubleshooting](FAQ#Troubleshooting.md) ###
  1. I don't get any notifications from Google. What should I do?
  1. How do I Get the Merchant Codes back from a new-order-notification?


---


## Installation ##

### 1. What files should I download? ###
There are five files available for download. The first one is mandatory, the rest optional.
  * GCheckoutV2.5.0.5.zip -- DLL file that you should put in your bin directory.
  * Examplesv2.5.0.5.zip -- Example ASPX files that demonstrate how to call the DLL.
  * GCheckoutSourceV2.5.0.5.zip -- Source code used to build the DLL. This is useful if you want to extend the library or if you are doing merchant-calculation callbacks.
  * API reference v1.3.chm -- Windows help file that documents the classes and methods in GCheckout.dll.
  * API reference v1.3.zip -- HTML files that documents the classes and methods in GCheckout.dll. Same content as "API reference v1.3.chm" but different format.

### 2. How do I install the DLL file on my web server? ###
You can either add a reference to the file from your web solution or you can place the assembly in the GAC. See Gacutil for more information.

### 3. Does GCheckout.dll work in shared environments? ###
It is recommended that you use v2.5.0.5+ for shared environments. Godaddy and many other providers have issues with the v1 implementation.

### 4. Can I call the library from Visual Basic? ###
Yes, any .net language can use the library.

## Usage ##

### 1. I downloaded the files, put GCheckout.dll in my bin directory. Now what? ###
The best thing to do is download the examples and look at the aspx pages contained in the post\_cart folder. These will provide you with different samples on how to create a cart and post it to Google Checkout.

### 2. How do I process notifications sent by Google? ###
A detailed example has been created in the api25notification folder of samples.
The workflow is described [here](http://code.google.com/apis/checkout/developer/Google_Checkout_Custom_Processing_How_To.html).

### 3. How do I read merchant-private-data from a notification? ###
The private data is located in the inputNewOrderNotification.shoppingcart.merchantprivatedata node of the NewOrderNotification. If you only have one XmlNode then you can just use the following array syntax `inputNewOrderNotification.shoppingcart.merchantprivatedata.Any[0].InnerText` or `.Any(0)` for vb.net.

For methods on how to create merchant-private-data, see the examples private-data.aspx and private-data-xml.aspx in the post\_cart directory.

### 4. How do I use merchant-calculation callbacks? ###
In the merchant\_calculation\listener folder, there is an example called callback.aspx. It calls into the Google Checkout assembly into a class called CallbackProcessor. The Process method has a complete example of how to process the callbacks for coupons and shipping amounts.

### 5. How do I read merchant-private-data in merchant-calculation callbacks? ###
The CallbackProcessor creates and Order class. This class contains a property MerchantPrivateData if you are just passing a string and MerchantPrivateDataNodes if you sent an XmlNodeList.

### Troubleshooting ###

1. I don't get any notifications from Google. What should I do?
  * Make sure you are not getting messages in the Admin Console. If there was an error, it will be logged.
  * The next thing to do is to verify the web logs to make sure you were not throwing a 500 Error.
  * Make sure you did not swallow the error.

2. How do I Get the Merchant Codes back from a new-order-notification?
  * There is a new class called MerchantCode (GCheckout.Checkout.MerchantCode).
  * Find the static property on it called GetMerchantCodes
  * If you are not using the extended notification, you can just take your new-order-notification and call the method this way
  * MerchantCode[.md](.md) codes = MerchantCode.GetMerchantCodes(this); "this" being the new order notification object.
  * It will return a MerchantCode Array. (Null will not be returned, you will just receive an empty array).
  * The Property CodeType will tell you if it is a Coupon or Gift Certificate.

We have now converted to Hg from svn for source control. Updates are **not** being uploaded to the svn repo, it is read only.
# Introduction #

The project's documentation currently resides at http://code.google.com/apis/checkout/samples/Google_Checkout_Sample_Code_NET.html

Feel free to add tips and tricks learned when using the code on this wiki.


## Version 1.0.2 released ##

I just released version 1.0.2. It is the same as version 1.0.1, except that it points to the new Sandbox URL. The old Sandbox URL will stop working on 1/17/2007. So update if you want to use Sandbox!


## Version 1.1 released (Feb 3, 2007) ##

We just released version 1.1. Highlights:
  * Examples of how to use the library.
    * Merchant-calculated tax, shipping and coupons.
    * Notification sender (to test your notification handler).
    * Post cart.
    * Process notifications asynchronously.
    * Process notifications synchronously.
  * Support for features exposed by the recently published XSD.
    * Merchant-item-id property of cart items, which can be used to store SKUs (see http://code.google.com/apis/checkout/developer/index.html#tag_platform-id).
    * Third-party pixel tracking (see http://code.google.com/apis/checkout/developer/checkout_pixel_tracking.html)
    * Platform-id for eCommerce providers (see http://code.google.com/apis/checkout/developer/index.html#tag_platform-id)


## Version 1.2 released (Apr 10, 2007) ##

A ton of really cool features have made it into this version of the
code.

  * You can now use config sections in the web.config file.
    * See [Joe's blog post](http://joefeser.posterous.com/2007/04/using-config-sections-with-google.html) for how to do it.
  * International Tax and Shipping - These modifications let you offer shipping methods and charge tax for international addresses.
    * See [the Shipping Restrictions and Address Filters section of the Developer's Guide](http://code.google.com/apis/checkout/developer/index.html#shipping_restrictions_and_address_filters).
    * See the document on [Understanding Areas](http://code.google.com/apis/checkout/developer/Google_Checkout_Understanding_Areas.html) for examples.
  * Restricting Shipping Options for Post Office (P.O.) Box Addresses - This update allows you to prevent a shipping option from being offered if the shipping address is a P.O. box in the United States.
    * See [the Shipping Restrictions and Address Filters section of the Developer's Guide](http://code.google.com/apis/checkout/developer/index.html#shipping_restrictions_and_address_filters).
    * See the document on [Understanding Areas](http://code.google.com/apis/checkout/developer/Google_Checkout_Understanding_Areas.html) for examples.
  * Address Filters to Limit Shipping Methods - This update enables you to specify a geographic area where a particular merchant-calculated shipping method is available or unavailable.
    * The [Shipping Restrictions and Address Filters](http://code.google.com/apis/checkout/developer/index.html#shipping_restrictions_and_address_filters) section of the Dev Guide has more information.
    * The document [Shipping Restrictions and Address Filters ](http://code.google.com/apis/checkout/developer/Google_Checkout_Shipping_Restrictions_and_Address_Filters.html) explains how to use both types of filters.
  * Selecting a Rounding Policy for Tax Calculations - This update allows you to select the rounding policy that Google Checkout will use to calculate taxes and order totals. This change also enables you to choose whether Google will apply rounding rules to each item in an order before the order total is calculated or if Google will calculate the order total before applying rounding rules.
    * See the [Additional Tax-Related Features](http://code.google.com/apis/checkout/developer/index.html#additional_tax_features) section of the Developer's Guide.
  * The only feature that is not supported in the code is the PIN attribute on  merchant-code-string ([relevant section in the Dev Guide](http://code.google.com/apis/checkout/developer/index.html#tag_merchant-code-string)). Once the XSD provides support for this feature, it will be added to the code.


## Version 1.3 released (November 23, 2007) ##

The Schema and release notes are supported up to November 15, 2007.

  * Add util method to extract shipping method name from NewOrderNotification has been closed.
    * See [Issue 17](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=17&can=1)
  * GCheckout.Util.GCheckoutConfigurationHelper can work only in Web Application has been closed
    * See [Issue 19](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=19&can=1)
  * Order of method calls significant for merchant-calculated shipping has been closed
    * See [Issue 20](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=20&can=1)
  * Change the way Alt Tax Rate Tables are created and passed to Shopping Cart Items has been closed
    * See [Issue 21](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=21&can=1)
  * Create public ShoppingCartItem class for the AddItem method has been closed
    * See [Issue 22](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=22&can=1)
  * Implement new URL for XML posts has been closed
    * See [Issue 26](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=26&can=1)
  * Proxy Support
  * VB.Net examples now exist.
  * The coverage for our unit tests has increased from 31% to over 70%. See [Issue 24](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=24&can=1)
  * Other bugs or enhancements have also been added to this release.

## Version 1.3.2 released (May 14, 2008) ##

**New**

  * Added NDepend Reports for Cyclomatic complexity Analysis.
  * The ability to obtain GiftCertificateAdjustment from the NewOrderNotificationExtended class.
  * Added Sample using the new ga.js Google Analytics javascript file.

**Bug Fixes**

  * MerchantCalculationCallback does not work with non USD Currency. Allow the currency to be set without using the web.config file. This is consistent with the other callback classes.
    * See [Issue 29](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=29&can=1)
  * GCheckout problem sending URLEncoded Querystrings. We are using .NET 1.1 so the issue was fixed as close as possible to match the .NET 2.0 fix.
    * See [Issue 30](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=30&can=1)
  * GiftCertificateAdjustment Access from the Extended New Order Notification is fixed.
    * See [Issue 31](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=31&can=1)
  * Tax rates entered in UI aren't applied. This was an oversite on my side. We now check to make sure at least one Tax table is in use before building out the node. If the node exists and it is empty, it will override any values entered into the Admin UI.
    * See [Issue 36](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=36&can=1)
  * Fixed the ShoppingCartItem class to allow you to obtain the TaxTableSelector property from a NewOrderNotificationExtended class. The property was not available in the past.

## Version 2.5.0.5 released (Apr 21, 2011) ##

**New**

  * Support for v2.5 Callback API as described [here](http://code.google.com/apis/checkout/developer/Google_Checkout_Custom_Processing_How_To.html).
  * Added new example "api25notification" showing how to process a v2.5 order notification callback. Please see the Examples or Source downloads on the tab [here](http://code.google.com/p/google-checkout-dotnet-sample-code/downloads/list)

**Bug Fixes**

  * itemshippinginformationlist and trackingdatalist were being set even if they were not used, causing a failure when posted.
    * See [Issue 52](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=52&can=1)
  * Added the ability to create a notification-history-request with a serial-number instead of an array or order numbers.
    * See [Issue 48](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=48&can=1)
  * Fixed bug in default-tax-table and alternate-tax-table where rateSpecified was not being set, causing the rate to not be serialized.
    * See [Issue 55](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=55&can=1)

## Version 2.5.0.9 released (Aug 3, 2012) ##

**New**
  * Assembly is now signed
  * Complete Logging of Xml and Errors

A new attribute was added to the config to handle this. LogDirectoryXml. If this is set and logging is set to true, all of the xml will be saved to that folder. We try to determine the serial number and if we do, we save the file with that name.

**Bug Fixes**

  * Handle incorrect xml sent by the api for the Notification History Response.
    * See [Issue 59](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=52&can=1)
    * See [Issue 60](http://code.google.com/p/google-checkout-dotnet-sample-code/issues/detail?id=48&can=1)
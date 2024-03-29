/*************************************************
 * Copyright (C) 2006-2012 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*************************************************/
using System;
using System.IO;
using System.Text;
using GCheckout.Checkout;
using NUnit.Framework;
using GCheckout.Util;

namespace GCheckout.Checkout.Tests {

  /// <exclude/>
  [TestFixture]
  public class EncodeHelperTests {
    /// <exclude/>
    [Test]
    public void StringToUtf8BytesAndBack() {
      string Orig = "abc€Œ™©®åëñöÿ!\"#$%&'()*+,-./שּׁзγəˆỊ₪€₧ﻷ";
      Assert.AreEqual(Orig,
        EncodeHelper.Utf8BytesToString(EncodeHelper.StringToUtf8Bytes(Orig)));
    }

    /// <exclude/>
    [Test]
    public void GetTopElement_OK() {
      byte[] B = EncodeHelper.Serialize(CreateNewOrderNotification());
      string Xml = EncodeHelper.Utf8BytesToString(B);
      Assert.AreEqual("new-order-notification",
        EncodeHelper.GetTopElement(Xml));
    }

    /// <exclude/>
    [Test]
    public void Utf8StreamToString() {
      string Orig = "abc€Œ™©®åëñöÿ!\"#$%&'()*+,-./שּׁзγəˆỊ₪€₧ﻷ";
      byte[] B = EncodeHelper.StringToUtf8Bytes(Orig);
      MemoryStream MS = new MemoryStream(B);
      string NewString = EncodeHelper.Utf8StreamToString(MS);
      Assert.AreEqual(Orig, NewString);
    }

    /// <exclude/>
    [Test]
    public void GetElementValue_OK_1() {
      byte[] B = EncodeHelper.Serialize(CreateNewOrderNotification());
      String Xml = EncodeHelper.Utf8BytesToString(B);
      Assert.AreEqual("841171949013218",
        EncodeHelper.GetElementValue(Xml, "google-order-number"));
    }

    /// <exclude/>
    [Test]
    public void GetElementValue_OK_2() {
      byte[] B = EncodeHelper.Serialize(CreateNewOrderNotification());
      String Xml = EncodeHelper.Utf8BytesToString(B);
      Assert.AreEqual("fc8n593wfhfoc8nwot8",
        EncodeHelper.GetElementValue(Xml, "serial-number"));
    }

    /// <exclude/>
    [Test]
    public void GetElementValue_NotFound() {
      byte[] B = EncodeHelper.Serialize(CreateNewOrderNotification());
      String Xml = EncodeHelper.Utf8BytesToString(B);
      Assert.AreEqual("", EncodeHelper.GetElementValue(Xml, "wacky-element"));
    }

    /// <exclude/>
    [Test]
    public void SerializeAndDeserialize() {
      AutoGen.NewOrderNotification N1 = CreateNewOrderNotification();
      byte[] B = EncodeHelper.Serialize(N1);
      String Xml = EncodeHelper.Utf8BytesToString(B);
      AutoGen.NewOrderNotification N2 = (AutoGen.NewOrderNotification)
        EncodeHelper.Deserialize(Xml, typeof(AutoGen.NewOrderNotification));
      Assert.AreEqual(N1.googleordernumber, N2.googleordernumber);
      Assert.AreEqual(N1.buyerid, N2.buyerid);
      Assert.AreEqual(N1.serialnumber, N2.serialnumber);
      Assert.AreEqual(N1.financialorderstate, N2.financialorderstate);
      Assert.AreEqual(N1.timestamp, N2.timestamp);
      Assert.AreEqual(N1.shoppingcart.items.Length,
        N2.shoppingcart.items.Length);
      Assert.AreEqual(N1.shoppingcart.items[0].itemname,
        N2.shoppingcart.items[0].itemname);
      Assert.AreEqual(N1.shoppingcart.items[0].itemdescription,
        N2.shoppingcart.items[0].itemdescription);
      Assert.AreEqual(N1.shoppingcart.items[0].quantity,
        N2.shoppingcart.items[0].quantity);
      Assert.AreEqual(N1.shoppingcart.items[0].unitprice.currency,
        N2.shoppingcart.items[0].unitprice.currency);
      Assert.AreEqual(N1.shoppingcart.items[0].unitprice.Value,
        N2.shoppingcart.items[0].unitprice.Value);
      Assert.AreEqual(N1.shoppingcart.items[1].itemname,
        N2.shoppingcart.items[1].itemname);
      Assert.AreEqual(N1.shoppingcart.items[1].itemdescription,
        N2.shoppingcart.items[1].itemdescription);
      Assert.AreEqual(N1.shoppingcart.items[1].quantity,
        N2.shoppingcart.items[1].quantity);
      Assert.AreEqual(N1.shoppingcart.items[1].unitprice.currency,
        N2.shoppingcart.items[1].unitprice.currency);
      Assert.AreEqual(N1.shoppingcart.items[1].unitprice.Value,
        N2.shoppingcart.items[1].unitprice.Value);
    }

    /// <exclude/>
    [Test]
    public void EncodeXmlChars() {
      string In = "$25 > $20 & $100 < $200 <<&&>>";
      string Expected = "$25 &#x3e; $20 &#x26; $100 &#x3c; $200 &#x3c;&#x3c;" +
        "&#x26;&#x26;&#x3e;&#x3e;";
      Assert.AreEqual(Expected, EncodeHelper.EscapeXmlChars(In));
    }

    /// <exclude/>
    [Test]
    public void FailedXmlParsing_NotXml() {
      string invalidXml = "This is not valid XML.";
      try {
        Object o = EncodeHelper.Deserialize(invalidXml);
        Assert.Fail("An exception should have been thrown.");
      }
      catch (ApplicationException e) {
        // Make sure there is an exception and that it contains
        // the malformed XML.
        Assert.IsTrue(e.Message.IndexOf(invalidXml) > -1);
      }
    }

    /// <exclude/>
    [Test]
    public void FailedXmlParsing_InvalidBeginning() {
      AutoGen.NewOrderNotification n = CreateNewOrderNotification();
      string xml = EncodeHelper.Utf8BytesToString(EncodeHelper.Serialize(n));
      xml = "blah" + xml;
      try {
        Object o = EncodeHelper.Deserialize(xml);
        Assert.Fail("An exception should have been thrown.");
      }
      catch (ApplicationException e) {
        // Make sure there is an exception and that it contains
        // the malformed XML.
        Assert.IsTrue(e.Message.IndexOf(xml) > -1);
      }
    }

    /// <exclude/>
    [Test]
    public void BadXmlTests() {
      try {
        EncodeHelper.Deserialize("<garbage />", typeof(System.Object));
        Assert.Fail("You should not have been able to deserialize this preceding xml");
      }
      catch {
      }

      MemoryStream ms = new MemoryStream();
      using (StreamWriter sw = new StreamWriter(ms)) {
        sw.Write("<garbage />");
        sw.Flush();
        object test = EncodeHelper.Deserialize(ms);
        Assert.AreEqual(null, test);
      }

      try {
        //Test the Deserialize method that builds an error message.
        ms = new MemoryStream();
        using (BufferedStream sw = new BufferedStream(ms)) {
          sw.Write(Encoding.UTF8.GetPreamble(), 0, 3);
          byte[] msg = System.Text.Encoding.UTF8.GetBytes("<garbage>");
          sw.Write(msg, 0, msg.Length);
          sw.Flush();
          ms.Position = 0;
          object test = EncodeHelper.Deserialize(ms);
          Assert.AreEqual(null, test);
        }
      }
      catch (Exception ex) {
        if (ex.Message.IndexOf("Couldn't parse XML") == -1)
          Assert.Fail("We should have failed for a bad xml file.");
      }
    }

    /// <exclude/>
    [Test]
    public void FailedXmlParsing_InvalidEnd() {
      AutoGen.NewOrderNotification n = CreateNewOrderNotification();
      string xml = EncodeHelper.Utf8BytesToString(EncodeHelper.Serialize(n));
      xml = xml + "blah";
      try {
        Object o = EncodeHelper.Deserialize(xml);
        Assert.Fail("An exception should have been thrown.");
      }
      catch (ApplicationException e) {
        // Make sure there is an exception and that it contains
        // the malformed XML.
        Assert.IsTrue(e.Message.IndexOf(xml) > -1);
      }
    }

    /// <exclude/>
    [Test]
    public void EnumSerilizedNameTests() {
      //make sure the value is string.Empty
      EnumSerilizedNameAttribute val = new EnumSerilizedNameAttribute();
      Assert.AreEqual(val.Value, string.Empty);

      //get a member info to ourself
      Type t = typeof(EncodeHelperTests);
      System.Reflection.MemberInfo mi = t.GetMember("EnumSerilizedNameTests")[0];
      Assert.AreEqual(string.Empty, EnumSerilizedNameAttribute.GetValue(mi));
    }

    /// <exclude/>
    [Test]
    public void CartSignatureTests() {
      string xml = "<test />";
      string sign = "wnHXcU/1//4SbpVEb88WaIB9td4=";
      Assert.AreEqual(sign, EncodeHelper.GetCartSignature(xml, "12345"));
    }

    /// <exclude/>
    [Test]
    public void MoneyTests() {
      Assert.AreEqual(12.99m, EncodeHelper.Money(12.99m).Value);
      Assert.AreEqual(12.95m, EncodeHelper.Money("USD", 12.95m).Value);
      //rounding tests
      Assert.AreEqual(12.99m, EncodeHelper.Money(12.994m).Value);
      Assert.AreEqual(12.98m, EncodeHelper.Money("USD", 12.975m).Value);

      Assert.AreEqual("USD", EncodeHelper.Money("USD", 12.95m).currency);
    }

    /// <exclude/>
    [Test]
    public void TypeDictionaryEntryAttributeTests() {
      //make sure the value is string.Empty
      TypeDictionaryEntryAttribute val = new TypeDictionaryEntryAttribute();
      Assert.AreEqual(val.Name, string.Empty);
      Assert.AreEqual(val.Value, string.Empty);

      //get a member info to ourself
      Type t = typeof(EncodeHelperTests);
      System.Reflection.MemberInfo mi = t.GetMember("EnumSerilizedNameTests")[0];
      Assert.AreEqual(string.Empty, TypeDictionaryEntryAttribute.GetValue(mi, "Test"));

      Assert.AreEqual(string.Empty, ShippingTypeHelper.GetSerializedName(ShippingType.Unknown));
      Assert.AreEqual(string.Empty, ShippingTypeHelper.GetShippingCompany(ShippingType.Unknown));
    }

    /// <exclude/>
    private AutoGen.NewOrderNotification CreateNewOrderNotification() {
      AutoGen.NewOrderNotification N1 = new AutoGen.NewOrderNotification();
      N1.googleordernumber = "841171949013218";
      N1.buyerid = 379653;
      N1.serialnumber = "fc8n593wfhfoc8nwot8";
      N1.timestamp = DateTime.Now;
      N1.shoppingcart = new AutoGen.ShoppingCart();
      N1.shoppingcart.items = new AutoGen.Item[2];
      N1.shoppingcart.items[0] = new AutoGen.Item();
      N1.shoppingcart.items[0].itemname = "Vanilla Coffee Syrup";
      N1.shoppingcart.items[0].itemdescription = "From Espresso House";
      N1.shoppingcart.items[0].quantity = 10;
      N1.shoppingcart.items[0].unitprice = new AutoGen.Money();
      N1.shoppingcart.items[0].unitprice.currency = "USD";
      N1.shoppingcart.items[0].unitprice.Value = 5.05m;
      N1.shoppingcart.items[1] = new AutoGen.Item();
      N1.shoppingcart.items[1].itemname = "Nescafé Cappuccino ©";
      N1.shoppingcart.items[1].itemdescription = "שּׁзγəˆỊ₪€₧ﻷ";
      N1.shoppingcart.items[1].quantity = 2;
      N1.shoppingcart.items[1].unitprice = new AutoGen.Money();
      N1.shoppingcart.items[1].unitprice.currency = "SEK";
      N1.shoppingcart.items[1].unitprice.Value = 23.50m;
      return N1;
    }

  }
}

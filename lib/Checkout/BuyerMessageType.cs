/*************************************************
 * Copyright (C) 2008-2010 Google Inc.
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
/*
 Edit History:
 *  5-22-2010   Joe Feser joe.feser@joefeser.com
 *  Initial Release.
 * 
*/
using System;

namespace GCheckout.Checkout
{
  /// <summary>
  /// The type of BuyerMessage.
  /// </summary>
  public enum BuyerMessageType
  {
    ///<remarks />
    Unknown,
    ///<remarks />
    BuyerNote,
    ///<remarks />
    DeliveryInstructions,
    ///<remarks />
    GiftMessage,
    ///<remarks />
    InHonorOfMessage,
    ///<remarks />
    InMemoryOfMessage,
    ///<remarks />
    InTributeOfMessage,
    ///<remarks />
    SpecialInstructions,
    ///<remarks />
    SpecialRequests
  }
}

/*
 * COPYRIGHT © 2014. OPENPAY.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Class: WebhookService.cs
 * 
 * Change control:
 * ---------------------------------------------------------------------------------------
 * Version | Date       | Name                                      | Description
 * ---------------------------------------------------------------------------------------
 *   1.0	2014-12-01	Marcos Coronado marcos.coronado@openpay.mx	 Creating Class.
 *
 */
using Openpay.Entities;
using System.Collections.Generic;

namespace Openpay
{
    public interface IWebhookService
    {
        Webhook Create(Webhook webhook);
        void Delete(string webhook_id);
        Webhook Get(string webhook_id);
        List<Webhook> List();
        void Verify(string webhook_id, string verification_code);
    }
}
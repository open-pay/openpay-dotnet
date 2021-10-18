using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class CardService : OpenpayResourceService<Card, Card>
    {
        public CardService(string api_key, string merchant_id, Countries country, bool production = false)
            : base(api_key, merchant_id, country, production)
        {
            ResourceName = "cards";
        }

        internal CardService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "cards";
        }

        public Card Create(Card card)
        {
            return base.Create(null, card);
        }

        public new Card Create(string customer_id, Card card)
        {
            return base.Create(customer_id, card);
        }

        public new void Delete(string customer_id, string card_id)
        {
            base.Delete(customer_id, card_id);
        }

        public void Delete(string card_id)
        {
            base.Delete(null, card_id);
        }

        public new Card Get(string customer_id, string card_id)
        {
            return base.Get(customer_id, card_id);
        }

        public Card Get(string card_id)
        {
            return base.Get(null, card_id);
        }

        public new List<Card> List(string customer_id, SearchParams filters = null)
        {
            return base.List(customer_id, filters);
        }

        public List<Card> List(SearchParams filters = null)
        {
            return base.List(null, filters);
        }

		public PointsBalance Points(string card_id)
		{
			string ep = GetEndPoint(null, card_id) + "/points";
			return this.httpClient.Get<PointsBalance>(ep);
		}

		public PointsBalance Points(string customer_id, string card_id)
		{
			string ep = GetEndPoint(customer_id, card_id) + "/points";
			return this.httpClient.Get<PointsBalance>(ep);
		}

	}
}

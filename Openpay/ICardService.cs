using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface ICardService
    {
        Card Create(Card card);
        Card Create(string customer_id, Card card);
        void Delete(string card_id);
        void Delete(string customer_id, string card_id);
        Card Get(string card_id);
        Card Get(string customer_id, string card_id);
        List<Card> List(SearchParams filters = null);
        List<Card> List(string customer_id, SearchParams filters = null);
        PointsBalance Points(string card_id);
        PointsBalance Points(string customer_id, string card_id);
    }
}
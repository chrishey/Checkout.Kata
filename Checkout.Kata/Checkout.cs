using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Kata
{
    public class Checkout
    {
        private readonly List<Item> _items;
        private readonly List<SpecialOffer> _specialOffers;

        public Checkout()
        {
            _items = new List<Item>();
            _specialOffers = new List<SpecialOffer>();
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public void AddSpecialOffer(SpecialOffer offer)
        {
            //todo: add a check to make sure the same offer can't added more than once
            _specialOffers.Add(offer);
        }

        public decimal Total()
        {
            // check for qualifying offers, if none to apply return the item prices sum
            if(!_specialOffers.Any())
                return _items.Sum(x => x.Price);

            var subTotal = 0.0m;

            foreach (var offer in _specialOffers)
            {
                if (_items.Count(x => x.Sku == offer.Sku) < offer.Quantity) continue; // offer doesn't apply on the SKU, not enough items
                {
                    // set a flag on the items where the offer is applied so they don't get added to the total
                    // as they are in the sub total.
                    _items.Where(x=>x.Sku==offer.Sku).Take(offer.Quantity).ToList().ForEach(SetOfferApplied);
                    subTotal += offer.Price;
                }
            }

            return subTotal + _items.Where(i => !i.OfferApplied).Sum(p=>p.Price);
        }

        private void SetOfferApplied(Item item)
        {
            item.OfferApplied= true;
        }

        public void Scan(Item item)
        {
            _items.Add(item);
        }
    }
}

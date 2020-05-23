using System.Collections.Generic;
using System.Linq;

namespace Checkout.Kata
{
    public class Checkout
    {
        private readonly List<Item> _items;

        public Checkout()
        {
            _items = new List<Item>();
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public decimal Total()
        {
            return _items.Sum(x=>x.Price);
        }

        public void Scan(Item item)
        {
            _items.Add(item);
        }
    }
}

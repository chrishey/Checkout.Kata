using System.Collections.Generic;

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
            return 0m;
        }

        public void Scan(Item item)
        {
            _items.Add(item);
        }
    }
}

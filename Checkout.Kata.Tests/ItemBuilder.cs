namespace Checkout.Kata.Tests
{
    public class ItemBuilder
    {
        protected Item Item;

        public ItemBuilder()
        {
            Item = new Item();
        }

        public ItemBuilder WithSku(string sku)
        {
            Item.Sku = sku;
            return this;
        }

        public ItemBuilder WithPrice(decimal price)
        {
            Item.Price = price;
            return this;
        }

        public Item Build()
        {
            return Item;
        }
    }
}

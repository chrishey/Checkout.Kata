namespace Checkout.Kata
{
    public class Item
    {
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public bool OfferApplied { get; set; }

        public Item()
        {
            OfferApplied = false;
        }
    }
}
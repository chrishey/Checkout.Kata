using Should;
using Xunit;

namespace Checkout.Kata.Tests
{
    public class CheckoutFixture
    {
        private readonly Checkout _itemUnderTest;

        public CheckoutFixture()
        {
            _itemUnderTest = new Checkout();
        }

        [Fact]
        public void CanScanAnItem()
        {
            var item = new Item {Sku = "A99", Price = 0.50m};

            _itemUnderTest.Scan(item);

            _itemUnderTest.GetItems().Count.ShouldEqual(1);
        }

        [Fact]
        public void CanGetCheckoutTotal()
        {
            var itemPrice = 0.50m;
            var item = new Item { Sku = "A99", Price = itemPrice };

            _itemUnderTest.Scan(item);

            _itemUnderTest.Total().ShouldEqual(itemPrice);
        }

        [Fact]
        public void CanScanMultipleItems()
        {
            var item = new Item { Sku = "A99", Price = 0.50m };
            var item2 = new Item { Sku = "B15", Price = 0.30m };

            _itemUnderTest.Scan(item);
            _itemUnderTest.Scan(item2);

            _itemUnderTest.GetItems().Count.ShouldEqual(2);
        }

        [Fact]
        public void CanGetTotalForMultipleItems()
        {
            var item1 = new ItemBuilder().WithSku("A99").WithPrice(0.50m).Build();
            var item2 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();

            _itemUnderTest.Scan(item1);
            _itemUnderTest.Scan(item2);

            _itemUnderTest.Total().ShouldEqual(0.80m);
        }

        [Fact]
        public void CanApplySpecialOffer()
        {
            var item1 = new ItemBuilder().WithSku("A99").WithPrice(0.50m).Build();
            var item2 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();
            var item3 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();

            var offer = new SpecialOffer {Sku = "B15", Price = 0.45m, Quantity = 2};

            // this does require the offer to be added before scanning.
            // However gives flexibility that you can add offers rather than them being set in the Checkout itself.
            _itemUnderTest.AddSpecialOffer(offer);

            _itemUnderTest.Scan(item1);
            _itemUnderTest.Scan(item2);
            _itemUnderTest.Scan(item3);

            _itemUnderTest.Total().ShouldEqual(0.95m);
        }

        [Fact]
        public void CanTotalSpecialOfferAndNonQualifyingItems()
        {
            var item1 = new ItemBuilder().WithSku("A99").WithPrice(0.50m).Build();
            var item2 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();
            var item3 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();
            var item4 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();
            var item5 = new ItemBuilder().WithSku("C40").WithPrice(0.60m).Build();

            var offer = new SpecialOffer { Sku = "B15", Price = 0.45m, Quantity = 2 };

            // this does require the offer to be added before scanning.
            // However gives flexibility that you can add offers rather than them being set in the Checkout itself.
            _itemUnderTest.AddSpecialOffer(offer);

            _itemUnderTest.Scan(item1);
            _itemUnderTest.Scan(item2);
            _itemUnderTest.Scan(item3);
            _itemUnderTest.Scan(item4);
            _itemUnderTest.Scan(item5);

            _itemUnderTest.Total().ShouldEqual(1.85m);
        }

        [Fact]
        public void CanTotalMultipleSpecialOffersAndNonQualifyingItems()
        {
            var item1 = new ItemBuilder().WithSku("A99").WithPrice(0.50m).Build();
            var item2 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();
            var item3 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();
            var item4 = new ItemBuilder().WithSku("B15").WithPrice(0.30m).Build();
            var item5 = new ItemBuilder().WithSku("C40").WithPrice(0.60m).Build();
            var item6 = new ItemBuilder().WithSku("A99").WithPrice(0.50m).Build();
            var item7 = new ItemBuilder().WithSku("A99").WithPrice(0.50m).Build();

            var offer = new SpecialOffer { Sku = "B15", Price = 0.45m, Quantity = 2 };
            var offer2 = new SpecialOffer { Sku = "A99", Price = 1.30m, Quantity = 3 };

            // this does require the offer to be added before scanning.
            // However gives flexibility that you can add offers rather than them being set in the Checkout itself.
            _itemUnderTest.AddSpecialOffer(offer);
            _itemUnderTest.AddSpecialOffer(offer2);

            _itemUnderTest.Scan(item1);
            _itemUnderTest.Scan(item2);
            _itemUnderTest.Scan(item3);
            _itemUnderTest.Scan(item4);
            _itemUnderTest.Scan(item5);
            _itemUnderTest.Scan(item6);
            _itemUnderTest.Scan(item7);

            _itemUnderTest.Total().ShouldEqual(2.65m);
        }
    }
}
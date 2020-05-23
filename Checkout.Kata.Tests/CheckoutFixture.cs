using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
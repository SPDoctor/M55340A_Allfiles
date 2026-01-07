using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Tests.Models
{
    [TestClass]
    public class ShirtTest
    {
        [TestMethod]
        public void IsGetFormattedTaxedPriceReturnsCorrectly()
        {
            Shirt shirt = new Shirt
            {
                Price = 10F,
                Tax = 1.2F
            };

            string taxedPrice = shirt.GetFormattedTaxedPrice();

            Assert.AreEqual("$12.00", taxedPrice);
        }
    }
}
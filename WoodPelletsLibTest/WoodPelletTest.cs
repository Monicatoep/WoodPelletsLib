using WoodPelletsLib;

namespace WoodPelletsLibTest
{
    [TestClass]
    public class WoodPelletTest
    {
        private WoodPellet woodPellet = new() { Id = 1, Brand = "Good", Price = 5000, Quality = 5 };
        private WoodPellet woodPelletBrandNull = new() { Id = 1, Brand = null, Price = 5000, Quality = 5 };
        private WoodPellet woodPelletBrandTooShort = new() { Id = 1, Brand = "G", Price = 5000, Quality = 5 };
        private WoodPellet woodPelletQualityNotGood = new() { Id = 1, Brand = "GoodBrand", Price = 5000, Quality = 6 };
        private WoodPellet woodPelletQualityNotGood2 = new() { Id = 1, Brand = "GoodBrand", Price = 5000, Quality = 6 };

        [TestMethod()]
        public void ValidateBrandTest()
        {
            woodPellet.ValidateBrand();
            Assert.ThrowsException<ArgumentNullException>(() => woodPelletBrandNull.ValidateBrand());
            Assert.ThrowsException<ArgumentException>(() => woodPelletBrandTooShort.ValidateBrand());
        }

        public void ValidateQualityTest()
        {
            woodPellet.ValidateQuality();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityNotGood.ValidateQuality());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityNotGood2.ValidateQuality());
        }
    }
}
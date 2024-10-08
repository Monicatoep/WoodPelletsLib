using WoodPelletsLib;

namespace WoodPelletsLibTest
{
    [TestClass]
    public class WoodPelletTest
    {
        private WoodPellet woodPellet = new() { Id = 10, Brand = "Good", Price = 5000, Quality = 5 };
        private WoodPellet woodPelletBrandNull = new() { Id = 11, Brand = null, Price = 5000, Quality = 5 };
        private WoodPellet woodPelletBrandTooShort = new() { Id = 12, Brand = "G", Price = 5000, Quality = 5 };
        private WoodPellet woodPelletQualityNotGood = new() { Id = 13, Brand = "GoodBrand", Price = 5000, Quality = 6 };
        private WoodPellet woodPelletQualityNotGood2 = new() { Id = 14, Brand = "GoodBrand", Price = 5000, Quality = 0 };

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


        //Tester positive gr�nsev�rdier p� Quality med DataRows
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(4)]
        [DataRow(5)]
        public void ValidateQualitiesTest(int quality)
        {
            woodPellet.Quality = quality;
            woodPellet.ValidateQuality();
        }

        //Tester negative gr�nsev�rdier p� Quality med DataRows
        [TestMethod()]
        [DataRow(0)]
        [DataRow(6)]
        public void ValidateQualitiesFailTest(int quality)
        {
            woodPellet.Quality = quality;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPellet.ValidateQuality());
        }


        [TestMethod()]
        public void ValidateTest()
        {
            woodPellet.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => woodPelletBrandNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => woodPelletBrandTooShort.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityNotGood.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityNotGood2.Validate());
        }
    }
}
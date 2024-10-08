namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Brand)}={Brand}, {nameof(Price)}={Price.ToString()}, {nameof(Quality)}={Quality.ToString()}}}";
        }

        public void ValidateBrand()
        {
            if (Brand == null) throw new ArgumentNullException("Brand is null");
            if (Brand.Length < 2) throw new ArgumentException("Brand must be at least 2 characters: " + Brand);
        }

        public void ValidatePrice()
        {
            if (Price < 0) throw new ArgumentOutOfRangeException("Price year must be a positive number: " + Price);
        }

        public void ValidateQuality()
        {
            if (Quality < 1 || Quality > 5) throw new ArgumentOutOfRangeException("Quality must be between 1 and 5: " + Quality);
        }

        public void Validate()
        {
            ValidateBrand();
            ValidatePrice();
            ValidateQuality();
        }




    }
}

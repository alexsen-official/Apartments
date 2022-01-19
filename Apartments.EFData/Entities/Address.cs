namespace EFData.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        
        public Apartment Apartment { get; set; }
    }
}
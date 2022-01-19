namespace EFData.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
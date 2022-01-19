using System.Collections.Generic;

namespace EFData.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        
        public Kind Kind { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public Owner Owner { get; set; }
        public Provider Provider { get; set; }
        
        public List<Amenity> Amenities { get; set; }
        
        public bool? PetsAllowed { get; set; }
        public decimal Price { get; set; }

        public Apartment()
        {
            Amenities = new List<Amenity>();
        }
    }
}
using System.Collections.Generic;

namespace Apartments.Data.Entities
{
    public class ApartmentInfo
    {
        public int Id { get; set; }
        public Kind? Kind { get; set; }
        public Address? Address { get; set; }
        public Owner? Owner { get; set; }
        public Provider? Provider { get; set; }
        public List<Amenity> Amenities { get; set; }
        public bool? PetsAllowed { get; set; }
        public decimal Price { get; set; }
    }
}
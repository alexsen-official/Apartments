using System.Collections.Generic;

namespace Apartments.Data.Entities
{
    public class Information
    {
        public Apartment Apartment { get; set; }
        public Kind? Kind { get; set; }
        public Address? Address { get; set; }
        public Owner? Owner { get; set; }
        public Provider? Provider { get; set; }
        public List<Amenity> Amenities { get; set; }
    }
}
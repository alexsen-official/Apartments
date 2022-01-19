using System.Collections.Generic;

namespace EFData.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Apartment> Apartments { get; set; }

        public Amenity()
        {
            Apartments = new List<Apartment>();
        }
    }
}
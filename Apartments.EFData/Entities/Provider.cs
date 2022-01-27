using System.Collections.Generic;

namespace EfData.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Apartment> Apartments { get; set; }
        
        public Provider()
        {
            Apartments = new List<Apartment>();
        }
    }
}
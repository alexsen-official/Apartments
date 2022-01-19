using System.Collections.Generic;

namespace EFData.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Apartment> Apartments { get; set; }
    }
}
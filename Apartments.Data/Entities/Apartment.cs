using System.Collections.Generic;

namespace Apartments.Data.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public int? KindId { get; set; }
        public int? AddressId { get; set; }
        public int? OwnerId { get; set; }
        public int? ProviderId { get; set; }
        public bool? PetsAllowed { get; set; }
        public decimal Price { get; set; }
    }
}
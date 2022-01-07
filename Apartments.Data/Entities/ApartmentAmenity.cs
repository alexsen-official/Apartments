using Microsoft.EntityFrameworkCore;

namespace Apartments.Data.Entities
{
    [Keyless]
    public class ApartmentAmenity
    {
        public int ApartmentId { get; set; }
        public int AmenityId { get; set; }
    }
}
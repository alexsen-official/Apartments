using System.Collections.Generic;

namespace Apartments.Models.ViewModel
{
    public class ApartmentViewModel
    {
        public int Id { get; set; }
        public KindViewItem? Kind { get; set; }
        public AddressViewItem? Address { get; set; }
        public OwnerViewItem? Owner { get; set; }
        public ProviderViewItem? Provider { get; set; }

        public List<AmenityViewItem> Amenities { get; set; }
        public bool? PetsAllowed { get; set; }
        public decimal Price { get; set; }
    }
}
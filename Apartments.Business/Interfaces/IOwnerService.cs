using System.Collections.Generic;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IOwnerService
    {
        public IEnumerable<OwnerViewItem> GetOwners();
        public OwnerViewItem GetOwnerById(int id);
    }
}
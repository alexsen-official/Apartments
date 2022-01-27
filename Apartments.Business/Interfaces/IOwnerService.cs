using System.Collections.Generic;
using System.Threading.Tasks;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IOwnerService
    {
        public Task<IEnumerable<OwnerViewItem>> GetOwners();
        public Task<OwnerViewItem> GetOwnerById(int id);
        public Task<IEnumerable<OwnerViewItem>> CreateOwner(OwnerViewItem ownerViewItem);
        public Task<IEnumerable<OwnerViewItem>> UpdateOwner(OwnerViewItem ownerViewItem);
        public Task<IEnumerable<OwnerViewItem>> DeleteOwner(int id);
    }
}
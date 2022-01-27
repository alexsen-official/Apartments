using System.Collections.Generic;
using System.Threading.Tasks;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IProviderService
    {
        public Task<IEnumerable<ProviderViewItem>> GetProviders();
        public Task<ProviderViewItem> GetProviderById(int id);
        public Task<IEnumerable<ProviderViewItem>> CreateProvider(ProviderViewItem providerViewItem);
        public Task<IEnumerable<ProviderViewItem>> UpdateProvider(ProviderViewItem providerViewItem);
        public Task<IEnumerable<ProviderViewItem>> DeleteProvider(int id);
    }
}
using System.Collections.Generic;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IProviderService
    {
        public IEnumerable<ProviderViewItem> GetProviders();
        public ProviderViewItem GetProviderById(int id);
        public IEnumerable<ProviderViewItem> CreateProvider(ProviderViewItem providerViewItem);
        public IEnumerable<ProviderViewItem> UpdateProvider(ProviderViewItem providerViewItem);
        public IEnumerable<ProviderViewItem> DeleteProvider(int id);
    }
}
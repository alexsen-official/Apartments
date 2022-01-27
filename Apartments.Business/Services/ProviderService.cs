using System.Linq;
using System.Collections.Generic;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using EfData.Entities;
using EfData.Interfaces;

namespace Apartment.Business.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }
        
        public IEnumerable<ProviderViewItem> GetProviders()
        {
            IEnumerable<Provider> providers = _providerRepository.GetProviders();

            return providers.Select(provider => 
                new ProviderViewItem 
                {
                    Id = provider.Id,
                    Name = provider.Name
                });
        }
        
        public ProviderViewItem GetProviderById(int id)
        {
            Provider provider = _providerRepository.GetProviderById(id);
            
            return new ProviderViewItem 
            {
                Id = provider.Id,
                Name = provider.Name
            };
        }

        public IEnumerable<ProviderViewItem> CreateProvider(ProviderViewItem providerViewItem)
        {
            Provider provider = new()
            {
                Id = providerViewItem.Id,
                Name = providerViewItem.Name
            };
            
            _providerRepository.CreateProvider(provider);
            return GetProviders();
        }
        
        public IEnumerable<ProviderViewItem> UpdateProvider(ProviderViewItem providerViewItem)
        {
            Provider provider = new()
            {
                Id = providerViewItem.Id,
                Name = providerViewItem.Name
            };
            
            _providerRepository.UpdateProvider(provider);
            return GetProviders();
        }
        
        public IEnumerable<ProviderViewItem> DeleteProvider(int id)
        {
            _providerRepository.DeleteProvider(id);
            return GetProviders();
        }
    }
}
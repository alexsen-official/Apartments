using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<IEnumerable<ProviderViewItem>> GetProviders()
        {
            var providers = await _providerRepository.GetProviders();

            return providers.Select(provider => 
                new ProviderViewItem 
                {
                    Id = provider.Id,
                    Name = provider.Name
                });
        }
        
        public async Task<ProviderViewItem> GetProviderById(int id)
        {
            var provider = await _providerRepository.GetProviderById(id);
            
            return new ProviderViewItem 
            {
                Id = provider.Id,
                Name = provider.Name
            };
        }

        public async Task<IEnumerable<ProviderViewItem>> CreateProvider(ProviderViewItem providerViewItem)
        {
            Provider provider = new()
            {
                Id = providerViewItem.Id,
                Name = providerViewItem.Name
            };
            
            await _providerRepository.CreateProvider(provider);
            return await GetProviders();
        }
        
        public async Task<IEnumerable<ProviderViewItem>> UpdateProvider(ProviderViewItem providerViewItem)
        {
            Provider provider = new()
            {
                Id = providerViewItem.Id,
                Name = providerViewItem.Name
            };
            
            await _providerRepository.UpdateProvider(provider);
            return await GetProviders();
        }
        
        public async Task<IEnumerable<ProviderViewItem>> DeleteProvider(int id)
        {
            await _providerRepository.DeleteProvider(id);
            return await GetProviders();
        }
    }
}
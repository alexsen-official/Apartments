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
            return GetProviders().FirstOrDefault();
        }
    }
}
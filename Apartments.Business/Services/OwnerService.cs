using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using EfData.Entities;
using EfData.Interfaces;

namespace Apartment.Business.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        
        public async Task<IEnumerable<OwnerViewItem>> GetOwners()
        {
            var owners = await _ownerRepository.GetOwners();

            return owners.Select(owner => 
                new OwnerViewItem 
                {
                    Id = owner.Id,
                    FirstName = owner.FirstName,
                    LastName = owner.LastName
                });
        }

        public async Task<OwnerViewItem> GetOwnerById(int id)
        {
            var owner = await _ownerRepository.GetOwnerById(id);
            
            return new OwnerViewItem 
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PhoneNumber = owner.PhoneNumber
            };
        }
        
        public async Task<IEnumerable<OwnerViewItem>> CreateOwner(OwnerViewItem ownerViewItem)
        {
            Owner owner = new()
            {
                Id = ownerViewItem.Id,
                FirstName = ownerViewItem.FirstName,
                LastName = ownerViewItem.LastName,
                PhoneNumber = ownerViewItem.PhoneNumber
            };
            
            await _ownerRepository.CreateOwner(owner);
            return await GetOwners();
        }
        
        public async Task<IEnumerable<OwnerViewItem>> UpdateOwner(OwnerViewItem ownerViewItem)
        {
            Owner owner = new()
            {
                Id = ownerViewItem.Id,
                FirstName = ownerViewItem.FirstName,
                LastName = ownerViewItem.LastName,
                PhoneNumber = ownerViewItem.PhoneNumber
            };
            
            await _ownerRepository.UpdateOwner(owner);
            return await GetOwners();
        }
        
        public async Task<IEnumerable<OwnerViewItem>> DeleteOwner(int id)
        {
            await _ownerRepository.DeleteOwner(id);
            return await GetOwners();
        }
    }
}
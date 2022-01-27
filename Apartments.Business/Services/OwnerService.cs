using System.Linq;
using System.Collections.Generic;
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
        
        public IEnumerable<OwnerViewItem> GetOwners()
        {
            IEnumerable<Owner> owners = _ownerRepository.GetOwners();

            return owners.Select(owner => 
                new OwnerViewItem 
                {
                    Id = owner.Id,
                    FirstName = owner.FirstName,
                    LastName = owner.LastName
                });
        }

        public OwnerViewItem GetOwnerById(int id)
        {
            Owner owner = _ownerRepository.GetOwnerById(id);
            
            return new OwnerViewItem 
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PhoneNumber = owner.PhoneNumber
            };
        }
        
        public IEnumerable<OwnerViewItem> CreateOwner(OwnerViewItem ownerViewItem)
        {
            Owner owner = new()
            {
                Id = ownerViewItem.Id,
                FirstName = ownerViewItem.FirstName,
                LastName = ownerViewItem.LastName,
                PhoneNumber = ownerViewItem.PhoneNumber
            };
            
            _ownerRepository.CreateOwner(owner);
            return GetOwners();
        }
        
        public IEnumerable<OwnerViewItem> UpdateOwner(OwnerViewItem ownerViewItem)
        {
            Owner owner = new()
            {
                Id = ownerViewItem.Id,
                FirstName = ownerViewItem.FirstName,
                LastName = ownerViewItem.LastName,
                PhoneNumber = ownerViewItem.PhoneNumber
            };
            
            _ownerRepository.UpdateOwner(owner);
            return GetOwners();
        }
        
        public IEnumerable<OwnerViewItem> DeleteOwner(int id)
        {
            _ownerRepository.DeleteOwner(id);
            return GetOwners();
        }
    }
}
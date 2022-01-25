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
            return GetOwners().FirstOrDefault();
        }
    }
}
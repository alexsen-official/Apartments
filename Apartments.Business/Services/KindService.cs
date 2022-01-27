using System.Linq;
using System.Collections.Generic;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using EfData.Entities;
using EfData.Interfaces;

namespace Apartment.Business.Services
{
    public class KindService : IKindService
    {
        private readonly IKindRepository _kindRepository;

        public KindService(IKindRepository kindRepository)
        {
            _kindRepository = kindRepository;
        }
        
        public IEnumerable<KindViewItem> GetKinds()
        {
            IEnumerable<Kind> kinds = _kindRepository.GetKinds();

            return kinds.Select(kind => 
                new KindViewItem 
                {
                    Id = kind.Id,
                    Name = kind.Name
                });
        }

        public KindViewItem GetKindById(int id)
        {
            Kind kind = _kindRepository.GetKindById(id);
            
            return new KindViewItem 
            {
                Id = kind.Id,
                Name = kind.Name
            };
        }
        
        public IEnumerable<KindViewItem> CreateKind(KindViewItem kindViewItem)
        {
            Kind kind = new()
            {
                Id = kindViewItem.Id,
                Name = kindViewItem.Name
            };
            
            _kindRepository.CreateKind(kind);
            return GetKinds();
        }
        
        public IEnumerable<KindViewItem> UpdateKind(KindViewItem kindViewItem)
        {
            Kind kind = new()
            {
                Id = kindViewItem.Id,
                Name = kindViewItem.Name
            };
            
            _kindRepository.UpdateKind(kind);
            return GetKinds();
        }
        
        public IEnumerable<KindViewItem> DeleteKind(int id)
        {
            _kindRepository.DeleteKind(id);
            return GetKinds();
        }

    }
}
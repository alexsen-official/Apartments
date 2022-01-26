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
            
            IEnumerable<Kind> kinds = _kindRepository.CreateKind(kind);
            
            return kinds.Select(k => 
                new KindViewItem 
                {
                    Id = k.Id,
                    Name = k.Name
                });
        }
        
        public IEnumerable<KindViewItem> UpdateKind(KindViewItem kindViewItem)
        {
            Kind kind = new()
            {
                Id = kindViewItem.Id,
                Name = kindViewItem.Name
            };
            
            IEnumerable<Kind> kinds = _kindRepository.UpdateKind(kind);
            
            return kinds.Select(k => 
                new KindViewItem 
                {
                    Id = k.Id,
                    Name = k.Name
                });
        }
        
        public IEnumerable<KindViewItem> DeleteKind(int id)
        {
            IEnumerable<Kind> kinds = _kindRepository.DeleteKind(id);
            
            return kinds.Select(k => 
                new KindViewItem 
                {
                    Id = k.Id,
                    Name = k.Name
                });
        }

    }
}
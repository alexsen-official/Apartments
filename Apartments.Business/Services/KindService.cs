using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<IEnumerable<KindViewItem>> GetKinds()
        {
            var kinds = await _kindRepository.GetKinds();

            return kinds.Select(kind => 
                new KindViewItem 
                {
                    Id = kind.Id,
                    Name = kind.Name
                });
        }

        public async Task<KindViewItem> GetKindById(int id)
        {
            var kind = await _kindRepository.GetKindById(id);
            
            return new KindViewItem 
            {
                Id = kind.Id,
                Name = kind.Name
            };
        }
        
        public async Task<IEnumerable<KindViewItem>> CreateKind(KindViewItem kindViewItem)
        {
            Kind kind = new()
            {
                Id = kindViewItem.Id,
                Name = kindViewItem.Name
            };
            
            await _kindRepository.CreateKind(kind);
            return await GetKinds();
        }
        
        public async Task<IEnumerable<KindViewItem>> UpdateKind(KindViewItem kindViewItem)
        {
            Kind kind = new()
            {
                Id = kindViewItem.Id,
                Name = kindViewItem.Name
            };
            
            await _kindRepository.UpdateKind(kind);
            return await GetKinds();
        }
        
        public async Task<IEnumerable<KindViewItem>> DeleteKind(int id)
        {
            await _kindRepository.DeleteKind(id);
            return await GetKinds();
        }

    }
}
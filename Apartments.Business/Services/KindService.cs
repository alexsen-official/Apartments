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
            return GetKinds().FirstOrDefault();
        }
    }
}
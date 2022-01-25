using System.Collections.Generic;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IKindService
    {
        public IEnumerable<KindViewItem> GetKinds();
        public KindViewItem GetKindById(int id);
    }
}
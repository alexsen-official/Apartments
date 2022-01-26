using System.Collections.Generic;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IKindService
    {
        public IEnumerable<KindViewItem> GetKinds();
        public KindViewItem GetKindById(int id);
        public IEnumerable<KindViewItem> CreateKind(KindViewItem kindViewItem);
        public IEnumerable<KindViewItem> UpdateKind(KindViewItem kindViewItem);
        public IEnumerable<KindViewItem> DeleteKind(int id);
    }
}
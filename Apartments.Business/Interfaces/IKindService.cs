using System.Collections.Generic;
using System.Threading.Tasks;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IKindService
    {
        public Task<IEnumerable<KindViewItem>> GetKinds();
        public Task<KindViewItem> GetKindById(int id);
        public Task<IEnumerable<KindViewItem>> CreateKind(KindViewItem kindViewItem);
        public Task<IEnumerable<KindViewItem>> UpdateKind(KindViewItem kindViewItem);
        public Task<IEnumerable<KindViewItem>> DeleteKind(int id);
    }
}
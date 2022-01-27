using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IKindRepository
    {
        public Task<IEnumerable<Kind>> GetKinds();
        public Task<Kind> GetKindById(int id);
        public Task CreateKind(Kind kind);
        public Task UpdateKind(Kind kind);
        public Task DeleteKind(int id);
    }
}
using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IKindRepository
    {
        public IEnumerable<Kind> GetKinds();
        public Kind GetKindById(int id);
        public IEnumerable<Kind> CreateKind(Kind kind);
        public IEnumerable<Kind> UpdateKind(Kind kind);
        public IEnumerable<Kind> DeleteKind(int id);
    }
}
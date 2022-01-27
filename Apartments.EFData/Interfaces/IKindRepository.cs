using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IKindRepository
    {
        public IEnumerable<Kind> GetKinds();
        public Kind GetKindById(int id);
        public void CreateKind(Kind kind);
        public void UpdateKind(Kind kind);
        public void DeleteKind(int id);
    }
}
using System.Collections.Generic;
using System.Linq;
using EfData.Entities;
using EfData.Interfaces;

namespace EfData.Repositories
{
    public class KindRepository : IKindRepository
    {
        private readonly EfApartmentsContext _context;

        public KindRepository(EfApartmentsContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Kind> GetKinds()
        {
            return _context.Kinds;
        }

        public Kind GetKindById(int id)
        {
            return _context.Kinds.SingleOrDefault(k => k.Id == id);
        }
        
        public void CreateKind(Kind kind)
        {
            _context.Kinds.Add(kind);
            _context.SaveChanges();
        }
        
        public void UpdateKind(Kind kind)
        {
            Kind dbKind = _context.Kinds.SingleOrDefault(k => k.Id == kind.Id);

            if (dbKind == null)
            {
                return;
            }
            
            dbKind.Name = kind.Name;
            dbKind.Apartments = kind.Apartments;

            _context.SaveChanges();
        }
        
        public void DeleteKind(int id)
        {
            Kind dbKind = _context.Kinds.SingleOrDefault(k => k.Id == id);

            if (dbKind == null)
            {
                return;
            }

            _context.Kinds.Remove(dbKind);
            _context.SaveChanges();
        }
    }
}
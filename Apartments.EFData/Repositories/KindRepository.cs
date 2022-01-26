using System.Collections.Generic;
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
            return _context.Kinds.Find(id);
        }
        
        public IEnumerable<Kind> CreateKind(Kind kind)
        {
            _context.Kinds.Add(kind);
            _context.SaveChanges();

            return _context.Kinds;
        }
        
        public IEnumerable<Kind> UpdateKind(Kind kind)
        {
            Kind dbKind = _context.Kinds.Find(kind.Id);

            if (dbKind != null)
            {
                dbKind.Name = kind.Name;
                dbKind.Apartments = kind.Apartments;

                _context.SaveChanges();
            }

            return _context.Kinds;
        }
        
        public IEnumerable<Kind> DeleteKind(int id)
        {
            Kind dbKind = _context.Kinds.Find(id);

            if (dbKind != null)
            {
                _context.Kinds.Remove(dbKind);
                _context.SaveChanges();
            }

            return _context.Kinds;
        }
    }
}
using System.Linq;
using EFData.Entities;
using System.Collections.Generic;

namespace EFData.Repositories
{
    public class KindRepository
    {
        private readonly EFApartmentsContext _context;

        public KindRepository(EFApartmentsContext context)
        {
            _context = context;
        }
        
        public List<Kind> GetKinds()
        {
            return _context.Kinds.ToList();
        }

        public Kind GetKindById(int id)
        {
            return _context.Kinds.FirstOrDefault(kind => kind.Id == id);
        }
        
        public Kind GetKindByApartmentId(int apartmentId)
        {
            return _context.Kinds.FirstOrDefault(kind => kind.ApartmentId == apartmentId);
        }
    }
}
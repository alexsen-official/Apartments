using System.Linq;
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
            return GetKinds().FirstOrDefault(kind => kind.Id == id);
        }
    }
}
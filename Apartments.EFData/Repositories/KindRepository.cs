using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;
using EfData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfData.Repositories
{
    public class KindRepository : IKindRepository
    {
        private readonly EfApartmentsContext _context;

        public KindRepository(EfApartmentsContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Kind>> GetKinds()
        {
            var kinds = await _context.Kinds.ToListAsync();
            return kinds;
        }

        public async Task<Kind> GetKindById(int id)
        {
            var kind = await _context.Kinds.SingleOrDefaultAsync(k => k.Id == id);
            return kind;
        }
        
        public async Task CreateKind(Kind kind)
        {
            _context.Kinds.Add(kind);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateKind(Kind kind)
        {
            var dbKind = await _context.Kinds.SingleOrDefaultAsync(k => k.Id == kind.Id);

            if (dbKind == null)
            {
                return;
            }
            
            dbKind.Name = kind.Name;
            dbKind.Apartments = kind.Apartments;

            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteKind(int id)
        {
            var dbKind = await _context.Kinds.SingleOrDefaultAsync(k => k.Id == id);

            if (dbKind == null)
            {
                return;
            }

            _context.Kinds.Remove(dbKind);
            await _context.SaveChangesAsync();
        }
    }
}
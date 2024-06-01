using Microsoft.EntityFrameworkCore;

using Tattoo.Data;
using Tattoo.Entities;
using Tattoo.Repositories.Interfaces;

namespace Tattoo.Repositories
{
    public class TattooStyleRepository : ITattooStyleRepository
    {
        private readonly ApplicationDbContext _context;

        public TattooStyleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TattooStyle>> FindAll()
        {
            return await _context.TattooStyles
                .ToListAsync();
        }

        public async Task<TattooStyle?> FindById(long id)
        {
            return await _context.TattooStyles
                .FirstOrDefaultAsync(ts => ts.Id == id);
        }

        public async Task<TattooStyle> Save(TattooStyle tattooStyle)
        {
            await _context.TattooStyles.AddAsync(tattooStyle);
            await _context.SaveChangesAsync();
            return tattooStyle;
        }

        public async Task<TattooStyle> Update(TattooStyle tattooStyle)
        {
            _context.TattooStyles.Update(tattooStyle);
            await _context.SaveChangesAsync();
            return tattooStyle;
        }

        public async Task Delete(TattooStyle tattooStyle)
        {
            _context.TattooStyles.Remove(tattooStyle);
            await _context.SaveChangesAsync();
        }
    }
}

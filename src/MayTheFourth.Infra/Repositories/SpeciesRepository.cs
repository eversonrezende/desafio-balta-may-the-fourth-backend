using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.Repositories
{
    public class SpeciesRepository : BaseRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<bool> AnyAsync()
            => await _appDbContext.Planets.AnyAsync();

        public async Task SaveAsync(Species species, CancellationToken cancellationToken)
        {
            await _appDbContext.Species.AddAsync(species);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PagedList<Species>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _appDbContext.Species.AsQueryable();
            return await GetPagedAsync(query, pageNumber, pageSize);
        }

        public async Task<int> CountItemsAsync()
        => await _appDbContext.Species.CountAsync();


        public async Task<Species?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _appDbContext.Species
            .Include(x => x.Films)
            .Include(x => x.People)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}

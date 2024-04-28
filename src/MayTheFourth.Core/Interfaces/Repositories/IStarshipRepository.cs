using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IStarshipRepository
{
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken);
    Task SaveAsync(Starship starship, CancellationToken cancellationToken);
    Task<Starship?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Starship?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task<int> CountTotalItemsAsync();
    Task<PagedList<Starship>?> GetAllAsync(int pageNumber, int pageSize);
}

using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IPlanetRepository
{
    Task<bool> AnyAsync(string name, string gravity);
    Task<int> CountTotalItemsAsync();
    Task<bool> DeletePlanetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Planet>?> GetAllAsync(int page, int pageSize);
    Task<Planet?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Planet?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task SaveAsync(Planet planet, CancellationToken cancellationToken);
}

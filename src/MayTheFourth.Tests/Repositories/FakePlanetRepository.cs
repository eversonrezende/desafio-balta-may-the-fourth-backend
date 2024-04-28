using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;

namespace MayTheFourth.Tests.Repositories;

public class FakePlanetRepository : IPlanetRepository
{
    public readonly List<Planet> _planets;

    public FakePlanetRepository()
    {
        _planets = new List<Planet>()
        {
            new Planet { Id = Guid.NewGuid(), Name = "Tatooine", Gravity = "1.0x", Slug = "tatooine" },
            new Planet { Id = Guid.NewGuid(), Name = "Dagobah", Gravity = "0.9g", Slug = "dagobah" },
            new Planet { Id = Guid.NewGuid(), Name = "Endor", Gravity = "0.8g", Slug = "endor" },
            new Planet { Id = Guid.NewGuid(), Name = "Coruscant", Gravity = "Normal", Slug = "coruscant" },
            new Planet { Id = Guid.NewGuid(), Name = "Hoth", Gravity = "1.2g", Slug = "hoth" },
        };
    }

    public Task<bool> AnyAsync(string name, string gravity)
    {
        return Task.FromResult(_planets.Any(x => x.Name == name && x.Gravity.Equals(gravity)));
    }

    public async Task SaveAsync(Planet planet, CancellationToken cancellationToken)
    {
        _planets.Add(planet);
    }

    public Task<Planet?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_planets.FirstOrDefault(x => x.Id == id));
    }

    public async Task<Planet?> GetBySlugAsync(string slug, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(slug))
            return null;

        var lowerCaseSlug = slug.ToLowerInvariant();
        return await Task.FromResult(_planets.FirstOrDefault(x => x.Slug == lowerCaseSlug));
    }

    public Task<bool> DeletePlanetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var planet = _planets.FirstOrDefault(x => x.Id == id);
        if (planet != null)
        {
            _planets.Remove(planet);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<int> CountTotalItemsAsync()
    {
        return Task.FromResult(_planets.Count);
    }

    public async Task<PagedList<Planet>?> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _planets.AsQueryable();
        return await GetPagedAsync(query, pageNumber, pageSize);
    }

    private static Task<PagedList<T>> GetPagedAsync<T>(IQueryable<T> source, int pageNumber, int pageSize)
        => Task.FromResult(new PagedList<T>(pageNumber, pageSize, source.Count(), source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()));
}

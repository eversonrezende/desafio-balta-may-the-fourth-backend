using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IVehicleRepository
{
    Task<bool> AnyAsync(string name, string model);
    Task<int> CountTotalItemsAsync();
    Task<bool> DeleteVehicleByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedList<Vehicle>?> GetAllAsync(int pageNumber, int pageSize);
    Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Vehicle?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task SaveAsync(Vehicle vehicle, CancellationToken cancellationToken);
}

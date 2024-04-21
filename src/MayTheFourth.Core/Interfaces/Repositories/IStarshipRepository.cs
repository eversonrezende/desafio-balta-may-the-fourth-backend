﻿using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IStarshipRepository
{
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken);
    Task<List<Starship>?> GetAllStarshipsAsync();
    Task SaveAsync(Starship starship, CancellationToken cancellationToken);
}

﻿using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IPlanetRepository
{
    Task<bool> AnyAsync(string name, string gravity);
    Task<List<Planet>?> GetAllPlanets();
    Task SaveAsync(Planet planet, CancellationToken cancellationToken);
}
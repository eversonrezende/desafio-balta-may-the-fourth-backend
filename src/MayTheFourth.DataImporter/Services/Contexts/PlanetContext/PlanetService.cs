using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.DataImporter.DTOs;
using MayTheFourth.DataImporter.Services.Contexts.SharedContext;
using MayTheFourth.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MayTheFourth.DataImporter.Services.Contexts.PlanetContext
{
    public class PlanetService : IEntityService
    {
        private readonly IPlanetRepository _planetRepository;
        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public async Task ImportAsync(string jsonList, CancellationToken cancellationToken)
        {
            List<PlanetDTO> planets = new();
            planets = JsonSerializer.Deserialize<List<PlanetDTO>>(jsonList)!;

            // Cadastrar 
            foreach (var planetDTO in planets)
            {
                await _planetRepository.SaveAsync(planetDTO.ToPlanet(), cancellationToken);
            }
        }
    }
}

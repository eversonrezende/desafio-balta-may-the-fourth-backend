using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.DataImporter.DTOs;
using MayTheFourth.DataImporter.Extensions;
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
        private List<PlanetDTO> _planets = new();
        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public void LoadList(string jsonList)
            => _planets = JsonSerializer.Deserialize<List<PlanetDTO>>(jsonList)!;

        public async Task ImportAsync(CancellationToken cancellationToken)
        {
            // Cadastrar 
            foreach (var planetDTO in _planets)
            {
                await _planetRepository.SaveAsync(planetDTO.ToPlanet(), cancellationToken);
            }
        }

        public async Task<bool> IsEmpty() => !await _planetRepository.AnyAsync();        
    }
}

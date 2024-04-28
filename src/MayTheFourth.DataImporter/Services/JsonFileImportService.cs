using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.DataImporter.DTOs;
using MayTheFourth.DataImporter.Services.Contexts.PersonContext;
using MayTheFourth.DataImporter.Services.Contexts.PlanetContext;
using MayTheFourth.DataImporter.Services.Contexts.SharedContext;
using MayTheFourth.Infra.Data;
using MayTheFourth.Infra.DTOs;
using MayTheFourth.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.DataImporter.Services
{
    public class JsonFileImportService : IDataImportService
    {
        private readonly PlanetService _planetService;
        private readonly PersonService _personService;

        public string ResourceFileName { get; set; } = string.Empty;

        public JsonFileImportService(PlanetService planetService, PersonService personService)
        {
            _planetService = planetService;
            _personService = personService;
        }
        private async Task<bool> IsDatabaseEmpty()
        {
            return await _planetService.IsEmpty()
                & await _personService.IsEmpty();
        }

        public async Task ImportDataAsync(CancellationToken cancellationToken)
        {
            if (!await IsDatabaseEmpty()) return;

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(ResourceFileName)!)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string jsonString = reader.ReadToEnd();
                        using (JsonDocument doc = JsonDocument.Parse(jsonString))
                        {
                            JsonElement root = doc.RootElement;
                            foreach (JsonElement element in root.EnumerateArray())
                            {
                                var endpoint = element.GetProperty("Endpoint").GetString();
                                JsonElement data = element.GetProperty("Data");
                                JsonElement results = data.GetProperty("results");
                                switch (endpoint)
                                {
                                    case "people":
                                        _personService.LoadList(results.GetRawText());
                                        break;

                                    case "planets":
                                        _planetService.LoadList(results.GetRawText());
                                        break;

                                    //case "films":
                                    //    films = JsonSerializer.Deserialize<List<FilmDTO>>(results.GetRawText())!;
                                    //    break;

                                    //case "species":
                                    //    speciesList = JsonSerializer.Deserialize<List<SpeciesDTO>>(results.GetRawText())!;
                                    //    break;

                                    //case "starships":
                                    //    starships = JsonSerializer.Deserialize<List<StarshipDTO>>(results.GetRawText())!;
                                    //    break;

                                    //case "vehicles":
                                    //    vehicles = JsonSerializer.Deserialize<List<VehicleDTO>>(results.GetRawText())!;
                                    //    break;
                                }
                            }
                        }
                    }

                }

                // Planet tem que ser o primeiro, porque os outros têm referência pra ele
                await _planetService.ImportAsync(cancellationToken);
                await _personService.ImportAsync(cancellationToken);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

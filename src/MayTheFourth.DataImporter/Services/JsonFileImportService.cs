using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.DataImporter.Services.Contexts.PlanetContext;
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
        private readonly IPlanetRepository _planetRepository;

        public string ResourceFileName { get; private set; } = string.Empty;

        public JsonFileImportService(string resourceFileName, IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
            ResourceFileName = resourceFileName;
        }

        public async Task ImportDataAsync(CancellationToken cancellationToken)
        {
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
                                    case "planets":
                                        var planetService = new PlanetService(_planetRepository);
                                        await planetService.ImportAsync(results.GetRawText(), cancellationToken);
                                        break;

                                    case "films":
                                        // TODO
                                        break;
                                }
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

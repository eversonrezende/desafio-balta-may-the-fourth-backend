﻿using MayTheFourth.DataImporter.Services;

namespace MayTheFourth.Api.Extensions
{
    public static class DataImportExtension
    {
        public static void AddDataImport(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDataImportService, JsonFileImportService>();
        }

        public static async Task ImportDataAsync(this WebApplication app, string ResourceFileName)
        {
            using var scope = app.Services.CreateScope();
            var dataImportService = (JsonFileImportService)scope.ServiceProvider.GetRequiredService<IDataImportService>();

            dataImportService.ResourceFileName = ResourceFileName;
            await dataImportService.ImportDataAsync(new CancellationToken());
        }
    }
}
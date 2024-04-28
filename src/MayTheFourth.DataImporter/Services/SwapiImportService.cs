using MayTheFourth.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.DataImporter.Services
{
    public class SwapiImportService : IDataImportService
    {
        private readonly AppDbContext _appDbContext;
        public string Url { get; set; } = string.Empty;

        public SwapiImportService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task ImportDataAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

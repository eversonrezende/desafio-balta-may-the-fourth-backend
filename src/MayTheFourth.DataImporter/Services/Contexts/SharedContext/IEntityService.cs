using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.DataImporter.Services.Contexts.SharedContext
{
    public interface IEntityService
    {
        Task ImportAsync(string jsonList, CancellationToken cancellationToken);
    }
}

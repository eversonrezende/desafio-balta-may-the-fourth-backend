using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.SearchAll;

public class Response : SharedContext.UseCases.Response
{
    public Response(string message, int status)
    {
        Message = message; 
        Status = status;
    }

    public Response(string message, ResponseData data, int page, int pageSize, int totalItems)
    {
        Message = message;
        Status = 200;
        Data = data;
        Page = page;
        PageSize = pageSize;
        TotalItems = totalItems;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData(List<PlanetSummaryDto> planetList);

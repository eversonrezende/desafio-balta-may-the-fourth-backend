using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.StarshipContext.UseCases.SearchAll;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStarshipRepository _starshipRepository;

    public Handler(IStarshipRepository starshipRepository)
        => _starshipRepository = starshipRepository;

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Get List of Starships
        PagedList<Starship>? starships;
        int countItems = 0;
        try
        {
            if (request.PageSize > 30)
                request.ChangePageSize(30);

            countItems = await _starshipRepository.CountTotalItemsAsync();

            starships = await _starshipRepository.GetAllAsync(request.PageNumber, request.PageSize);

            if (starships!.Count <= 0)
                return new Response("Nenhuma nave encontrada.", 404);

            if (request.PageSize > starships.Count)
                starships.ChangePageSize(countItems);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }

        List<StarshipSummaryDto> starshipSummaryList = starships.Items!
            .Select(starship => new StarshipSummaryDto(starship)).ToList();

        PagedList<StarshipSummaryDto> starshipPagedSummary =
            new(starships.PageNumber, starships.PageSize, countItems, starshipSummaryList);
        #endregion

        #region Response
        return new Response("Lista de naves encontrada.", new ResponseData(starshipPagedSummary));
        #endregion
    }
}

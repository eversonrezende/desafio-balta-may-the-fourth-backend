using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.SearchAll;

public record Request(int page, int pageSize) : IRequest<Response>;
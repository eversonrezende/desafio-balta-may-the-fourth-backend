using MayTheFourth.Core.Contexts.StarshipContext.UseCases.SearchAll;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;
using System.Net;

namespace MayTheFourth.Tests.Contexts.StarshipContext.UseCases;

[TestClass]
public class SearchAllTests
{
    private readonly IStarshipRepository _starshipRepository;
    private readonly Handler _handler;

    public SearchAllTests()
    {
        _starshipRepository = new FakeStarshipRepository();
        _handler = new(_starshipRepository);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Error_404_When_StarshipList_Is_Empty()
    {
        var starshipRepository = new FakeStarshipRepository();
        starshipRepository._starships.Clear();

        var pageNumber = 1;
        var pageSize = 10;
        var handler = new Handler(starshipRepository);
        var request = new Request(pageNumber, pageSize);

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.AreEqual(((int)HttpStatusCode.NotFound), response.Status);
        Assert.AreEqual(false, response.IsSuccess);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Error_When_PageNumber_Request_Is_Greater_Than_Total_Pages_Available()
    {
        var pageNumber = 100;
        var pageSize = 10;
        var request = new Request(pageNumber, pageSize);

        var response = await _handler.Handle(request, new CancellationToken());

        Assert.AreEqual(false, response.IsSuccess);
        Assert.AreEqual(((int)HttpStatusCode.BadRequest), response.Status);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Succeed_When_SpaceshipList_Contains_Exacly_Three_Starships()
    {
        var pageNumber = 1;
        var pageSize = 10;
        var request = new Request(pageNumber, pageSize);

        var response = await _handler.Handle(request, new CancellationToken());

        Assert.AreEqual(3, response.Data!.Starships.Count, "Expected exactly three starships in the list.");
        Assert.AreEqual(true, response.IsSuccess);
        Assert.AreEqual(((int)HttpStatusCode.OK), response.Status);
    }
}

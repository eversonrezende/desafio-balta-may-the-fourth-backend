using MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchAll;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;

namespace MayTheFourth.Tests.Contexts.FilmContext.UseCases
{
    [TestClass]
    public class SearchAll
    {
        private readonly IFilmRepository _filmRepository;

        public SearchAll()
        {
            _filmRepository = new FakeFilmRepository();
        }

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Should_Return_Exactly_Five_Films()
        {
            var pageNumber = 1;
            var pageSize = 10;
            var handler = new Handler(_filmRepository);
            var request = new Request(pageNumber, pageSize);

            var films = await handler.Handle(request, new CancellationToken());

            Assert.AreEqual(5, films.Data!.PagedSummaryFilms.Count, "Expected exactly five films in the list.");
        }
    }
}

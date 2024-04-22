using MayTheFourth.Api.Extensions;
using MayTheFourth.Api.Extensions.Contexts.FilmContext;
using MayTheFourth.Api.Extensions.Contexts.PersonContext;
using MayTheFourth.Api.Extensions.Contexts.PlanetContext;
using MayTheFourth.Api.Extensions.Contexts.StartshipContext;

var builder = WebApplication.CreateBuilder(args);

builder.AddPlanetContext();
builder.AddStarshipContext();
builder.AddFilmContext();
builder.AddPersonContext();
builder.AddDbContext();
builder.AddMediatR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPlanetEndpoints();
app.MapStarshipEndpoints();
app.MapFilmEndpoints();
app.MapPersonEndpoints();

app.Run();
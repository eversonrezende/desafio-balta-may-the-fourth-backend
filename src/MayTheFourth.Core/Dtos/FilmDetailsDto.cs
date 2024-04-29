﻿using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class FilmDetailsDto
{
    public FilmDetailsDto(Film film)
    {
        Id = film.Id;
        Title = film.Title;
        Slug = film.Slug;
        EpisodeId = film.EpisodeId;
        OpeningCrawl = film.OpeningCrawl;
        Director = film.Director;
        Producer = film.Producer;
        ReleaseDate = film.ReleaseDate;
        Created = film.Created;
        Edited = film.Edited;
        SpeciesList = film.SpeciesList.Select(species => new SpeciesSummaryDto
        {
            Id = species.Id,
            Name = species.Name,
            Slug = species.Slug,
            Language = species.Language,
            Designation = species.Designation,
            Classification = species.Classification,
        }).ToList();
        Starships = film.Starships.Select(starship => new StarshipSummaryDto
        {
            Id = starship.Id,
            Name = starship.Name,
            Slug = starship.Slug,
            Model = starship.Model,
            Manufacturer = starship.Manufacturer
        }).ToList();
        Vehicles = film.Vehicles.Select(vehicle => new VehicleSummaryDto
        {
            Id = vehicle.Id,
            Name = vehicle.Name,
            Slug = vehicle.Slug,
            Model = vehicle.Model,
            Manufacturer = vehicle.Manufacturer
        }).ToList();
        Characters = film.Characters.Select(characters => new PersonSummaryDto
        {
            Id = characters.Id,
            Name = characters.Name,
            Slug = characters.Slug,
            BirthYear = characters.BirthYear,
            Gender = characters.Gender,
            HomeworldId = characters.HomeworldId
        }).ToList();
        Planets = film.Planets
            .Select(planet => new PlanetSummaryDto(planet)).ToList();
    }

    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public int EpisodeId { get; set; }
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }

    public List<SpeciesSummaryDto> SpeciesList { get; set; } = [];
    public List<StarshipSummaryDto> Starships { get; set; } = [];
    public List<VehicleSummaryDto> Vehicles { get; set; } = [];
    public List<PersonSummaryDto> Characters { get; set; } = [];
    public List<PlanetSummaryDto> Planets { get; set; } = [];
}

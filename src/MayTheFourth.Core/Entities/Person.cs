﻿using MayTheFourth.Core.Contexts.SharedContext.Entities;
using System.Text.Json.Serialization;

namespace MayTheFourth.Core.Entities;

public class Person : Entity
{
    public Person()
    {
        Slug = Name.ToLower().Replace(" ", "-");    
    }

    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public int Height { get; set; }
    public string Mass { get; set; } = string.Empty;
    public string SkinColor { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }

    public Planet? Homeworld { get; set; }
    public Guid HomeworldId { get; set; }

    public List<Film> Films { get; set; } = [];
    public List<Species> Species { get; set; } = [];
    public List<Starship> Starships { get; set; } = [];
    public List<Vehicle> Vehicles { get; set; } = [];
}

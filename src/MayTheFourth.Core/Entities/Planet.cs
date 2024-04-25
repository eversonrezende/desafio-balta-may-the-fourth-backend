﻿using MayTheFourth.Core.Contexts.SharedContext.Entities;

namespace MayTheFourth.Core.Entities;

public class Planet : Entity
{
    public Planet()
    {
        Slug = Name.ToLower().Replace(" ", "-");    
    }

    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public int Diameter { get; set; }
    public int RotationPeriod { get; set; }
    public int OrbitalPeriod { get; set; }
    public string Gravity { get; set; } = string.Empty;
    public int Population { get; set; }
    public string Climate { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty;
    public string SurfaceWater { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }

    public List<Person> Residents { get; set; } = [];
    public List<Film> Films { get; set; } = [];
}

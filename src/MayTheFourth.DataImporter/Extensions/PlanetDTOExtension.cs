using MayTheFourth.Core.Entities;
using MayTheFourth.DataImporter.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.DataImporter.Extensions
{
    public static class PlanetDTOExtension
    {
        public static Planet ToPlanet(this PlanetDTO dto)
        {
            var planet = new Planet
            {
                Name = dto.Name,
                Diameter = int.TryParse(dto.Diameter!, out int parsedDiameter) ? parsedDiameter : 0,
                RotationPeriod = int.TryParse(dto.RotationPeriod, out int parsedRotationPeriod) ? parsedRotationPeriod : 0,
                OrbitalPeriod = int.TryParse(dto.OrbitalPeriod!, out int parsedOrbitalPeriod) ? parsedOrbitalPeriod : 0,
                Gravity = dto.Gravity!,
                Population = int.TryParse(dto.Population!, out int parsedPopulation) ? parsedOrbitalPeriod : 0,
                Climate = dto.Climate!,
                Terrain = dto.Terrain!,
                SurfaceWater = dto.SurfaceWater!,
                Url = dto.Url!,
                Created = dto.Created,
                Edited = dto.Edited,
                Slug = dto.Name.ToLower().Replace(" ", "-"),
                Residents = new(),
                Films = new()
            };
            return planet;
        }

    }
}

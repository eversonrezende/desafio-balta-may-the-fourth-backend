using MayTheFourth.Core.Entities;
using MayTheFourth.DataImporter.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.DataImporter.Extensions
{
    public static class PersonDTOExtension
    {
        public static Person ToPerson(this PersonDTO dto)
        {

            var person = new Person
            {
                Name = dto.Name,
                Slug = dto.Name.ToLower().Replace(" ", "-"),
                BirthYear = dto.BirthYear,
                EyeColor = dto.EyeColor,
                Gender = dto.Gender,
                HairColor = dto.HairColor,
                Height = int.TryParse(dto.Height, out int parsedDtoHeight) ? parsedDtoHeight : 0,
                Mass = dto.Mass,
                SkinColor = dto.SkinColor,
                Url = dto.Url,
                Created = dto.Created,
                Edited = dto.Edited
            };

            return person;
        }

    }
}

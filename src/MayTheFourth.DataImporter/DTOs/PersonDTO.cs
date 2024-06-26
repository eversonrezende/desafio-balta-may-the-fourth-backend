﻿using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.DataImporter.DTOs
{
    public class PersonDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; } = string.Empty;

        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; } = string.Empty;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public string Height { get; set; } = string.Empty;

        [JsonPropertyName("mass")]
        public string Mass { get; set; } = string.Empty;

        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }

        [JsonPropertyName("homeworld")]
        public string Homeworld { get; set; } = string.Empty;

        [JsonPropertyName("films")]
        public List<string> Films { get; set; } = [];

        [JsonPropertyName("species")]
        public List<string> Species { get; set; } = [];

        [JsonPropertyName("starships")]
        public List<string> Starships { get; set; } = [];

        [JsonPropertyName("vehicles")]
        public List<string> Vehicles { get; set; } = [];

        public Person ToPerson()
        {

            var person = new Person
            {
                Name = Name,
                Slug = Name.ToLower().Replace(" ", "-"),
                BirthYear = BirthYear,
                EyeColor = EyeColor,
                Gender = Gender,
                HairColor = HairColor,
                Height = int.TryParse(Height, out int parsedDtoHeight) ? parsedDtoHeight : 0,
                Mass = Mass,
                SkinColor = SkinColor,
                Url = Url,
                Created = Created,
                Edited = Edited
            };

            return person;
        }


    }
}

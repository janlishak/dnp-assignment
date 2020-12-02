using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ass1.Models
{

    public class Person
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [NotNull]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [NotNull]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [ValidHairColor]
        [JsonPropertyName("hairColor")]
        public string HairColor { get; set; }
        [NotNull]
        [ValidEyeColor]
        [JsonPropertyName("eyeColor")]
        public string EyeColor { get; set; }
        [NotNull, Range(0, 125)]
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [NotNull, Range(1, 250)]
        [JsonPropertyName("weight")]
        public float Weight { get; set; }
        [NotNull, Range(30, 250)]
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [NotNull]
        [JsonPropertyName("sex")]
        public string Sex { get; set; }

        public void Update(Person toUpdate)
        {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColor = toUpdate.HairColor;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColor = toUpdate.EyeColor;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
        }

    }

}
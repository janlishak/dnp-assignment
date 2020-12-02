﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace Ass1.Models
{
    public class Adult
    {
        [JsonPropertyName("jobTitle")]
        public string JobTitle { get; set; }
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
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public void Update(Adult toUpdate)
        {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColor = toUpdate.HairColor;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColor = toUpdate.EyeColor;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
            JobTitle = toUpdate.JobTitle;
        }
        //public void Update(Adult toUpdate)
        //{
          //  JobTitle = toUpdate.JobTitle;
            //base.Update(toUpdate);
        //}   

    }

    public class ValidHairColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"blond", "red", "brown", "black",
            "white", "grey", "blue", "green", "leverpostej"}.ToList();
            if (valid == null || valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
        }
    }

    public class ValidEyeColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"brown", "grey", "green", "blue",
            "amber", "hazel"}.ToList();
            if (valid != null && valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid hair colors are: Brown, Grey, Green, Blue, Amber, Hazel");
        }
    }

}
    
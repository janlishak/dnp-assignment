using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAssignment.Models
{
       
        public class Interest
        {
            [Key]
            public string Type { get; set; }

            [JsonIgnore]
            public List<ChildInterest> ChildInterests { get; set; }

        }
    }

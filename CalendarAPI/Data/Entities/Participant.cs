using CalendarAPI.Helpers.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Entities
{
    public class Participant
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartingTime { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FinalTime { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public Role Role { get; set; }
    }
}

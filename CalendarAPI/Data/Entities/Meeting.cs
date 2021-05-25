using CalendarAPI.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Entities
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public virtual Participant InterviewerId { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }


        [Required]
        public virtual Participant CandidateId { get; set; }
    }
}

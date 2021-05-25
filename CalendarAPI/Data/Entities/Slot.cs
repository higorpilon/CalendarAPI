using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Entities
{
    public class Slot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        


        public int InterviewerId { get; set; }
        public virtual Participant Interviewer { get; set; }



        public int CandidadeId { get; set; }
        public virtual Participant CandidateId { get; set; }
    }
}

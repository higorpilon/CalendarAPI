using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Entities
{
    public class Meeting
    {


        public int Id { get; set; }


        public int InterviewerId { get; set; }
        public virtual Participant Interviewer { get; set; }


        public int SlotId { get; set; }
        public Slot Slot { get; set; }

        public int CandidateId { get; set; }
        public virtual Participant Candidate { get; set; }
    }
}

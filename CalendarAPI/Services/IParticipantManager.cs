using CalendarAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Services
{
    public interface IParticipantManager
    {
        bool AreParticipantsValid(Participant participantOne, Participant participantTwo);

        IQueryable<Slot> PossibleSchedules(Participant participantOne, Participant participantTwo);

        bool IsSingleParticipantValid(Participant participant);

        void CreateAvailability(Participant participant);
    }
}

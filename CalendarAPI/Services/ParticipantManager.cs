using CalendarAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Services
{
    public class ParticipantManager : IParticipantManager
    {
        public bool AreParticipantsValid(Participant participantOne, Participant participantTwo)
        {
            if (participantOne == null || participantTwo == null)
            {
                return false;
            }

            if (participantOne.Role != participantTwo.Role)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsSingleParticipantValid(Participant participant)
        {

            if (participant.StartingTime.Minute == 0)
            {
                if (participant.StartingTime < participant.FinalTime)
                {
                    //to verify if the availability is at least of 1 hour
                    TimeSpan meeting = new TimeSpan(1, 0, 0);

                    if ((participant.FinalTime - participant.StartingTime) >= meeting)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public IQueryable<Meeting> PossibleSchedules(Participant participantOne, Participant participantTwo)
        {
            if (AreParticipantsValid(participantOne, participantTwo))
            {
                var interview = new Interview();
                throw new Exception();

                //TODO
            }
            else
            {
                return null;
            }
        }
    }
}

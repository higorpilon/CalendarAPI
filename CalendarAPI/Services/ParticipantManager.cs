using CalendarAPI.Data.Entities;
using CalendarAPI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Services
{
    public class ParticipantManager : IParticipantManager
    {
        private readonly ISlotRepository _slotRepository;

        public ParticipantManager(ISlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }

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

        public void CreateAvailability(Participant participant)
        {
            DateTime initTime = participant.StartingTime;
            DateTime endTime = participant.FinalTime;


            do
            {

                initTime.AddHours(1); //adicionar 1 hora (tempo de cada reunião)
            } while (initTime < endTime);
        }

        public IQueryable<Slot> PossibleSchedules(Participant participantOne, Participant participantTwo)
        {
            if (AreParticipantsValid(participantOne, participantTwo))
            {
                
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

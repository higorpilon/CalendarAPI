using CalendarAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Repositories
{
    public interface IParticipantRepository
    {

        IQueryable<Participant> GetAll();


        Task<Participant> GetByIdAsync(int id);

        Task CreateAsync(Participant participant);


        Task UpdateAsync(Participant participant);


        Task DeleteAsync(Participant participant);


        Task<bool> ExistAsync(int id);


        //services

        Task<bool> AreParticipantsValid(int participantOne, int participantTwo);

        Task<IEnumerable<string>> PossibleSchedules(int participantOne, int participantTwo);

        bool IsSingleParticipantValid(Participant participant);

        void CreateAvailability(Participant participant);
    }
}

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
    }
}

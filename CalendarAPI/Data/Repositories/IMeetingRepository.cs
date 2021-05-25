using CalendarAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Repositories
{
   public interface IMeetingRepository
    {
        IQueryable<Meeting> GetAll();

        Task<Meeting> GetByInterviewerIdAsync(int id);

        Task<Meeting> GetByIdAsync(int id);

        Task CreateAsync(Meeting meeting);


        Task UpdateAsync(Meeting meeting);


        Task DeleteAsync(Meeting meeting);


        Task<bool> ExistAsync(int id);
    }
}

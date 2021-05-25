using CalendarAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Repositories
{
   public interface ISlotRepository
    {
        IQueryable<Slot> GetAll();


        Task<Slot> GetByDateAsync(DateTime date);

        Task CreateAsync(Slot slot);


        Task UpdateAsync(Slot slot);


        Task DeleteAsync(Slot slot);


        Task<bool> ExistAsync(int id);
    }
}

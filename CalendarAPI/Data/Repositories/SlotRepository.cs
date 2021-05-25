using CalendarAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        private readonly DataContext _context;


        public SlotRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Slot slot)
        {
            await _context.Set<Slot>().AddAsync(slot);
            await SaveAllAsync();
        }

        public async Task DeleteAsync(Slot slot)
        {
            _context.Set<Slot>().Remove(slot);
            await SaveAllAsync();
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Set<Slot>().AnyAsync(e => e.Id == id);
        }

        public IQueryable<Slot> GetAll()
        {
            return _context.Set<Slot>().AsNoTracking();
        }

        public async Task<Slot> GetByDateAsync(DateTime dateTime)
        {
            return await _context.Set<Slot>().AsNoTracking().FirstOrDefaultAsync(e => e.StartTime == dateTime);
        }

        public async Task UpdateAsync(Slot slot)
        {
            _context.Set<Slot>().Update(slot);
            await SaveAllAsync();
        }
    }
}

using CalendarAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly DataContext _context;

        public MeetingRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Meeting meeting)
        {
            await _context.Set<Meeting>().AddAsync(meeting);
            await SaveAllAsync();
        }

        public async Task DeleteAsync(Meeting meeting)
        {
            _context.Set<Meeting>().Remove(meeting);
            await SaveAllAsync();
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Set<Meeting>().AnyAsync(e => e.Id == id);
        }

        public IQueryable<Meeting> GetAll()
        {
            return _context.Set<Meeting>().AsNoTracking();
        }

        public async Task<Meeting> GetByIdAsync(int id)
        {
            return await _context.Set<Meeting>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Meeting meeting)
        {
            _context.Set<Meeting>().Update(meeting);
            await SaveAllAsync();
        }

        public async Task<Meeting> GetByInterviewerIdAsync(int id)
        {
            return await _context.Set<Meeting>().AsNoTracking().FirstOrDefaultAsync(e => e.InterviewerId == id);
        }
    }
}

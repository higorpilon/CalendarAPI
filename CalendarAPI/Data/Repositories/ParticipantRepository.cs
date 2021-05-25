using CalendarAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly DataContext _context;

        public ParticipantRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Participant participant)
        {
            await _context.Set<Participant>().AddAsync(participant);
            await SaveAllAsync();
        }

        public async Task DeleteAsync(Participant participant)
        {
            _context.Set<Participant>().Remove(participant);
            await SaveAllAsync();
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Set<Participant>().AnyAsync(e => e.Id == id);
        }

        public IQueryable<Participant> GetAll()
        {
            return _context.Set<Participant>().AsNoTracking();
        }

        public async Task<Participant> GetByIdAsync(int id)
        {
            return await _context.Set<Participant>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Participant participant)
        {
            _context.Set<Participant>().Update(participant);
            await SaveAllAsync();
        }
    }
}

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





        //services


        public async Task<bool> AreParticipantsValid(int participantOne, int participantTwo)
        {

            var one = await _context.Set<Participant>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == participantOne);

            var two = await _context.Set<Participant>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == participantTwo);

            if (string.IsNullOrEmpty(one.Role) || string.IsNullOrEmpty(two.Role))
            {
                return false;
            }

            if (one.Role == "interviewer")
            {
                if (two.Role == "candidadate")
                {
                    return true;
                }

            }


            if (two.Role == "interviewer")
            {
                if (one.Role == "candidadate")
                {
                    return true;
                }

            }

            return false;
        }

        public bool IsSingleParticipantValid(Participant participant)
        {

            if (participant.StartingTime.Minute == 0 && participant.FinalTime.Minute == 0 && participant.StartingTime > DateTime.Now)
            {
                if (participant.StartingTime.Second == 0 && participant.FinalTime.Second == 0)
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
            }

            return false;
        }

        public async void CreateAvailability(Participant participant)
        {
            DateTime initTime = participant.StartingTime;
            DateTime endTime = participant.FinalTime;

            do
            {
                var slot = _context.Set<Slot>().AsNoTracking().Where(x => x.ParticipantId == participant.Id && x.StartTime == initTime);
                if (slot.Count() == 0)
                {
                    await _context.Set<Slot>().AddAsync(new Slot
                    {
                        StartTime = initTime,
                        ParticipantId = participant.Id
                    });
                }

                initTime = initTime.AddHours(1); //adicionar 1 hora (tempo de cada reunião)
            } while (initTime < endTime);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<string>> PossibleSchedules(int participantOne, int participantTwo)
        {

            var one = await _context.Set<Participant>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == participantOne);

            var two = await _context.Set<Participant>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == participantTwo);

            if (await AreParticipantsValid(one.Id, two.Id))
            {
                List<string> q1 = new List<string>();
                foreach (var item in _context.Set<Slot>().AsNoTracking().Where(x => x.ParticipantId == one.Id))
                {
                    q1.Add(item.StartTime.ToString());
                }
                List<string> q2 = new List<string>();
                foreach (var item in _context.Set<Slot>().AsNoTracking().Where(x => x.ParticipantId == two.Id))
                {
                    q2.Add(item.StartTime.ToString());
                }

                var query = q1.Intersect(q2);
                return query;
            }
            else
            {
                return null;
            }
        }

    }
}

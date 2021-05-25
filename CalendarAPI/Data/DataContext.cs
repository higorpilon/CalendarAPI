using CalendarAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Slot> Slots { get; set; }


        public DbSet<Meeting> Meetings { get; set; }


        public DbSet<Participant> Participants { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}

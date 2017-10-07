using CoreScheduler.Data.Abstracts;
using CoreScheduler.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreScheduler.Data.Repositories
{
    public class AttendeeRepository : EntityBaseRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(SchedulerDbContext context) : base(context)
        {

        }
    }
}

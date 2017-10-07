using CoreScheduler.API.Data;
using CoreScheduler.API.Data.Abstracts;
using CoreScheduler.API.Data.Entities;
using CoreScheduler.API.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreScheduler.API.Data.Repositories
{
    public class AttendeeRepository : EntityBaseRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(SchedulerDbContext context) : base(context)
        {

        }
    }
}

using CoreScheduler.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreScheduler.Data.Abstracts
{
    public interface IScheduleRepository : IEntityBaseRepository<Schedule> { }
    public interface IUserRepository : IEntityBaseRepository<User> { }
    public interface IAttendeeRepository : IEntityBaseRepository<Attendee> { }
}

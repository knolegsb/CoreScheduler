using CoreScheduler.Data.Abstracts;
using CoreScheduler.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreScheduler.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(SchedulerDbContext context) : base(context)
        {

        }
    }
}

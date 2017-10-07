using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreScheduler.API.Data.Abstracts;
using CoreScheduler.API.Data.Entities;
using CoreScheduler.API.ViewModels;
using AutoMapper;
using CoreScheduler.API.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreScheduler.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;
        private IScheduleRepository _scheduleRepository;
        private IAttendeeRepository _attendeeRepository;

        int page = 1;
        int pageSize = 10;
        public UsersController(
            IUserRepository userRepository,
            IScheduleRepository scheduleRepository,
            IAttendeeRepository attendeeRepository)
        {
            _userRepository = userRepository;
            _scheduleRepository = scheduleRepository;
            _attendeeRepository = attendeeRepository;
        }

        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalUsers = _userRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

            IEnumerable<User> _users = _userRepository
                    .AllIncluding(u => u.SchedulesCreated)
                    .OrderBy(u => u.Id)
                    .Skip((currentPage - 1) * currentPageSize)
                    .Take(currentPageSize)
                    .ToList();

            IEnumerable<UserViewModel> _usersVM = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_users);
            Response.AddPagination(page, pageSize, totalUsers, totalPages);
            return new OkObjectResult(_usersVM);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreScheduler.API.ViewModels.Validators
{
    public class ScheduleViewModelValidator : AbstractValidator<ScheduleViewModel>
    {
        public ScheduleViewModelValidator()
        {
            RuleFor(s => s.TimeEnd).Must((start, end) =>
            {
                return DateTimeIsGreater(start.TimeStart, end);
            }).WithMessage("Schedule's End time must be greater than start time");
        }

        private bool DateTimeIsGreater(DateTime start, DateTime end)
        {
            return end > start;
        }
    }
}

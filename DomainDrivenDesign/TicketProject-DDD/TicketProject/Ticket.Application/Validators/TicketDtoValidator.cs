using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.DTOs;

namespace Ticket.Application.Validators
{
    public class TicketDtoValidator: AbstractValidator<TicketDTO>
    {
        public TicketDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("title is required");
            RuleFor(t => t.Description).MinimumLength(10).WithMessage("Description must be at least 10 characters");

        }
    }
}

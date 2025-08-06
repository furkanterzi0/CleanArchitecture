using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entites;

namespace Ticket.Application.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<ETicket>> GetAllAsync();
        Task<ETicket> AddAsync(ETicket ticket);
    }
}

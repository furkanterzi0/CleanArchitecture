using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Interfaces;
using Ticket.Domain.Entites;
using Ticket.Infrastructure.Context;

namespace Ticket.Infrastructure.Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketDbContext _context;

        public TicketService(TicketDbContext context)
        {
            _context = context;
        }
        public async Task<ETicket> AddAsync(ETicket ticket)
        {
            _context.ETickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<IEnumerable<ETicket>> GetAllAsync()
        {
            return await _context.ETickets.ToListAsync();
        }
    }
}

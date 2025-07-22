using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entites;

namespace Ticket.Infrastructure.Context
{
    public class TicketDbContext: DbContext 
    {
        
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) { }

        public DbSet<ETicket> ETickets => Set<ETicket>();
        

    }
}

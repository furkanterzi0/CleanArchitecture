using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entites;
using Ticket.Application.DTOs;

namespace Ticket.Common.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TicketDTO, ETicket>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Open"))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<ETicket, TicketDTO>();
        }
    }
}

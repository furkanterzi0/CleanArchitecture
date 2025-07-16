using MediatR;
using OnionArchDemo.Application.Interfaces.Repositories;
using OnionArchDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Application.Features.Queries
{
    public class GetAllUserQuery: IRequest<List<User>>
    {

    }

    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly IUserRepository userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetAllAsync();
        }
    }
}

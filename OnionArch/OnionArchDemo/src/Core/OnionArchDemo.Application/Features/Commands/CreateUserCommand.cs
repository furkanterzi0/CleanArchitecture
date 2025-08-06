using MediatR;
using OnionArchDemo.Application.Interfaces.Repositories;
using OnionArchDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Application.Features.Commands
{
    public class CreateUserCommand: IRequest<int>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.name,
                Email = request.email
            };
            await userRepository.AddAsync(user);
            return user.Id;
        }
    }
}

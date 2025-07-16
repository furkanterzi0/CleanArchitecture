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
    public class GetAllProductQuery: IRequest<List<Product>>
    {

    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IProductRepository productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetAllAsync();
        }
    }



}

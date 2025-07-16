using AutoMapper;
using MediatR;
using ProductApp.Application.dto;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    // Query tanımı
    public class GetAllProductQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {
    }

    // Handler ayrı tanımlandı
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ServiceResponse<List<ProductViewDto>>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();

            var viewModel = mapper.Map<List<ProductViewDto>>(products);
         
            return new ServiceResponse<List<ProductViewDto>>(viewModel);
        }
    }
}

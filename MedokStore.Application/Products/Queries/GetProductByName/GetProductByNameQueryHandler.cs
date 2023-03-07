using AutoMapper;
using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Products.Queries.GetProductByName
{
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, ProductDetailsByNameVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductByNameQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ProductDetailsByNameVm> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Product.FirstOrDefaultAsync(product => product.Name == request.Name, cancellationToken);
            if (entity == null || entity.Name != request.Name)
            {
                throw new NotFoundException(nameof(Category), request.Name);
            }
            return _mapper.Map<ProductDetailsByNameVm>(entity);
        }
    }
}

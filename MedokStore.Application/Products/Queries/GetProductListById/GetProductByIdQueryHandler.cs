using AutoMapper;
using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Products.Queries.GetProductListById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailsByIdVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ProductDetailsByIdVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Product.FirstOrDefaultAsync(product => product.ProductId == request.ProductId, cancellationToken);
            if (entity == null || entity.ProductId != request.ProductId)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
            return _mapper.Map<ProductDetailsByIdVm>(entity); ;
        }
    }
}

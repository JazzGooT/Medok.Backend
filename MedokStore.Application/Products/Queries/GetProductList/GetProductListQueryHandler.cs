using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MedokStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductListQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var categoryId = await _dbContext.Category.FirstOrDefaultAsync(category => category.Name == request.CategoryName);
            var productQuery = await _dbContext.Product
                .Where(product => product.CategoryId == categoryId.CategoryId)
                .ProjectTo<ProductLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProductListVm { ProductList = productQuery };
        }
    }
}

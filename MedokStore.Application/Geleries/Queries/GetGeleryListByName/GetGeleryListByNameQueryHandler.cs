using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MedokStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Geleries.Queries.GetGeleryListByName
{
    public class GetGeleryListByNameQueryHandler : IRequestHandler<GetGeleryListByNameQuery, GeleryListByNameVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGeleryListByNameQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GeleryListByNameVm> Handle(GetGeleryListByNameQuery request, CancellationToken cancellationToken)
        {
            var productId = await _dbContext.Product.FirstOrDefaultAsync(product => product.Name == request.ProductName);
            var geleryQuery = await _dbContext.Gelery
                .Where(gelery => gelery.ProductId == productId.ProductId)
                .ProjectTo<GeleryLookUpByNameDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new GeleryListByNameVm { GeleryList = geleryQuery };
        }
    }
}

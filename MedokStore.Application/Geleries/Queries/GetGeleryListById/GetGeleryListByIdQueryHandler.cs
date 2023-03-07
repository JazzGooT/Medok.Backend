using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MedokStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Geleries.Queries.GetGeleryListById
{
    public class GetGeleryListByIdQueryHandler : IRequestHandler<GetGeleryListByIdQuery, GeleryListByIdVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGeleryListByIdQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GeleryListByIdVm> Handle(GetGeleryListByIdQuery request, CancellationToken cancellationToken)
        {
            var geleryQuery = await _dbContext.Gelery
                .Where(gelery => gelery.ProductId == request.ProductId)
                .ProjectTo<GeleryLookUpByIdDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new GeleryListByIdVm { GeleryList = geleryQuery };
        }
    }
}

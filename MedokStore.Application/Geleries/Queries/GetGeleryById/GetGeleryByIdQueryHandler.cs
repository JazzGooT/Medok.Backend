using AutoMapper;
using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Geleries.Queries.GetGeleryById
{
    public class GetGeleryByIdQueryHandler : IRequestHandler<GetGeleryByIdQuery, GeleryDetailsByIdVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGeleryByIdQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GeleryDetailsByIdVm> Handle(GetGeleryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Gelery.FirstOrDefaultAsync(gelery => gelery.GeleryId == request.GeleryId, cancellationToken);

            if (entity == null || entity.GeleryId != request.GeleryId)
            {
                throw new NotFoundException(nameof(Gelery), request.GeleryId);
            }
            return _mapper.Map<GeleryDetailsByIdVm>(entity);
        }
    }
}
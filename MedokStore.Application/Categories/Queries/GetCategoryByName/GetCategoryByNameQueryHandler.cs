using AutoMapper;
using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Categories.Queries.GetCategoryByName
{
    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, CategoryDetailsByNameVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCategoryByNameQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<CategoryDetailsByNameVm> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Category.FirstOrDefaultAsync(category => category.Name == request.Name, cancellationToken);

            if (entity == null || entity.Name != request.Name)
            {
                throw new NotFoundException(nameof(Category), request.Name);
            }
            return _mapper.Map<CategoryDetailsByNameVm>(entity);
        }
    }
}

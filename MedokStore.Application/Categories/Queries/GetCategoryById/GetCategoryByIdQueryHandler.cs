using AutoMapper;
using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDetailsByIdVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<CategoryDetailsByIdVm> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Category.FirstOrDefaultAsync(category => category.CategoryId == request.CategoryId, cancellationToken);

            if (entity == null || entity.CategoryId != request.CategoryId)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }
            return _mapper.Map<CategoryDetailsByIdVm>(entity);
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MedokStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Categories.Queries.GetCategoryByLanguage
{
    public class GetCategoryListByLanguageQueryHandler : IRequestHandler<GetCategoryListByLanguageQuery, CategoryListByLanguageVm>
    {
        private readonly IMedokStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCategoryListByLanguageQueryHandler(IMedokStoreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<CategoryListByLanguageVm> Handle(GetCategoryListByLanguageQuery request, CancellationToken cancellationToken)
        {
            var categoryQuery = await _dbContext.Category
                .Where(category => category.Language == request.Language)
                .ProjectTo<CategoryLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new CategoryListByLanguageVm { CategoryList = categoryQuery };
        }
    }
}

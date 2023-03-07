using MediatR;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public CreateCategoryCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categories = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = request.Name,
                Language = request.Language,
            };
            await _dbContext.Category.AddAsync(categories, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

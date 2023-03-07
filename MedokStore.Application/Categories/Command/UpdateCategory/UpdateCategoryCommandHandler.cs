using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public UpdateCategoryCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Category.FirstOrDefaultAsync(category => category.CategoryId == request.CategoryId, cancellationToken);
            if (entity == null || entity.CategoryId != request.CategoryId)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }
            entity.Name = request.Name;
            entity.Language = request.Language;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

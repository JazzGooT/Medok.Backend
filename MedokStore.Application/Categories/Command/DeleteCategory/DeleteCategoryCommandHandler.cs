using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public DeleteCategoryCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Category.FirstOrDefaultAsync(category => category.CategoryId == request.CatetoryId, cancellationToken);
            if (entity == null || entity.CategoryId != request.CatetoryId)
            {
                throw new NotFoundException(nameof(Category), request.CatetoryId);
            }
            _dbContext.Category.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

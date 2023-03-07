using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Products.Cammand.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public DeleteProductCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Product.FirstOrDefaultAsync(product => product.ProductId == request.ProductId, cancellationToken);
            if (entity == null || entity.ProductId != request.ProductId)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
            _dbContext.Product.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

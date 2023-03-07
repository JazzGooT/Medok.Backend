using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Products.Cammand.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public UpdateProductCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var entity = await _dbContext.Product.FirstOrDefaultAsync(product => product.ProductId == product.ProductId, cancellationToken);

            if (entity == null || entity.ProductId != request.ProductId)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
            if (request.Name != null) entity.Name = request.Name;
            if (request.Price != 0) entity.Price = request.Price;
            if (request.Description != null) entity.Description = request.Description;
            if (request.Compound != null) entity.Compound = request.Compound;
            if (request.Capacity != null) entity.Capacity = request.Capacity;
            if (request.CompleteSet != null) entity.CompleteSet = request.CompleteSet;
            if (request.Image != null)
            {
                var memoryStream = new MemoryStream();
                request.Image.CopyTo(memoryStream);
                entity.Image = memoryStream.ToArray();
                memoryStream.Close();
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

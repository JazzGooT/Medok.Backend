using MediatR;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Products.Cammand.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public CreateProductCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var memoryStream = new MemoryStream();
            request.Image.CopyTo(memoryStream);
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Compound = request.Compound,
                Capacity = request.Capacity,
                CompleteSet = request.CompleteSet,
                Image = memoryStream.ToArray()
            };
            await _dbContext.Product.AddAsync(product, cancellationToken);
            foreach (var item in request.Gelery)
            {
                memoryStream = new MemoryStream();
                item.CopyTo(memoryStream);
                var gelery = new Gelery
                {
                    GeleryId = Guid.NewGuid(),
                    Name = item.FileName,
                    Image = memoryStream.ToArray(),
                    ProductId = product.ProductId
                };
                await _dbContext.Gelery.AddAsync(gelery, cancellationToken);
                memoryStream.Close();
            }
            memoryStream.Close();
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

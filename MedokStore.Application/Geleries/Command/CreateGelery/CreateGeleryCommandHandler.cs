using MediatR;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;

namespace MedokStore.Application.Geleries.Command.CreateGelery
{
    public class CreateGeleryCommandHandler : IRequestHandler<CreateGeleryCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public CreateGeleryCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(CreateGeleryCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Image)
            {
                var memoryStream = new MemoryStream();
                item.CopyTo(memoryStream);
                var gelery = new Gelery
                {
                    GeleryId = Guid.NewGuid(),
                    Name = item.FileName,
                    Image = memoryStream.ToArray(),
                    ProductId = request.ProductId
                };
                await _dbContext.Gelery.AddAsync(gelery, cancellationToken);
                memoryStream.Close();
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

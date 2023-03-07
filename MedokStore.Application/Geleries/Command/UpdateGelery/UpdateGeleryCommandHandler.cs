using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Geleries.Command.UpdateGelery
{
    public class UpdateGeleryCommandHandler : IRequestHandler<UpdateGeleryCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public UpdateGeleryCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateGeleryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Gelery.FirstOrDefaultAsync(gelery => gelery.GeleryId == request.GeleryId, cancellationToken);
            if (entity == null || entity.GeleryId != request.GeleryId)
            {
                throw new NotFoundException(nameof(Gelery), request.GeleryId);
            }
            if (request.Name != null) entity.Name = request.Image.FileName;
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

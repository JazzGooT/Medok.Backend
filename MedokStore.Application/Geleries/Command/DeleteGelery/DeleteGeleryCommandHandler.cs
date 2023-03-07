using MediatR;
using MedokStore.Application.Common.Exceptions;
using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Geleries.Command.DeleteGelery
{
    public class DeleteGeleryCommandHandler : IRequestHandler<DeleteGeleryCommand>
    {
        private readonly IMedokStoreDbContext _dbContext;
        public DeleteGeleryCommandHandler(IMedokStoreDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteGeleryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Gelery.FirstOrDefaultAsync(gelery => gelery.GeleryId == request.GeleryId, cancellationToken);
            if (entity == null || entity.GeleryId != request.GeleryId)
            {
                throw new NotFoundException(nameof(Gelery), request.GeleryId);
            }
            _dbContext.Gelery.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

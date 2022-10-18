using CQRSPattern.Repository.AppDBContext;
using CQRSPattern.Repository.CQRS.Command.Request;
using CQRSPattern.Repository.CQRS.Commands.Response;
using MediatR;

namespace CQRSPattern.Repository.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly AppDbContext _context;

        public DeleteProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == request.Id);

            _context.Remove(product);

            await _context.SaveChangesAsync();

            return new DeleteProductCommandResponse()
            {
                IsSuccess = true
            };
        }
    }
}
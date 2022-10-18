using CQRSPattern.Core.Entities;
using CQRSPattern.Repository.AppDBContext;
using CQRSPattern.Repository.CQRS.Commands.Request;
using CQRSPattern.Repository.CQRS.Commands.Response;
using MediatR;

namespace CQRSPattern.Repository.CQRS.Handlers.CommandHandlers
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly AppDbContext _context;

        public UpdateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            _context.Products.Update(new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity
            });

            await _context.SaveChangesAsync();

            return new UpdateProductCommandResponse()
            {
                IsSuccess = true
            };
        }
    }
}
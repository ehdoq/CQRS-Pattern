using CQRSPattern.Core.Entities;
using CQRSPattern.Repository.AppDBContext;
using CQRSPattern.Repository.CQRS.Command.Request;
using CQRSPattern.Repository.CQRS.Commands.Response;
using MediatR;

namespace CQRSPattern.Repository.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly AppDbContext _context;

        public CreateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();

            _context.Products.Add(new Product()
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.Now,
            });

            await _context.SaveChangesAsync();

            return new CreateProductCommandResponse()
            {
                IsSuccess = true,
                ProductId = id,
            };
        }
    }
}
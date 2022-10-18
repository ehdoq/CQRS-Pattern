using CQRSPattern.Repository.CQRS.Commands.Response;
using MediatR;

namespace CQRSPattern.Repository.CQRS.Command.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
using CQRSPattern.Repository.CQRS.Commands.Response;
using MediatR;

namespace CQRSPattern.Repository.CQRS.Commands.Request
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
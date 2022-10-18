using CQRSPattern.Repository.CQRS.Commands.Response;
using MediatR;

namespace CQRSPattern.Repository.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
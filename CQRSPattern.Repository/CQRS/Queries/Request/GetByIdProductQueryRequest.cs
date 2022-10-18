using CQRSPattern.Repository.CQRS.Queries.Response;
using MediatR;

namespace CQRSPattern.Repository.CQRS.Queries.Request
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
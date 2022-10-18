using CQRSPattern.Repository.CQRS.Queries.Response;
using MediatR;

namespace CQRSPattern.Repository.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {

    }
}
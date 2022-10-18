using CQRSPattern.Repository.AppDBContext;
using CQRSPattern.Repository.CQRS.Queries.Request;
using CQRSPattern.Repository.CQRS.Queries.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPattern.Repository.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly AppDbContext _context;

        public GetAllProductQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            return await _context.Products.Select(product => new GetAllProductQueryResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            }).ToListAsync();
        }
    }
}
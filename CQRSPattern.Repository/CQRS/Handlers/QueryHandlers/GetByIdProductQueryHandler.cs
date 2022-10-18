using CQRSPattern.Repository.AppDBContext;
using CQRSPattern.Repository.CQRS.Queries.Request;
using CQRSPattern.Repository.CQRS.Queries.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPattern.Repository.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetByIdProductQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            return new GetByIdProductQueryResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
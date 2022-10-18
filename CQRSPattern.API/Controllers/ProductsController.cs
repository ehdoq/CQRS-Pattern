using CQRSPattern.Repository.CQRS.Commands.Request;
using CQRSPattern.Repository.CQRS.Commands.Response;
using CQRSPattern.Repository.CQRS.Queries.Request;
using CQRSPattern.Repository.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GetAllProductQueryResponse> allProducts = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(allProducts);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdProductQueryResponse product = await _mediator.Send(new GetByIdProductQueryRequest() { Id = id });
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest requestModel)
        {
            UpdateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteProductCommandResponse response = await _mediator.Send(new DeleteProductCommandRequest() { Id = id });
            return Ok(response);
        }
    }
}
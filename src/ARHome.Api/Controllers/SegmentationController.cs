using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Segmentation;
using ARHome.GenericSubDomain.MediatR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ARHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SegmentationController(IMediator mediator)
            => _mediator = mediator;
        
        [DisableRequestSizeLimit]
        [HttpPost("defineSegments")]
        public async Task<SegmentationResult> DefineSegments(
            [FromBody] SegmentationRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendCommand<SegmentationRequest, SegmentationResult>(request, cancellationToken);
        }
    }
}
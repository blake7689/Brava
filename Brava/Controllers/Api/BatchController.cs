using Brava.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Brava.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchRepository _batchRepository;
        private readonly ILogger<BatchController> _logger;

        public BatchController(IBatchRepository batchRepository, ILogger<BatchController> logger)
        {
            _batchRepository = batchRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBatchJson([FromQuery] string batchNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(batchNumber))
                    return BadRequest(new { error = "Batch number is required." });

                var batch = _batchRepository.GetBatchByBatchNumber(batchNumber);

                if (batch == null)
                    return NotFound(new { error = "Batch not found." });

                return new JsonResult(batch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving batch with number {BatchNumber}", batchNumber);
                return StatusCode(500, new { error = "An unexpected error occurred." });
            }
        }
    }
}
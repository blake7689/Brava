using Brava.Interfaces;
using Brava.Models;
using Brava.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Brava.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchRepository _batchRepository;

        public BatchController(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        [HttpGet]
        public IActionResult GetBatchJson([FromQuery] string batchNumber)
        {
            if (string.IsNullOrWhiteSpace(batchNumber))
                return BadRequest(new { error = "Batch number is required." });

            var batch = _batchRepository.GetBatchByBatchNumber(batchNumber);

            if (batch == null)
                return NotFound(new { error = "Batch not found." });

            //return Ok(batch);
            return new JsonResult(batch);
        }
    }
}

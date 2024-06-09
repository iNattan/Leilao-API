using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LanceController : ControllerBase
    {
        private readonly ILogger<LanceController> _logger;
        private readonly LanceService _lanceService;

        public LanceController(ILogger<LanceController> logger, LanceService lanceService)
        {
            _logger = logger;
            _lanceService = lanceService;
        }

        [HttpPost(Name = "CreateLance")]
        public IActionResult Create([FromBody] Lance lance)
        {
            _lanceService.Add(lance);

            return CreatedAtAction(nameof(Create), new { id = lance.IDLance }, lance);
        }

        [HttpGet(Name = "ListarLance")]
        public IActionResult Get()
        {
            try
            {
                var itensEmLeilao = _lanceService.ListarItensEmLeilao();
                return Ok(itensEmLeilao);
            }
            catch (Exception ex)
            {        
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompradorController : ControllerBase
    {
        private readonly ILogger<CompradorController> _logger;
        private readonly CompradorService _compradorService;

        public CompradorController(ILogger<CompradorController> logger, CompradorService compradorService)
        {
            _logger = logger;
            _compradorService = compradorService;
        }

        [HttpPost(Name = "CreateComprador")]
        public IActionResult Create([FromBody] Comprador comprador)
        {
            _compradorService.Add(comprador);

            return CreatedAtAction(nameof(Create), new { id = comprador.IDComprador }, comprador);
        }
    }
}

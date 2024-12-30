using Microsoft.AspNetCore.Mvc;
using OBSI.Infra.Models;
using OBSI.Infra.Repository;
using OBSLI.Api.Shared;
using Prometheus;

namespace OBSLI.Api.Controllers
{
    public class FornecedorController : Controller
    {
        IFornecedor _fornecedorRepository;
        private readonly ILogger<FornecedorController> _logger;
        private static readonly Counter totalRequest = Metrics.CreateCounter("custom_requests_fornecedor", "Contador de requisições personalizadas");


        public FornecedorController(IFornecedor fornecedorRepository, ILogger<FornecedorController> logger)
        {
            _fornecedorRepository = fornecedorRepository;
            _logger = logger;
        }

        [HttpPost("fonrecedor")]
        public async Task<ActionResult<FornecedorDTO>> FornecedorAdd([FromBody] FornecedorDTO postDTO)
        {
            var fornecedor = postDTO.ToEntity();
            await _fornecedorRepository.Adicionar(fornecedor);
            return Ok(postDTO);
        }

        [HttpGet("fornecedor")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> FornecedorList()
        {
            _logger.LogInformation("Solicitando dados do fornecedor");

            var fornecedores = await _fornecedorRepository.ObterTodos();

            totalRequest.Inc();
            return Ok(fornecedores);

        }

        [HttpGet("fornecedor/{id}")]
        public async Task<ActionResult<Fornecedor>> FornecedorGet(Guid id)
        {

            _logger.LogInformation($"Solicitando dado do fornecedor {id}");

            var fornecedor = await _fornecedorRepository.ObterPorId(id);

            if (fornecedor == null)
            {
                _logger.LogWarning($"Fornecedor {id} não encontrado");
                return NotFound();
            }

            _logger.LogInformation($"Fornecedor {id} encontrado");

            return Ok(fornecedor);
        }
    }
}

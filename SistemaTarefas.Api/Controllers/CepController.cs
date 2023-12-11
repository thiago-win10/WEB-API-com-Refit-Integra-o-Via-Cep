using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Application.Integration.Interfaces;
using SistemaTarefas.Application.Integration.Response;

namespace SistemaTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;
        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> GetListCep(string cep)
        {
            var response = await _viaCepIntegration.ObterDadosViaCep(cep);

            if (response == null)
            {
                return BadRequest("Cep não encontrado");
            }

            return Ok(response);    
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Domain.Entities;
using SistemaTarefas.Domain.InterfacesRepository;
using SistemaTarefas.Infra.Repository;

namespace SistemaTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefasController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> GetAllTarefas()
        {
            List<TarefaModel> tarefas = await _tarefaRepository.GetAllTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> GetById(int id)
        {
            TarefaModel tarefas = await _tarefaRepository.GetById(id);

            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefa)
        {
            TarefaModel tarefaModel = await _tarefaRepository.Register(tarefa);

            return Ok(tarefaModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel result = await _tarefaRepository.Update(tarefaModel, id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<TarefaModel>> Remover(int id)
        {
            bool excluir = await _tarefaRepository.Delete(id);
            return Ok(excluir);
        }
    }
}

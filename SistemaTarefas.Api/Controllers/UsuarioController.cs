using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Domain.Entities;
using SistemaTarefas.Domain.InterfacesRepository;

namespace SistemaTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsers()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.GetAllUsers();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> GetById(int id)
        {
            UsuarioModel usuario = await _usuarioRepository.GetById(id);

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuario)
        {
            UsuarioModel user = await _usuarioRepository.Register(usuario);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuario, int id)
        {
            usuario.Id = id;
            UsuarioModel result = await _usuarioRepository.Update(usuario, id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<UsuarioModel>> Remover(int id)
        {
            bool excluir = await _usuarioRepository.Delete(id);
            return Ok(excluir);
        }

    }
}

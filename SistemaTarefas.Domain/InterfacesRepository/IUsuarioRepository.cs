using SistemaTarefas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefas.Domain.InterfacesRepository
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetAllUsers();
        Task<UsuarioModel> GetById(int id);
        Task<UsuarioModel> Register(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int id);
        Task<bool> Delete(int id);
    }
}

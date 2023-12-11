using SistemaTarefas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefas.Domain.InterfacesRepository
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> GetAllTarefas();
        Task<TarefaModel> GetById(int id);
        Task<TarefaModel> Register(TarefaModel tarefa);
        Task<TarefaModel> Update(TarefaModel tarefa, int id);
        Task<bool> Delete(int id);
    }
}

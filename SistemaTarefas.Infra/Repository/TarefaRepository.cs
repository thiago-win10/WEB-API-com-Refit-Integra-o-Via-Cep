using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Domain.Entities;
using SistemaTarefas.Domain.InterfacesRepository;
using SistemaTarefas.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefas.Infra.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly SistemaTarefasContext _tarefasContext;
        public TarefaRepository(SistemaTarefasContext tarefasContext)
        {
            _tarefasContext = tarefasContext;
        }

        public async Task<List<TarefaModel>> GetAllTarefas()
        {
            return await _tarefasContext.Tarefas.AsNoTracking()
                .Include(x=>x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> GetById(int id)
        {
            return await _tarefasContext.Tarefas
                .Include(x=>x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<TarefaModel> Register(TarefaModel tarefa)
        {
            await _tarefasContext.AddAsync(tarefa);
            await _tarefasContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> Update(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaModel  = await GetById(id);

            if (tarefaModel == null)
            {
                throw new Exception($"Tarefa do ID {id} nao encontrado");
            }


            tarefaModel.Id = tarefa.Id;
            tarefaModel.Nome = tarefa.Nome;
            tarefaModel.Descricao = tarefa.Descricao;
            tarefaModel.Status = tarefa.Status;
            tarefaModel.UsuarioId = tarefa.UsuarioId;

            _tarefasContext.Update(tarefaModel);
            await _tarefasContext.SaveChangesAsync();

            return tarefaModel;
        }
        public async Task<bool> Delete(int id)
        {
            TarefaModel result = await GetById(id);
            if (result == null)
            {
                throw new Exception($"Tarefa do ID {id} nao encontrado");
            }

            _tarefasContext.Remove(result);
            await _tarefasContext.SaveChangesAsync();

            return true;
        }
    }
}

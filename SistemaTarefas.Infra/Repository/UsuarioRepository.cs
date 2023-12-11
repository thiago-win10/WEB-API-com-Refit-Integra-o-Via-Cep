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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaTarefasContext _context;
        public UsuarioRepository(SistemaTarefasContext context)
        {
            _context = context;
        }
        public async Task<List<UsuarioModel>> GetAllUsers()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }
        public async Task<UsuarioModel> GetById(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Register(UsuarioModel usuario)
        {
             await _context.Usuarios.AddAsync(usuario);
             await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
        {
            UsuarioModel result = await GetById(id);
            if (result == null)
            {
                throw new Exception($"Usuario do ID {id} nao encontrado");
            }

            result.Nome = usuario.Nome;
            result.Email = usuario.Email;

            _context.Usuarios.Update(result);
            await _context.SaveChangesAsync();

            return result;
        }
        public async Task<bool> Delete(int id)
        {
            UsuarioModel result = await GetById(id);
            if (result == null)
            {
                throw new Exception($"Usuario do ID {id} nao encontrado");
            }

            _context.Usuarios.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

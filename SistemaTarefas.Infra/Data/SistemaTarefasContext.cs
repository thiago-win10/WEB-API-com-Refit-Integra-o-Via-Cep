using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Domain.Entities;
using SistemaTarefas.Infra.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefas.Infra.Data
{
    public class SistemaTarefasContext : DbContext
    {
        public SistemaTarefasContext(DbContextOptions<SistemaTarefasContext> options) 
            : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Refit;
using SistemaTarefas.Application.Integration;
using SistemaTarefas.Application.Integration.Interfaces;
using SistemaTarefas.Application.Integration.Refit;
using SistemaTarefas.Domain.InterfacesRepository;
using SistemaTarefas.Infra.Data;
using SistemaTarefas.Infra.Repository;

namespace SistemaTarefas.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Banco de Dados
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaTarefasContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("SistemaTarefasContextBD")));

            //Injeção Dependencias
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

            builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

            //Refit Integração
            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

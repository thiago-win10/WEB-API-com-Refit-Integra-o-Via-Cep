using SistemaTarefas.Application.Integration.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefas.Application.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}

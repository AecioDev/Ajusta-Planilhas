using Gestao_Planilhas.Classes.Entidades;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Planilhas.Classes.Dados.Interfaces
{
    // Repositório de usuário para consultas específicas
    public interface IUserRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByNameAsync(string name);
        Task<Usuario> GetFlagAsync();
        Task<Usuario> GetByEmailAsync(string email);
    }
}

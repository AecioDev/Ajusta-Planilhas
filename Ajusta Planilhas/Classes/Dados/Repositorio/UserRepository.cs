using Gestao_Planilhas.Classes.Dados.Interfaces;
using Gestao_Planilhas.Classes.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gestao_Planilhas.Classes.Dados.Repositorio
{
    // Implementação do repositório de usuário
    public class UserRepository : Repository<Usuario>, IUserRepository
    {
        public UserRepository(GPContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.UserEmail == email);
        }

        public async Task<Usuario> GetByNameAsync(string name)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.UserNome == name);
        }

        public async Task<Usuario> GetFlagAsync()
        {
            return await _context.Usuarios.Where(u => u.UserFlag != "").FirstOrDefaultAsync();
        }
        public async Task UpdateFlagsAsync()
        {
            var usuariosFlag = _context.Usuarios.Where(u => !string.IsNullOrEmpty(u.UserFlag));

            foreach (var user in usuariosFlag)
            {
                user.UserFlag = ""; // Limpa a flag de todos 
            }

            //_context.Entry(usuariosFlag).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

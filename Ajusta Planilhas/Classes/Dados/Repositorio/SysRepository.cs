using Gestao_Planilhas.Classes.Dados.Interfaces;
using Gestao_Planilhas.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Planilhas.Classes.Dados.Repositorio
{
    public class SysRepository  : Repository<SYS0000>, ISysRepository
    {
        public SysRepository(GPContext context) : base(context)
        {
        }
    }
}

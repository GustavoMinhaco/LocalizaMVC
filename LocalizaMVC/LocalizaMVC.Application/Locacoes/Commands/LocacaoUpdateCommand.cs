using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Locacoes.Commands
{
    public class LocacaoUpdateCommand : LocacaoCommand
    {
        public int Id { get; set; }
    }
}

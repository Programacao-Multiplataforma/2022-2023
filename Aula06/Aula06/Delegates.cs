using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula06
{
    //necessário às mensagens (notificações) do Model para as Views
    public delegate void MetodosComInt(int valor);

    // extra - para as notificações de erro
    public delegate void MetodosComString(string mensagem);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula08
{
    //As classes exceção da aplicação devem derivar sempre de ApplicationException
    public class TextoInvalidoException : ApplicationException
    {
        public TextoInvalidoException(string msg)
            : base(msg)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula11e12
{
    public class OperacaoInvalidaException : ApplicationException
    {
        public OperacaoInvalidaException(string msg)
            : base(msg)
        {

        }
    }
}

using System;

namespace Aula10
{
    public class OperacaoInvalidaException : ApplicationException
    {
        public OperacaoInvalidaException(string msg)
            : base(msg)
        {

        }
    }
}

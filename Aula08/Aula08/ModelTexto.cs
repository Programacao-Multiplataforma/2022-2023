using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula08
{
    public class ModelTexto
    {
        //Propriedade que representa a lista de textos válidos (Estado da aplicação)
        public List<string> Lista { get; private set; }

        //Declaração de event associado ao delegate multicast
        public event MetodosComString TextoValido;

        public ModelTexto()
        {
            //Instanciar/Inicializar lista de textos válidos
            Lista = new List<string>();
        }

        public void ValidarTexto(string texto)
        {
            //Exemplo: Gera exceção "FormatException" caso o texto não seja número
            //Convert.ToInt16(texto);

            //Validação do texto inserido
            if (texto.Length > 0 && texto.Length <= 5)
            {
                texto = texto.ToUpper();
                Lista.Add(texto);

                //Lança notificação de texto válido (Event)
                if (TextoValido != null)
                    TextoValido(texto);
            }
            else
            {
                //Lança exceção caso o texto seja inválido
                //throw new ArgumentOutOfRangeException();
                //throw new ArgumentOutOfRangeException("", "Erro! Número de carateres inválido [1-5].");
                throw new TextoInvalidoException("Erro! Número de carateres inválido [1-5].");
            }
        }
    }
}

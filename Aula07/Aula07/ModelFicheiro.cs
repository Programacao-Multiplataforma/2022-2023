using System.IO;

namespace Aula07
{
    public class ModelFicheiro
    {
        //Propriedade armazena conteúdo do ficheiro
        public string Texto { get; private set; }

        //Declaração de evento
        public event MetodosSemParametros LeituraTerminada;
        public event MetodosSemParametros EscritaTerminada;

        public void LeituraFicheiro(string fich)
        {
            //Leitura do ficheiro
            StreamReader sr = new StreamReader(fich);
            Texto = sr.ReadToEnd();
            sr.Close();

            //Notificação de leitura de ficheiro terminada (Ligação Model->View)
            if (LeituraTerminada != null)
                LeituraTerminada();
        }

        public void EscritaFicheiro(string fich, string texto)
        {
            //Escrita no ficheiro
            StreamWriter sw = new StreamWriter(fich);
            sw.Write(texto);
            sw.Close();

            //Notificação de escrita no ficheiro terminada (Ligação Model->View)
            if (EscritaTerminada != null)
                EscritaTerminada();
        }
    }
}

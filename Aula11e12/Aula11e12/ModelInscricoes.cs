using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aula11e12
{
    public class ModelInscricoes
    {
        //Cria estrutura de dados para armazenar os alunos (Estado da aplicação)
        public Dictionary<string, Aluno> Dados { get; private set; }

        //Declaração dos eventos
        public event MetodosSemParametros? LeituraTerminada;
        public event MetodosSemParametros? EscritaTerminada;
        public event MetodosSemParametros? InscricaoAtualizada;

        public ModelInscricoes()
        {
            //Instancia estrutura de dados representada pela propriedade
            Dados = new Dictionary<string, Aluno>();
        }

        public void LeituraFicheiroTXT(string ficheiro)
        {
            //Remove dados antigos da estrutura de dados
            Dados.Clear();

            //Abre stream (ficheiro de texto) em modo de leitura
            StreamReader sr = new StreamReader(ficheiro);

            //enquanto tiver linhas de texto para ler
            while (!sr.EndOfStream)
            {
                //Lê linha de texto
                string line = sr.ReadLine();
                //Separa campos pelo ;
                string[] dadosAluno = line.Split(';');

                //Criado objeto aluno com os seus dados
                Aluno al = new Aluno(dadosAluno[0], dadosAluno[1], dadosAluno[2]);

                //Verifica se o aluno está inscrito
                if (dadosAluno[3] == "Inscrito")
                    al.Inscrito = true;
                else
                    al.Inscrito = false;

                //Adiciona aluno à estrutura de dados
                Dados.Add(al.Numero, al);
            }

            //Fecha a stream (ficheiro de texto)
            sr.Close();

            //Lança notificação (event) quando termina leitura de dados (Model->View)
            if (LeituraTerminada != null)
                LeituraTerminada();

        }

        public void EscritaFicheiroXML(string ficheiro)
        {
            //Verifica estado da aplicação e lança exceção caso não existam dados na estrutura para gravar em ficheiro
            if (Dados.Count == 0)
                throw new OperacaoInvalidaException("Não existem dados para serem guardados!");

            //Criar document xml na memória com a estrutura base
            XDocument doc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                                            new XComment("Listagem de alunos"),
                                            new XElement("Alunos",
                                                new XElement("Inscritos"),
                                                new XElement("NaoInscritos")));

            //Obtem cada aluno da estrutura de dados do Model
            foreach (Aluno al in Dados.Values)
            {
                //Cria estrutura xml para cada aluno
                XElement novo = new XElement("Aluno", new XAttribute("Numero", al.Numero),
                                                new XElement("Nome", al.Nome),
                                                new XElement("Curso", al.Curso));

                //Verifica se aluno inscrito e associa estrutura xml do aluno aos Inscritos ou NaoInscritosuur
                if (al.Inscrito == true)
                    doc.Element("Alunos").Element("Inscritos").Add(novo);
                else
                    doc.Element("Alunos").Element("NaoInscritos").Add(novo);
            }

            //Guarda a estrutura xml completa da memória para o ficheiro
            doc.Save(ficheiro);

            //Lança notificação (evento) quando termina escrita em ficheiro
            if (EscritaTerminada != null)
                EscritaTerminada();
        }

        public void LeituraFicheiroXML(string ficheiro)
        {
            //Remove dados antigos da estrutura de dados
            Dados.Clear();

            //Carrega conteúdo ficheiro xml para memória
            XDocument doc = XDocument.Load(ficheiro);

            //Efetua expressão de consulta LINQ relativa aos alunos inscritos
            var registo = from al in doc.Element("Alunos").Element("Inscritos").Descendants("Aluno") select al;

            //Percorre o xml dos alunos inscritos
            foreach (var campos in registo)
            {
                //Cria objeto aluno com os dados respetivos
                Aluno novoAluno = new Aluno(campos.Attribute("Numero").Value,
                                            campos.Element("Nome").Value,
                                            campos.Element("Curso").Value);

                novoAluno.Inscrito = true;

                //Adiciona aluno à estrutura de dados (estado da aplicação)
                Dados.Add(novoAluno.Numero, novoAluno);
            }

            //Efetua expressão de consulta LINQ relativa aos alunos não inscritos
            registo = from al in doc.Element("Alunos").Element("NaoInscritos").Descendants("Aluno") select al;

            //Percorre o xml dos alunos não inscritos
            foreach (var campos in registo)
            {
                //Cria objeto aluno com os dados respetivos
                Aluno novoAluno = new Aluno(campos.Attribute("Numero").Value,
                                            campos.Element("Nome").Value,
                                            campos.Element("Curso").Value);

                novoAluno.Inscrito = false;

                //Adiciona aluno à estrutura de dados (estado da aplicação)
                Dados.Add(novoAluno.Numero, novoAluno);
            }

            //Lança notificação (evento) quando termina leitura de dados
            if (LeituraTerminada != null)
                LeituraTerminada();
        }

        public void EscritaFicheiroTXT(string ficheiro)
        {
            //Verifica estado da aplicação e lança exceção caso não existam dados na estrutura para gravar em ficheiro
            if (Dados.Count == 0)
                throw new OperacaoInvalidaException("Não existem dados para serem guardados!");

            //Abre stream (ficheiro de texto) em modo de escrita
            StreamWriter sw = new StreamWriter(ficheiro);

            //Percorre os alunos da estrutura de dados
            foreach (Aluno al in Dados.Values)
            {
                //Formata informação do aluno
                string line = al.Numero + ";" + al.Nome + ";" + al.Curso + ";";
                if (al.Inscrito == true)
                    line += "Inscrito";
                else
                    line += "NaoInscrito";

                //Escreve informação do aluno em ficheiro
                sw.WriteLine(line);
            }

            //Fecha o ficheiro
            sw.Close();

            //Lança notificação (evento) quando termina escrita de dados
            if (EscritaTerminada != null)
                EscritaTerminada();
        }

        public void AlteraInscricao(string numero)
        {
            Aluno al;

            //Pesquisa aluno pelo número (value) na estrutura de dados (coleção Dictionary)
            Dados.TryGetValue(numero, out al);

            //Altera inscricao de aluno caso exista
            if (al != null)
                al.Inscrito = !al.Inscrito;

            //Lança notificação (evento) quando termina alteração da inscrição (Model->View)
            if (InscricaoAtualizada != null)
                InscricaoAtualizada();
        }
    }
}

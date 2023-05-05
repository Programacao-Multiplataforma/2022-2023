// See https://aka.ms/new-console-template for more information
using ConsoleApp;

ViewModel _viewModel = new ViewModel();

_viewModel.CarregaFicheiro("FicheiroTexto.txt");

Console.WriteLine("Número de Parágrafos : " + _viewModel.NumeroParagrafos);
Console.WriteLine("Número de Palavras : " + _viewModel.NumeroPalavras);
Console.WriteLine("Número de Carateres : " + _viewModel.NumeroCaracteres);
Console.WriteLine("Número de ocorrências da palavra 'alunos' : " + _viewModel.NumeroOcorrencias("alunos"));

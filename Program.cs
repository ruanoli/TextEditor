using System;
using System.IO;
Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Abrir o arquivo.");
    Console.WriteLine("2 - Criar novo arquivo");
    Console.WriteLine("0 - Sair");

    short option = short.Parse(Console.ReadLine());

    switch(option)
    {
        case 0 : Environment.Exit(0); break;
        case 1 : OpenFile(); break;
        case 2 : Editor(); break;
        default : Menu(); break;
    }
}

static void OpenFile()
{
     Console.Clear();
     Console.WriteLine("Insira o caminho do arquivo.");
     string path = Console.ReadLine();

     using(var file = new StreamReader(path))
     {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
     }
     Console.WriteLine("");
     Console.ReadLine();
     Menu();
}

static void Editor()
{
    Console.Clear();
    Console.WriteLine(@"Digite seu texto abaixo:
    (ESC para sair!)");
    Console.WriteLine("-------------------------");

    string text = string.Empty;

    do
    {
        text += Console.ReadLine();
        text+= Environment.NewLine;
    }
    while(Console.ReadKey().Key != ConsoleKey.Escape);

    Save(text);
}

static void Save(string text)
{
    Console.Clear();
    Console.WriteLine("Informe o caminho que o aqruivo deverá ser salvo.");
    string path = Console.ReadLine();

    using(var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"Arquivo {path} salvo com sucesso.");
    Console.ReadLine();
    Menu();
}
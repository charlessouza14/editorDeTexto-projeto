using System.Collections;
using System.IO;

namespace editorDeTexto
{ 
    internal class Program
    {
        private static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("Qual opção deseja escolher?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar arquivo");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("___________________________");
            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;

            }
        }
        static void Abrir() 
        {
            Console.WriteLine("Qual caminho do arquivo?");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamReader(caminho))
            {
                string texto = arquivo.ReadToEnd();
                Console.WriteLine(texto);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }
        static void Editar()
        {
            Console.WriteLine(" Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("_________________");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);
        } 
        static void Salvar(string texto)
        {
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamWriter(caminho))
            {
                arquivo.Write(texto);
            }

            Console.WriteLine("Arquivo" + caminho + " salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
            
    }
}
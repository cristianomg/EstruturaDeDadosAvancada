using ArvoreGenerica.DataStruct;
using ArvoreGenerica.ProgramStructs;
using System;

namespace ArvoreGenerica
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            bool runApp = true;
            while (runApp)
            {
                Console.WriteLine("Cadastrar pasta Raiz - 1 ");
                Console.WriteLine("Cadastrar pasta ou arquivo- 2");
                Console.WriteLine("Imprimir nome da pasta ou arquivo - 3");
                string opc = Console.ReadLine();
                Console.Clear();
                string nameArchive;
                switch (opc)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Informe o nome da pasta: ");
                            nameArchive = Console.ReadLine();
                            Console.WriteLine("Informe o tamanho da pasta: ");
                            decimal size = Convert.ToDecimal(Console.ReadLine());
                            app.AddArchiveRoot(nameArchive, size);
                        }
                        catch (Exception e) 
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Tente novamente.");
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Informe o nome da pasta pai: ");
                            string nameArchiveFather = Console.ReadLine();
                            Console.WriteLine("Informe o nome da pasta ou arquivo a ser armazenado: ");
                            nameArchive = Console.ReadLine();
                            Console.WriteLine("Informe o tamanho da pasta: ");
                            decimal size = Convert.ToDecimal(Console.ReadLine());
                            app.AddArchiveNode(nameArchiveFather, nameArchive, size);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Tente novamente.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Informe o nome da pasta que deseja pesquisar: ");
                        nameArchive = Console.ReadLine();
                        app.PrintFolderSize(nameArchive);
                        break;
                    case "4":
                        runApp = false;
                        break;
                    default:
                        Console.WriteLine("Opção invalida, tente novamente.");
                        break;
                }

            }
        }
    }
}

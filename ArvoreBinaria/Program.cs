using ArvoreBinaria.DataStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<Cidade> tree = new Tree<Cidade>();
            bool runCode = true;
            while (runCode)
            {
                Console.WriteLine("1 - Incluir cidade:");
                Console.WriteLine("2 - Buscar cidade pelo Id:");
                Console.WriteLine("3 - Listar todas cidades cadastradas: ");
                Console.WriteLine("4 - Parar o programa.");
                Console.WriteLine("Escolha uma opção: ");
                string opc = Console.ReadLine();
                switch(opc)
                {
                    case "1":
                        Console.WriteLine("Infome o id da cidade:");
                        string idCadastro = Console.ReadLine();
                        Console.WriteLine("Infome o nome da cidade:");
                        string cidade = Console.ReadLine();
                        try
                        {
                            uint id = Convert.ToUInt32(idCadastro);
                            tree.Insert(id, new Cidade() { Id = id, Nome = cidade });
                            Console.WriteLine("cadastro realizado.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Infome o id da cidade:");
                        idCadastro = Console.ReadLine();
                        try
                        {
                            uint id = Convert.ToUInt32(idCadastro);
                            Cidade cidadeResult = tree.Search(id);
                            Console.WriteLine("Cidade '" + cidadeResult.Nome + "' encontrada");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            List<Cidade> cidades = tree.Nodes.Select(x => x.Value).ToList();
                            foreach (Cidade c in cidades)
                            {
                                Console.WriteLine(c.Nome);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Nenhum cidade cadastrada.");
                        }
                        break;
                    case "4":
                        runCode = false;
                        break;
                }
            }
        }
    }
}

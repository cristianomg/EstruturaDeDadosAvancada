using ArvoreBinaria.DataStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    class Program2
    {
        static void Main()
        {
            Tree<Cidade> tree = new Tree<Cidade>();
            bool runCode = true;
            while (runCode)
            {
                Console.WriteLine("1 - Incluir cidade:");
                Console.WriteLine("2 - Buscar cidade pelo Id:");
                Console.WriteLine("3 - Percorrer a árvore imprimindo os valores dos nós para as opões pré-ordem, pós - ordem e in -ordem. ");
                Console.WriteLine("4 - Retornar o maior e o menor valor presente na árvore. ");
                Console.WriteLine("5 - Retornar a média dos valores presentes em uma árvore.");
                Console.WriteLine("6 - Retornar o número de nós de uma árvore.");
                Console.WriteLine("7 - Retornar o número de folhas de uma árvore. ");
                Console.WriteLine("8 - Retornar a altura da árvore. ");
                Console.WriteLine("9 - Remover Valor. ");
                Console.WriteLine("10 - Parar o programa.");
                Console.WriteLine("Escolha uma opção: ");
                string opc = Console.ReadLine();
                switch (opc)
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
                            Cidade cidadeResult = tree.Search(id).Value;
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
                            Console.WriteLine("Escolha o tipo de visita:");
                            Console.WriteLine("1 - pre ordem");
                            Console.WriteLine("2 - In ordem");
                            Console.WriteLine("3 - Pos ordem");
                            Enum.VisitType visita;
                            switch (Convert.ToInt16(Console.ReadLine()))
                            {
                                case 1:
                                    visita = Enum.VisitType.PreOrder;
                                    break;
                                case 2:
                                    visita = Enum.VisitType.InOrder;
                                    break;
                                case 3:
                                    visita = Enum.VisitType.PosOrder;
                                    break;
                                default:
                                    visita = Enum.VisitType.PreOrder;
                                    break;
                            }

                            List<Cidade> cidades = tree.VisitTree(visita).Select(x => x.Value).ToList();
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
                        Console.WriteLine(tree.GetMinMaxValues());
                        break;
                    case "5":
                        Console.WriteLine(tree.GetAverage());
                        break;
                    case "6":
                        Console.WriteLine(tree.GetAmountNodes());
                        break;
                    case "7":
                        Console.WriteLine(tree.GetAmountLeaf());
                        break;
                    case "8":
                        Console.WriteLine(tree.GetHeight());
                        break;
                    case "9":
                        try
                        {
                            Console.WriteLine("Insira a chave do item que deseja remover: ");
                            var key = Convert.ToUInt64(Console.ReadLine());
                            tree.RemoveNode(key);
                        }
                        catch
                        {
                            Console.WriteLine("Valor invalido.");
                        }
                        break;
                    case "10":
                        runCode = false;
                        break;
                }
            }
        }
    }
}

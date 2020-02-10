using ArvoreGenerica.DataStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreGenerica.ProgramStructs
{
    class App
    {
        private GenericTree<String, String, Archive> tree; 
        public App()
        {
            this.tree = new GenericTree<String, String, Archive>();
        }

        public void AddArchiveRoot(string nameArchive, decimal size)
        {
            try
            {
                tree.AddRoot(nameArchive, new Archive() { Name = nameArchive.Trim(), Size = size });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddArchiveNode(string nameFolder, string nameArchive, decimal size)
        {
            try
            {
                var folder = tree.SearchFather(nameFolder);
                if (folder != null)
                {
                    tree.AddNode(nameFolder, nameArchive, new Archive() { Name = nameArchive, Size = size });
                }
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintFolderSize(string nameFolder)
        {
            try
            {
                GenericNode<String, Archive> folderNode = tree.SearchNode(nameFolder);
                Archive folder = tree.SearchNode(nameFolder).Data;

                decimal totalSize = CalculateTotalSize(folderNode);
                if (folder != null)
                {
                    Console.WriteLine("O nome da pasta é: {0} com tamanho total : {1}", folder.Name, totalSize);
                }
            }catch (Exception)
            {
                Console.WriteLine("Pasta não encontrada.");
            }
        }

        private decimal CalculateTotalSize(GenericNode<String, Archive> folder)
        {
            decimal total = folder.Data.Size;
            if (folder.Children.Count > 0)
            {
                foreach (GenericNode<String, Archive> n in folder.Children)
                {
                    return total + CalculateTotalSize(n);
                }
                return total;
            }
            else
                return total;
        }
    }
}

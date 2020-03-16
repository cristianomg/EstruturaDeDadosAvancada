using ArvoreBinaria.DataStruct.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeDados.Entities
{
    public class Table
    {
        public string Name { get; set; }
        public ulong LastId { get; set; }
        public ITree<Entitie> Struct { get; set; }
    }
}

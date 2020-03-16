using BancoDeDados.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BancoDeDados.Interface
{
    interface IBancoDeDados 
    {
        public bool InsertTable(string name);
        public string ListAttributes();
        public Entitie Insert(string table, Entitie obj);
        public Entitie Update(string table, ulong Id, Entitie obj);
        public Entitie GetById(string table, ulong id);
        public Entitie GetByColumn(string table, string column, Object value);
        public bool Delete(string table, ulong id);
    }
}

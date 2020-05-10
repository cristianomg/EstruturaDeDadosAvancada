using BancoDeDados.Entities;
using BancoDeDados.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancoDeDados.Concrete
{
    public class BandoDeDados : IBancoDeDados
    {
        public Dictionary<string, Table> Tables { get; set; }
        public bool InsertTable(string name)
        {
            try
            {
                if (!Tables.ContainsKey(name))
                {
                    Tables.Add(name, new Table());
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        public Entitie Insert(string table, Entitie obj)
        {
            try
            {
                if (Tables.ContainsKey(table))
                {
                    var _table = Tables[table];
                    obj.Id = _table.LastId;
                    _table.Struct.Insert(_table.LastId, obj);
                    _table.LastId++;
                    return obj;
                }
                return null;
            }
            catch
            {
                return null;
            }

        }

        public bool Delete(string table, ulong id)
        {
            throw new NotImplementedException();
        }

        public Entitie GetByColumn(string table, string column, Object value)
        {
            if (Tables.ContainsKey(table))
            {
                var _table = Tables[table].Struct;
                if (_table.VisitTree(ArvoreBinaria.Enum.VisitType.InOrder).Any())
                {
                    return null;
                }
            }
            return null;
        }

        public Entitie GetById(string table, ulong id)
        {
            if (Tables.ContainsKey(table))
            {
                return Tables[table].Struct.Search(id).Value;
            }
            return null;
        }

        public string ListAttributes()
        {
            throw new NotImplementedException();
        }

        public Entitie Update(string table, ulong Id, Entitie obj)
        {
            if (Tables.ContainsKey(table))
            {
                var _table = Tables[table].Struct;
                _table.Insert(Id, obj);
                return obj;
            }
            return null;
        }
    }
}

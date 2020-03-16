using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria.DataStruct.Interfaces
{
    public interface ITree <TValue>
    {
        List<Node<TValue>> Nodes
        {
            get;
        }
        TValue Insert(UInt64 key, TValue value, Node<TValue> root = null);
        TValue Search(UInt64 key, Node<TValue>root = null);
        IEnumerator<TValue> Iterator();
    }
}

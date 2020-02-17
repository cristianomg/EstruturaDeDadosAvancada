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
        TValue Insert(uint key, TValue value, Node<TValue> root = null);
        TValue Search(uint key, Node<TValue>root = null);
        IEnumerator<TValue> Iterator();
    }
}

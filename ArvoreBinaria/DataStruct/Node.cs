using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria.DataStruct
{
    public class Node <TValue>
    {
        public UInt64 Key { get; set; }
        public TValue Value { get; set; }
        public Node<TValue> Right { get; set; }
        public Node<TValue> Left { get; set; }

    }
}

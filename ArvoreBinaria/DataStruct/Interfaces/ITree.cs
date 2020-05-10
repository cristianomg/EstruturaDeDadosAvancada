using ArvoreBinaria.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria.DataStruct.Interfaces
{
    public interface ITree<TValue>
    {
        TValue Insert(ulong key, TValue value, Node<TValue> root = null);
        Node<TValue> Search(ulong key, Node<TValue> root = null);
        List<Node<TValue>> VisitTree(VisitType type);
        Tuple<ulong, ulong> GetMinMaxValues();
        long GetAverage();
        int GetAmountNodes();
        int GetAmountLeaf();
        void RemoveNode(ulong key);

    }
}

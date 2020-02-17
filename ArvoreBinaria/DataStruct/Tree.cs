using ArvoreBinaria.DataStruct.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria.DataStruct
{
    public class Tree<TValue> : ITree<TValue>
    {
        private Node<TValue> root;

        public List<Node<TValue>> Nodes { get; private set; }

        public Tree()
        {
            Nodes = new List<Node<TValue>>();
        }

        public TValue Insert(uint key, TValue value, Node<TValue> root = null)
        {
            if (root == null)
            {
                root = this.root;
            }
            if (this.root == null)
            {
                this.root = new Node<TValue>()
                {
                    Key = key,
                    Value = value,
                    Left = null,
                    Right = null
                };
                Nodes.Add(this.root);
                return this.root.Value;
            }
            else if (key > root.Key)
            {
                if (root.Right == null)
                {
                    root.Right = new Node<TValue>()
                    {
                        Key = key,
                        Value = value,
                        Left = null,
                        Right = null
                    };
                    Nodes.Add(root);
                    return root.Value;
                }
                else
                {
                    return Insert(key, value, root.Right);
                }
            }
            else if (key < root.Key)
            {
                if (root.Left == null)
                {
                    root.Left = new Node<TValue>()
                    {
                        Key = key,
                        Value = value,
                        Left = null,
                        Right = null
                    };
                    Nodes.Add(root);
                return root.Value;
                }
                else
                {
                    return Insert(key, value, root.Left);
                }
            }
            else
                throw new Exception("Chave já adicionada.");
        }

        public IEnumerator<TValue> Iterator()
        {
            throw new NotImplementedException();
        }

        public TValue Search(uint key, Node<TValue>root = null)
        {
            if (root == null) 
                root = this.root;
            if (key == root.Key)
                return root.Value;
            else if (key > root.Key)
            {
                if (root.Right == null)
                    throw new Exception("Não encontrado.");
                return Search(key, root.Right);
            }
            else
            {
                if (root.Left == null)
                    throw new Exception("Não encontrado.");
                return Search(key, root.Left);
            }
        }
    }


}

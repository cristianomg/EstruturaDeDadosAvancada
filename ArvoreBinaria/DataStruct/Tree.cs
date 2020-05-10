using ArvoreBinaria.DataStruct.Interfaces;
using ArvoreBinaria.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria.DataStruct
{
    public class Tree<TValue> : ITree<TValue>
        where TValue : class
    {
        private Node<TValue> root;

        public TValue Insert(ulong key, TValue value, Node<TValue> root = null)
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
                    Right = null,
                    Parent = null
                };
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
                        Right = null,
                        Parent = root
                    };
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
                        Right = null,
                        Parent = root
                        
                    };
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

        public Node<TValue> Search(ulong key, Node<TValue>root = null)
        {
            if (root == null) 
                root = this.root;
            if (key == root.Key)
                return root;
            else if (key > root.Key)
            {
                if (root.Right == null)
                    return null;
                return Search(key, root.Right);
            }
            else
            {
                if (root.Left == null)
                    return null;
                return Search(key, root.Left);
            }
        }

        public List<Node<TValue>> VisitTree(VisitType type)
        {
            var refVisitedNodes = new List<Node<TValue>>();
            var result = new List<Node<TValue>>();
            switch (type)
            {
                case VisitType.PreOrder:
                    result = PreOrder(this.root, ref refVisitedNodes);
                    break;
                case VisitType.InOrder:
                    result =  InOrder(this.root, ref refVisitedNodes);
                    break;
                case VisitType.PosOrder:
                    result = PosOrder(this.root, ref refVisitedNodes);
                    break;
            }
            return result;
        }

        private List<Node<TValue>> PreOrder(Node<TValue> node, ref List<Node<TValue>> visitedNodes)
        {
            if (node != null)
            {
                visitedNodes.Add(node);
                PreOrder(node.Left, ref visitedNodes);
                PreOrder(node.Right, ref visitedNodes);
            }

            return visitedNodes;
        }

        private List<Node<TValue>> InOrder(Node<TValue> node, ref List<Node<TValue>> visitedNodes)
        {
            if (node != null)
            {
                InOrder(node.Left, ref visitedNodes);
                visitedNodes.Add(node);
                InOrder(node.Right, ref visitedNodes);
            }
            return visitedNodes;

        }
        private List<Node<TValue>> PosOrder(Node<TValue> node, ref List<Node<TValue>> visitedNodes)
        {
            if (node != null)
            {
                PosOrder(node.Left, ref visitedNodes);
                PosOrder(node.Right, ref visitedNodes);
                visitedNodes.Add(node);
            }
            return visitedNodes;

        }

        public Tuple<ulong, ulong> GetMinMaxValues()
        {
            var VisitedTree = VisitTree(VisitType.InOrder);

            var minValue = VisitedTree.Min(x => x.Key);

            var maxValue = VisitedTree.Max(x => x.Key);

            return new Tuple<ulong, ulong>(minValue, maxValue);

        }

        public long GetAverage()
        {
            var VisitedTree = VisitTree(VisitType.InOrder);

            var avg = VisitedTree.Sum(x => Convert.ToInt64(x.Key)) / VisitedTree.Count();

            return avg;
        }

        public int GetAmountNodes() => VisitTree(VisitType.InOrder).Count();

        public int GetAmountLeaf() => VisitTree(VisitType.InOrder).Count(x => x.Left == null && x.Right == null);

        public void RemoveNode(ulong key)
        {
            var node = Search(key);
            if (node != null)
            {
                if (node.Parent == null)
                {
                    this.root = RemoveCurrent(node);
                }
                else
                {
                    node.Parent = RemoveCurrent(node);
                }
            }
            
        }

        private Node<TValue> RemoveCurrent(Node<TValue> node)
        {
            if (node.Right != null && node.Left != null)
            {
                var refVisitedTree = new List<Node<TValue>>();
                var largestRightInSubtree = Search(this.InOrder(node.Left, ref refVisitedTree).Max(x => x.Key));

                node.Left.Parent = largestRightInSubtree;
                node.Right.Parent = largestRightInSubtree;

                largestRightInSubtree.Parent = node.Parent;
                largestRightInSubtree.Left = node.Left != largestRightInSubtree ? node.Left : null;
                largestRightInSubtree.Right = node.Right;


                return largestRightInSubtree;

            }
            else if (node.Left != null)
            {
                node.Left.Parent = node.Parent;
                return node.Left;
            }
            else if (node.Right != null)
            {
                node.Right.Parent = node.Parent;
                return node.Right;
            }

            else return null;
        }

        public int GetHeight()
        {
            var VisitedTree = VisitTree(VisitType.InOrder);
            var ParentList = new List<string>();

            VisitedTree.ForEach(x =>
            {
                if (!ParentList.Contains(x.Parent.ToString()))
                    ParentList.Add(x.Parent.ToString());
            });

            return ParentList.Count();
        }

    }


}

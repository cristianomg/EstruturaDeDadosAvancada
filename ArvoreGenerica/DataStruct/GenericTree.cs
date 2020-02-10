using ArvoreGenerica.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreGenerica.DataStruct
{
    public class GenericTree <IFather, I, E>
        where IFather : class
        where I : class
    {
        public GenericTree()
        {
            Nodes = new List<GenericNode<I, E>>();
        }

        public int Size { get; set; }
        public bool IsEmpty { get { return Size == 0 ? true : false; }}
        public GenericNode<I, E> Root { get; private set; }
        public IList<GenericNode<I, E>> Nodes { get; private set; }

        public bool IsInternal(GenericNode<I, E> node) => node.Children != null ? true : false;

        public bool IsExternal(GenericNode<I, E> node) => node.Children == null ? true : false;

        public bool IsRoot(GenericNode<I, E> node) => node.Father == null ? true : false;

        public IList<GenericNode<I, E>> Children(GenericNode<I, E> node) => node.Children;

        public void AddRoot(I index, E value)
        {
            if (Root == null)
            {
                Root = new GenericNode<I, E>() { Data = value, Index = index};
                Nodes.Add(Root);
                Size++;
            }
            else
            {
                throw new InvalidNodeException("Raiz já Ocupada.");
            }
        }

        public void AddNode(IFather indexFather, I index, E value)
        {
            if (Root == null)
            {
                throw new EmptyTreeException("Árvore vazia.");
            }
            else
            {
                GenericNode<I, E> father = SearchFather(indexFather);
                if (father == null)
                    throw new InvalidNodeException("Nó pai não encontrado.");
                else
                {
                    GenericNode<I, E> children = new GenericNode<I, E>()
                    {
                        Father = father,
                        Data = value,
                        Index = index
                    };
                    father.Children.Add(children);
                    Nodes.Add(children);
                }


            }

        }

        public GenericNode<I, E> SearchFather(IFather indexFather, List<GenericNode<I, E>> childrens = null, GenericNode<I, E> lastVisited = null)
        {
            if (lastVisited == null)
                childrens = new List<GenericNode<I, E>>(Root.Children);

            if (Root.Index.Equals(indexFather))
                return Root;

            else if (childrens.Count > 0)
            {
                List<GenericNode<I, E>> varChildrens = new List<GenericNode<I, E>>();
                foreach (GenericNode<I, E> c in childrens)
                {
                    if (c.Index.Equals(indexFather))
                        return c;
                }

                foreach(GenericNode<I, E> c in childrens) 
                {
                    varChildrens.AddRange(c.Children);
                    lastVisited = c;
                }
                childrens = new List<GenericNode<I, E>>(varChildrens);
                return SearchFather(indexFather, childrens, lastVisited);
            }
            else
                return null;

        }

        public GenericNode<I, E> SearchNode(I index, List<GenericNode<I, E>> childrens = null, GenericNode<I, E> lastVisited = null)
        {
            if (lastVisited == null)
                childrens = new List<GenericNode<I, E>>(Root.Children);

            if (Root.Index.Equals(index))
                return Root;

            else if (childrens.Count > 0)
            {
                List<GenericNode<I, E>> varChildrens = new List<GenericNode<I, E>>();
                foreach (GenericNode<I, E> c in childrens)
                {
                    if (c.Index.Equals(index))
                        return c;
                }

                foreach (GenericNode<I, E> c in childrens)
                {
                    varChildrens.AddRange(c.Children);
                    lastVisited = c;
                }
                childrens = new List<GenericNode<I, E>>(varChildrens);
                return SearchNode(index, childrens, lastVisited);
            }
            else
                return null;
        }

        public E Replace(GenericNode<I, E> node, E value)
        {
            if (node != null)
                node.Data = value;
            else
                throw new InvalidNodeException("Nó invalido.");
            return value;
        }

        public GenericNode<I, E> Father(GenericNode<I, E> node)
        {
            if (node != null)
                return node.Father;
            else
                throw new InvalidNodeException("Nó invalido.");
        }



    }
}

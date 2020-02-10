using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreGenerica.DataStruct
{
    public class GenericNode <I, E>
        where I : class
    {
        public GenericNode()
        {
            Children = new List<GenericNode<I, E>>();
        }
        public I Index { get; set; }
        public E Data { get; set; }
        public GenericNode<I, E> Father { get; set; }
        public List<GenericNode<I, E>> Children { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}

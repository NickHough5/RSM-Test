using System;

namespace NewCode1.BST
{
    public class Tree<TKey, TValue>
    {
        public Node<TKey, TValue> Root { get; private set; }

        public Node<TKey, TValue> AddNode(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public TValue FindByKey(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}
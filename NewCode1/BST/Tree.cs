using System;

namespace NewCode1.BST
{
    public class Tree<TKey, TValue>
    {
        public Node<TKey, TValue> Root { get; private set; }

        public Node<TKey, TValue> AddNode(TKey key, TValue value)
        {
            Node<TKey, TValue> before = null, after = this.Root;

            while(after != default)
            {
                before = after;
                if(key.GetHashCode() < after.Key.GetHashCode())
                {
                    after = after.Left;
                }
                else if(key.GetHashCode() > after.Key.GetHashCode())
                {
                    after = after.Right;
                }
                else
                {
                    // Trying to insert same key, this shouldn't happen
                    throw new Exception("Same key being inserted into Binary Tree, this cannot happen");
                }
            }

            Node<TKey, TValue> newNode = new Node<TKey, TValue>(key, value);
            if(this.Root == default)
            {
                this.Root = newNode;
            }
            else if (key.GetHashCode() < before.Key.GetHashCode())
            {
                before.Left = newNode;
            }
            else
            {
                before.Right = newNode;
            }

            return this.Root;
        }

        public TValue FindByKey(TKey key)
        {
            if(this.Root != default)
            {
                return FindByKey(key, this.Root);
            }

            return default;
        }

        public TValue FindByKey(TKey key, Node<TKey, TValue> parent)
        {
            if(parent != default)
            {
                if (key.GetHashCode() == parent.Key.GetHashCode())
                {
                    return parent.Value;
                }
                else if(key.GetHashCode() < parent.Key.GetHashCode())
                {
                    return FindByKey(key, parent.Left);
                }
                else
                {
                    return FindByKey(key, parent.Right);
                }
            }

            return default;
        }
    }
}
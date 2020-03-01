using System;
using System.Collections.Generic;
using System.Text;

namespace BinTree
{
    class BinaryTree<T>
    {
        private class Node
        {
            public int Key;
            public T Value;
            public Node Left;
            public Node Right;
        }

        private Node _root;

        public bool TryInsert(int key, T value)
        {
            Node newNode = new Node();
            newNode.Key = key;
            newNode.Value = value;

            if (_root == null)
            {
                _root = newNode;
                return true;
            }
            Node currentNode = _root;
            while(true)
            {
                if (newNode.Key >= currentNode.Key)
                {
                    if (newNode.Key == currentNode.Key)
                        return false;
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                }
                else
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                }
            }
            return true;
        }

        public void Insert(int key, T value)
        {
            if (!TryInsert(key,value))
                throw new System.ArgumentException("Key arguement must be unique!");
        }

        public bool TryGetValue(int key, out T value)
        {
            Node currentNode = _root;
            while (currentNode != null)
            {
                if (currentNode.Key == key)
                {
                    value = currentNode.Value;
                    return true;
                }
                if (key > currentNode.Key)
                    currentNode = currentNode.Right;
                else
                    currentNode = currentNode.Left;
            }
            value = default;
            return false;
        }

        public T GetValue(int key)
        {
            T value;
            if (TryGetValue(key, out value))
                return value;
            else
                throw new System.Exception("Key value does not exist in tree.");
        }

        public bool TrySetValue(int key, T value)
        {
            Node currentNode = _root;
            while (currentNode != null)
            {
                if (currentNode.Key == key)
                {
                    currentNode.Value = value;
                    return true;
                }
                if (key > currentNode.Key)
                    currentNode = currentNode.Right;
                else
                    currentNode = currentNode.Left;
            }
            return false;
        }
        
        public void SetValue(int key, T value)
        {
            if (!TrySetValue(key, value))
                throw new System.Exception("Key value does not exist in tree.");
        }

        public T this[int key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }
    }
}

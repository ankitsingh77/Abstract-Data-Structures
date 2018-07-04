using System;
using System.Collections.Generic;
namespace Abstract_Data_Structures
{
    public class Node<T>
    {
        public T NodeContent;
        public Node<T> nextNode;
    }
    public class MyList<T>
    {
        public Node<T> Head;
        private int size;

        public MyList()
        {
            size = 0;
            Head = null;
        }
        public int Count()
        {
            return size;
        }

        public void AddAt(int index, T NodeValue)
        {
            if (index > size + 1)
            {
                throw new Exception("Node cannot be added at " + index);
            }
            else
            {
                Node<T> newNode = new Node<T>
                {
                    NodeContent = NodeValue
                };
                if (index == 1)
                {
                    newNode.nextNode = Head;
                    Head = newNode;
                }
                else
                {
                    Node<T> temp = Head;
                    for (int i = 1; i < index - 1; i++)
                    {
                        temp = temp.nextNode;
                    }
                    newNode.nextNode = temp.nextNode;
                    temp.nextNode = newNode;
                }
                size = size + 1;
            }
        }

        public void RemoveAt(int index)
        {
            if (index > size)
            {
                throw new Exception("No element at index " + index);
            }
            else
            {
                if (index == 1)
                {
                    Head = Head.nextNode;
                }
                else
                {
                    Node<T> tempNode = Head;
                    for (int i = 1; i < index - 1; i++)
                    {
                        tempNode = tempNode.nextNode;
                    }
                    Node<T> deletedNode = tempNode.nextNode;
                    tempNode.nextNode = deletedNode.nextNode;
                    deletedNode.nextNode = null;
                }
                size = size - 1;
            }
        } 

        public Node<T> Retrieve(int index)
        {
            if (index > size)
            {
                throw new Exception("No element at index " + index);
            }
            else
            {
                Node<T> returnNode = Head;
                for (int i = 1; i < index && returnNode.nextNode != null; i++)
                {
                    returnNode = returnNode.nextNode;
                }
                return returnNode;
            }
        }

        public void AddNodeAtEnd(Node<T> node)
        {
            Node<T> temp = this.Head;
            Node<T> temp2 = node;
            while (temp.nextNode != null)
                temp = temp.nextNode;
            int nodeSize = 1;
            while (temp2.nextNode != null)
            {
                nodeSize++;
                temp2 = temp2.nextNode;
            }
            temp.nextNode = node;
            this.size += nodeSize;
        }

    }
}

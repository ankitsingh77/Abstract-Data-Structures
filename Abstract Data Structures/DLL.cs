// -----------------------------------------------------------------------
// <copyright file="DLL.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Abstract_Data_Structures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// 
    public class DLLNode<T>
    {
        public T nodeContent;
        public DLLNode<T> prevNode;
        public DLLNode<T> nextNode;
    }
    public class DLL<T>
    {
        private DLLNode<T> Head;
        private int size;
        

        public DLL()
        {
            size = 0;
            Head = null;
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public DLLNode<T> Retrieve(int index)
        {
            if (index > size)
            {
                throw new Exception("No element at index " + index);
            }
            else
            {
                DLLNode<T> returnNode = Head;
                for (int i = 1; i < index && returnNode.nextNode != null; i++)
                {
                    returnNode = returnNode.nextNode;
                }
                return returnNode;
            }
        }

        public void AddAt(int position, T nodeContent)
        {
            if (position > size + 1)
                throw new Exception("Node cannot be added at " + position);
            else
            {
                DLLNode<T> newNode = new DLLNode<T>
                {
                    nodeContent = nodeContent
                };
                if (position == 1)
                {
                    newNode.nextNode = Head;
                    newNode.prevNode = null;
                    if (Head != null)
                        Head.prevNode = newNode;
                    Head = newNode;
                }
                else
                {
                    DLLNode<T> temp = Head;
                    for (int i = 1; i < position - 1; i++)
                    {
                            temp = temp.nextNode;
                    }
                    if (temp.nextNode == null)
                    {
                        newNode.nextNode = null;
                        newNode.prevNode = temp;
                        temp.nextNode = newNode;
                    }
                    else
                    {
                        newNode.nextNode = temp.nextNode;
                        newNode.prevNode = temp;
                        temp.nextNode.prevNode = newNode;
                        temp.nextNode = newNode;
                    }
                    temp = null;
                }
                newNode = null;
                size++;
            }
        }

        public void RemoveAt(int position)
        {
            if (size < position)
            {
                throw new Exception("No element found at position " + position);
            }
            if (position == 1)
            {
                if (Head.nextNode == null)
                {
                    Head = null;
                    size--;
                    return;
                }
                else
                {
                    Head.nextNode.prevNode = null;
                    Head = Head.nextNode;
                }
            }
            else
            {
                DLLNode<T> temp = Head;
                for (int i = 1; i <= position - 1; i++)
                {
                    temp = temp.nextNode;
                }
                if (temp.nextNode == null)
                {
                    temp.prevNode.nextNode = null;
                    temp.prevNode = null;
                    temp = null;
                }
                else 
                {
                    temp.prevNode.nextNode = temp.nextNode;
                    temp.nextNode.prevNode = temp.prevNode;
                    temp = null;
                }
            }
            size--;
        }

        public void Add(T NodeContent)
        {
            DLLNode<T> targetNode = new DLLNode<T>
            {
                nodeContent = NodeContent
            };
            if (Head != null)
            {
                DLLNode<T> iteratorNode = Head;
                while (iteratorNode.nextNode != null)
                    iteratorNode = iteratorNode.nextNode;
                iteratorNode.nextNode = targetNode;
                targetNode.prevNode = iteratorNode;
                iteratorNode = null;
            }
            else
            {
                Head = targetNode;
            }
            targetNode = null;
            size++;
        }

        public void Delete(T NodeContent)
        {
            int position = 1;
            DLLNode<T> temp = Head;
            if (temp == null)
            {
                throw new Exception("Item not found");
            }
            while(temp != null)
            {
                if (temp.nodeContent.Equals(NodeContent))
                {
                    RemoveAt(position);
                    break;
                }
                else
                {
                    position++;
                    temp = temp.nextNode;
                }
            }
            temp = null;
            if (position == size)
            {
                throw new Exception("Item Not Found");
            }
            
        }
    }
}

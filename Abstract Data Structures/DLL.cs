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
        public T NodeContent;
        public DLLNode<T> PrevNode;
        public DLLNode<T> NextNode;
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
                for (int i = 1; i < index && returnNode.NextNode != null; i++)
                {
                    returnNode = returnNode.NextNode;
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
                    NodeContent = nodeContent
                };
                if (position == 1)
                {
                    newNode.NextNode = Head;
                    newNode.PrevNode = null;
                    if (Head != null)
                        Head.PrevNode = newNode;
                    Head = newNode;
                }
                else
                {
                    DLLNode<T> temp = Head;
                    for (int i = 1; i < position - 1; i++)
                    {
                            temp = temp.NextNode;
                    }
                    if (temp.NextNode == null)
                    {
                        newNode.NextNode = null;
                        newNode.PrevNode = temp;
                        temp.NextNode = newNode;
                    }
                    else
                    {
                        newNode.NextNode = temp.NextNode;
                        newNode.PrevNode = temp;
                        temp.NextNode.PrevNode = newNode;
                        temp.NextNode = newNode;
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
                if (Head.NextNode == null)
                {
                    Head = null;
                    size--;
                    return;
                }
                else
                {
                    Head.NextNode.PrevNode = null;
                    Head = Head.NextNode;
                }
            }
            else
            {
                DLLNode<T> temp = Head;
                for (int i = 1; i <= position - 1; i++)
                {
                    temp = temp.NextNode;
                }
                if (temp.NextNode == null)
                {
                    temp.PrevNode.NextNode = null;
                    temp.PrevNode = null;
                    temp = null;
                }
                else 
                {
                    temp.PrevNode.NextNode = temp.NextNode;
                    temp.NextNode.PrevNode = temp.PrevNode;
                    temp = null;
                }
            }
            size--;
        }

        public void Add(T NodeContent)
        {
            DLLNode<T> targetNode = new DLLNode<T>
            {
                NodeContent = NodeContent
            };
            if (Head != null)
            {
                DLLNode<T> iteratorNode = Head;
                while (iteratorNode.NextNode != null)
                    iteratorNode = iteratorNode.NextNode;
                iteratorNode.NextNode = targetNode;
                targetNode.PrevNode = iteratorNode;
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
                if (temp.NodeContent.Equals(NodeContent))
                {
                    RemoveAt(position);
                    break;
                }
                else
                {
                    position++;
                    temp = temp.NextNode;
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

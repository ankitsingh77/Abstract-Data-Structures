// -----------------------------------------------------------------------
// <copyright file="CLL.cs" company="Microsoft">
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
    public class CLL<T>
    {
        public Node<T> Head;
        private int size;


        public CLL()
        {
            Head = null;
            size = 0;
        }

        public void Insert(T NodeContent, bool insertAtBegin)
        {
            Node<T> temp = new Node<T>() { NodeContent = NodeContent };
            if (Head == null)
            {
                Head = temp;
                Head.nextNode = Head;
            }
            else
            {
                Node<T> current = Head;
                while (current.nextNode != Head)
                    current = current.nextNode;
                current.nextNode = temp;
                temp.nextNode = Head;
                if (insertAtBegin == true)
                    Head = temp;
            }
            size++;
        }

        public void Delete(bool fromFront)
        {
            if (Head == null)
            {
                throw new Exception("List is Empty");
            }
            Node<T> current = Head;
            Node<T> temp = Head;
            if (Head == Head.nextNode)
            {
                Head = null;
                size = 0;
                return;
            }
            while (current.nextNode != Head)
            {
                temp = current;
                current = current.nextNode;
            }
            if (fromFront)
            {
                Head = Head.nextNode;
                current.nextNode = Head;
            }
            else 
            {
                temp.nextNode = Head;
            }
            size--;
        }
    }
}
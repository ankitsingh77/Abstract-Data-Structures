using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Data_Structures
{
    public class Stack<T>
    {
        public Node<T> Top;

        public Stack()
        {
            Top = null;
        }

        public void Push(T element)
        {
            Node<T> temp = new Node<T>();
            temp.NodeContent = element;
            if(Top == null)
            {
                Top = temp;
                return;
            }
            temp.nextNode = Top;
            Top = temp;
        }

        public T Pop()
        {
            T returnValue;
            if (Top == null)
            {
                throw new Exception("Stack is empty");
            }
            else if (Top.nextNode == null)
            {
                returnValue = Top.NodeContent;
                Top = null;
            }
            else
            {
                returnValue = Top.NodeContent;
                Top = Top.nextNode;
            }
            return returnValue;
        }

        public bool IsEmpty()
        {
            return Top == null;
        }
    }
}

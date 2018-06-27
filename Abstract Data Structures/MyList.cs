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

        public Node<T> NthNodeFromEnd(int n)
        {
            Node<T> temp = Head;
            Node<T> temp1 = Head;

            for (int i = 1; i < n; i++)
                temp = temp.nextNode;
            while (temp.nextNode != null)
            {
                temp = temp.nextNode;
                temp1 = temp1.nextNode;
            }
            return temp1;
        }

        public static Node<T> MergeLists(Node<T> list1, Node<T> list2)
        {
            if (list1 == null || list2 == null)
                throw new Exception("Source/destination list is empty");

            Node<T> temp = list1;
            while (temp.nextNode != null)
            {
                temp = temp.nextNode;
            }
            temp.nextNode = list2;

            return list1;
        }

        public static bool CycleFound(Node<T> start, out Node<T> intersectionNode, out int position)
        {
            intersectionNode = null;
            position = 0;
            Node<T> slowptr = start;
            Node<T> fastptr = start;

            while (fastptr.nextNode != null)
            {
                fastptr = fastptr.nextNode;
                slowptr = slowptr.nextNode;
                if (fastptr.nextNode != null && fastptr.nextNode != slowptr)
                {
                    fastptr = fastptr.nextNode;
                }
                else
                {
                    break;
                }
            }
            if (fastptr.nextNode == null)
                return false;
            else 
            {
                fastptr = fastptr.nextNode;
            }
            slowptr = start;
            position = 1;
            while (fastptr != slowptr)
            {
                position++;
                fastptr = fastptr.nextNode;
                slowptr = slowptr.nextNode;
            }
            intersectionNode = slowptr;
            return true;
        }

        public static MyList<T> ReverseList(MyList<T> list)
        {
            Node<T> nextNode = null;
            Node<T> tempNode = null;
            Node<T> head = list.Head;
            while (head != null)
            {
                nextNode = head.nextNode;
                head.nextNode = tempNode;
                tempNode = head;
                head = nextNode;
            }
            list.Head = tempNode;
            return list;
        }

        public static void MergeListsAt(ref MyList<T> list1, ref MyList<T> list2,bool mergeonFirstList, int index)
        {
            Node<T> temp;
            if (mergeonFirstList)
            {
                temp = list1.Head;
                if (list1.size < index)
                {
                    throw new Exception("First List size is less than the index of merge.");
                }
                for (int i = 1; i < index; i++)
                {
                    temp = temp.nextNode;
                }
                list2.AddNodeAtEnd(temp);
            }
            else 
            {
                temp = list2.Head;
                if (list2.size < index)
                {
                    throw new Exception("Second List size is less than the index of merge.");
                }
                for (int i = 1; i < index; i++)
                {
                    temp = temp.nextNode;
                }
                list2.AddNodeAtEnd(temp);
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

        public static Node<T> IntersectionNode(MyList<T> list1, MyList<T> list2)
        {
            Node<T> temp1;
            Node<T> temp2;
            int differnce;

            if (list1.size > list2.size)
            {
                 temp1= list1.Head;
                 temp2 = list2.Head;
                 differnce = list1.size - list2.size;
            }
            else
            {
                temp1= list2.Head;
                temp2 = list1.Head;
                 differnce = list2.size - list1.size;
            }
                
            for (int i = 0; i < differnce; i++)
            {
                temp1 = temp1.nextNode;
            }
                
            while (temp1.nextNode != null && temp2.nextNode != null && temp1 != temp2)
            {
                temp1 = temp1.nextNode;
                temp2 = temp2.nextNode;
            }
            if (temp1 == temp2)
            {
                return temp1;
            }
            else
            {
                return null;
            }
            
        }

    }
}

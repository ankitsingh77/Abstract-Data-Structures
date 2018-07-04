using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Data_Structures
{
    public static class MyListExtension
    {
        public static Node<T> NthNodeFromEnd<T>(this MyList<T> list,int n)
        {
            Node<T> temp = list.Head;
            Node<T> temp1 = list.Head;

            for (int i = 1; i < n; i++)
                temp = temp.nextNode;
            while (temp.nextNode != null)
            {
                temp = temp.nextNode;
                temp1 = temp1.nextNode;
            }
            return temp1;
        }

        public static Node<T> MergeLists<T>(this Node<T> list1, Node<T> list2)
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

        public static bool CycleFound<T>(this Node<T> start, out Node<T> intersectionNode, out int position)
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

        public static MyList<T> ReverseList<T>(this MyList<T> list)
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

        public static void MergeListsAt<T>(this MyList<T> list1, ref MyList<T> list2, bool mergeonFirstList, int index)
        {
            Node<T> temp;
            if (mergeonFirstList)
            {
                temp = list1.Head;
                if (list1.Count() < index)
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
                if (list2.Count() < index)
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

        public static Node<T> IntersectionNode<T>(this MyList<T> list1, MyList<T> list2)
        {
            Node<T> temp1;
            Node<T> temp2;
            int differnce;

            if (list1.Count() > list2.Count())
            {
                temp1 = list1.Head;
                temp2 = list2.Head;
                differnce = list1.Count() - list2.Count();
            }
            else
            {
                temp1 = list2.Head;
                temp2 = list1.Head;
                differnce = list2.Count() - list1.Count();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Data_Structures
{
    public static class MyListExtension
    {
        /// <summary>
        /// Finds a node at a given distance from end in a linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Input List</param>
        /// <param name="n">Distance from end of list.</param>
        /// <returns>Node at a distance n from end of list.</returns>
        public static Node<T> NthNodeFromEnd<T>(this MyList<T> list, int n)
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

        /// <summary>
        /// Merges two linked list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1">Head Node/Node from First list</param>
        /// <param name="list2">Head Node/Node from Second list</param>
        /// <returns>Head node of merged list. </returns>
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

        /// <summary>
        /// Finds wether if a list has cycle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start">Head node of list</param>
        /// <param name="intersectionNode">Node at which cycle starts.</param>
        /// <param name="position">Postion at which cycle starts.</param>
        /// <returns>True if there is a cycle otherwise false.</returns>
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

        /// <summary>
        /// Finds length of cycle in linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Input List</param>
        /// <returns>Length of the cyclic path.</returns>
        public static int CycleLength<T>(this MyList<T> list)
        {
            int length = 0;
            if(list.Head==null)
            {
                return 0;
            }
            Node<T> fastPtr = list.Head;
            Node<T> slowPtr = list.Head;
            while (fastPtr.nextNode != null)
            {
                fastPtr = fastPtr.nextNode;
                slowPtr = slowPtr.nextNode;
                if (fastPtr.nextNode != null && fastPtr.nextNode != slowPtr)
                {
                    fastPtr = fastPtr.nextNode;
                }
                else
                {
                    break;
                }
            }
            if (fastPtr.nextNode == null)
                return 0;
            else
            {
                fastPtr = fastPtr.nextNode;
                length = 1;
            }
            fastPtr = fastPtr.nextNode;
            if(fastPtr==slowPtr)
            {
                return length;
            }
            while (slowPtr != fastPtr)
            {
                fastPtr = fastPtr.nextNode;
                length++;
            }
            return length;
        }

        /// <summary>
        /// Reverses a linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Input List</param>
        /// <returns>Reversed List</returns>
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

        public static Node<T> RecursiveListReversal<T>( Node<T> listHead)
        {
            if (listHead == null)
                return null;

            if(listHead.nextNode ==null)
            {
                return listHead;
            }
            Node<T> secondElement = listHead.nextNode;
            listHead.nextNode = null;
            Node<T> reverseListHead = RecursiveListReversal(secondElement);
            secondElement.nextNode = listHead; // Second Element will be the last element of reversed list.
            return reverseListHead;
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

        public static MyList<T> CloneList<T>(this MyList<T> inputList)
        {
            if (inputList == null)
                return null;
            MyList<T> clonedList = new MyList<T>();
            var temp = inputList.Head;
            if(temp==null)
            {
                return clonedList;
            }
            while (temp!=null)
            {
                Node<T> newNode = new Node<T>();
                newNode.NodeContent = temp.NodeContent;
                clonedList.AddNodeAtEnd(newNode);
                temp = temp.nextNode;
            }
            return clonedList;            
        }
    }
}

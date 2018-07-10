// -----------------------------------------------------------------------
// <copyright file="Problems.cs" company="None">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using InputOutputManger;
    using Abstract_Data_Structures;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// 

    public class CustomNode
    {
        public int data;
        public CustomNode nextNode;
        public CustomNode randomNode;
    }
    public static class Problems
    {

        #region List delete demo

        public static void DeletionDemo()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var meList = InputStream.ReadFileAsMyList(ioGenerator.GenerateIntegerInputFile(20));
            meList.Print();
            Console.WriteLine("Enter the position at which you want to delete a node");
            int nth = Convert.ToInt32(Console.ReadLine());
            meList.RemoveAt(nth);
            meList.Print();
        }

        public static void DeletionDemo_DLL()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var meList = InputStream.ReadFileAsDLL(ioGenerator.GenerateIntegerInputFile(20));
            meList.Print();
            Console.WriteLine("Enter the position at which you want to delete a node");
            int nth = Convert.ToInt32(Console.ReadLine());
            meList.RemoveAt(nth);
            meList.Print();
        }

        public static void DeletionDemo_CLL()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var meList = InputStream.ReadFileAsCLL(ioGenerator.GenerateIntegerInputFile(20));
            meList.Print();
            //Console.WriteLine("Enter the position at which you want to delete a node");
            //int nth = Convert.ToInt32(Console.ReadLine());
            meList.Delete(true);
            meList.Print();
        }

        #endregion

        #region nth number from end in a list
        public static void NthNumberfromEndDemo()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var meList = InputStream.ReadFileAsMyList(ioGenerator.GenerateIntegerInputFile(20));
            meList.Print();
            Console.WriteLine("Enter the position from end which you want to see");
            int nth = Convert.ToInt32(Console.ReadLine());
            int nodeContent = meList.NthNodeFromEnd(nth).NodeContent;
            Console.WriteLine("{0}th number from end is {1}", nth, nodeContent);
        }

        #endregion nth number from end in a list

        #region Find whether a list has a cycle or not. If yes at which node.
        public static void CyclicLinkDemo()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var list1 = InputStream.ReadFileAsMyList(ioGenerator.GenerateIntegerInputFile(20));
            var list2 = InputStream.ReadFileAsCLL(ioGenerator.GenerateIntegerInputFile(20));
            Node<int> list3 = list1.Head.MergeLists(list2.Head);
            Node<int> intersectionNode = new Node<int>();
            int position = 0;
            if (list3.CycleFound(out intersectionNode, out position))
            {
                Console.WriteLine("Cycle found at postion: {0} with Node Value:{1}", position, intersectionNode.NodeContent);
            }
            else
            {
                Console.WriteLine("This is a linear list");
            }
        }

        #endregion Find whether a list has a cycle or not. If yes at which node.

        public static void CycleLengthDemo()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var list = InputStream.ReadFileAsMyList(ioGenerator.GenerateIntegerInputFile(20));
            Console.WriteLine("Enter the node index where last node should point, 0 means no cycle");
            int n1 = Convert.ToInt32(Console.ReadLine());
            if (n1 == 0)
            {
                Console.WriteLine(string.Format("Cycle Length : {0}", list.CycleLength()));
            }
            else
            {
                if (n1 > list.Count())
                {
                    Console.WriteLine(string.Format("Index {0} cannot be greater than list size {1} ", n1, list.Count()));
                }
                else
                {
                    var temp = list.Head;
                    Node<int> intersectingNode = null;
                    if (n1 == 1)
                    {
                        intersectingNode = temp;
                    }
                    int tempposition = 1;
                    while (temp.nextNode != null)
                    {
                        temp = temp.nextNode;
                        tempposition++;
                        if (tempposition == n1 && intersectingNode == null)
                        {
                            intersectingNode = temp;
                        }
                    }
                    temp.nextNode = intersectingNode;
                    Console.WriteLine(string.Format("Cycle Length : {0}", list.CycleLength()));
                }
            }
        }

        #region reverse a list
        public static void ReversalDemo()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var meList = InputStream.ReadFileAsMyList(ioGenerator.GenerateIntegerInputFile(20));
            meList.Print();
            var clonedList = meList.CloneList<int>();
            MyList<int> reversedList = meList.ReverseList();

            Console.WriteLine("ReversedList (Iterative approach : ");
            var temp = reversedList.Head;
            while (temp != null)
            {
                Console.WriteLine(temp.NodeContent);
                temp = temp.nextNode;
            }

            Node<int> reversedListHead = MyListExtension.RecursiveListReversal<int>(clonedList.Head);
            Console.WriteLine("ReversedList (Recursive approach : ");
            while (reversedListHead != null)
            {
                Console.WriteLine(reversedListHead.NodeContent);
                reversedListHead = reversedListHead.nextNode;
            }
        }
        #endregion reverse a list

        #region Intersecting Lists Demo

        public static void IntersectingListsDemo()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var list1 = InputStream.ReadFileAsMyList(ioGenerator.GenerateIntegerInputFile(20));
            Console.WriteLine("****************First List********************");
            list1.Print();
            Console.WriteLine("\n\n");
            var list2 = InputStream.ReadFileAsMyList(ioGenerator.GenerateIntegerInputFile(20));
            Console.WriteLine("****************Second List********************");
            list2.Print();
            Console.WriteLine("Enter Merge index ");
            int n = Convert.ToInt32(Console.ReadLine());
            list1.MergeListsAt(ref list2, true, n);
            Node<int> intersectingNode = list1.IntersectionNode(list2);
            Console.WriteLine("Intersecting Node: {0}", intersectingNode.NodeContent);
        }

        #endregion

        #region Clone CustomList

        public static CustomNode CloneCustomList(CustomNode head)
        {
            CustomNode X;
            CustomNode Y;
            X = head;
            Dictionary<CustomNode, CustomNode> cloneList = new Dictionary<CustomNode, CustomNode>();
            while (X != null)
            {
                Y = new CustomNode
                {
                    data = X.data
                };
                cloneList.Add(X, Y);
            }
            X = head;
            while (X != null)
            {
                cloneList[X].nextNode = cloneList[X.nextNode];
                cloneList[X].randomNode = cloneList[X.randomNode];
                X = X.nextNode;
            }
            return cloneList[head];
        }

        #endregion Clone CustomList

        public static void Print<T>(this MyList<T> myList)
        {
            for (int i = 1; i <= myList.Count(); i++)
            {
                Console.WriteLine(myList.Retrieve(i).NodeContent);
            }
        }

        public static void Print<T>(this DLL<T> myList)
        {
            for (int i = 1; i <= myList.Count; i++)
            {
                Console.WriteLine(myList.Retrieve(i).NodeContent);
            }
        }

        public static void Print<T>(this CLL<T> myList)
        {
            for (int i = 1; i <= myList.Count; i++)
            {
                Console.WriteLine(myList.Retrieve(i).NodeContent);
            }
        }

        public static MyList<int> TakeInputList()
        {
            MyList<int> meList = new MyList<int>();
            Console.WriteLine("Enter the number of elements in List");
            int numbers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of List\n ");
            int i = 1;
            while (i <= numbers)
            {
                meList.AddAt(i++, Convert.ToInt32(Console.ReadLine()));
            }
            return meList;
        }

        public static DLL<int> TakeInputList_DLL()
        {
            DLL<int> meList = new DLL<int>();
            Console.WriteLine("Enter the number of elements in List");
            int numbers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of List\n ");
            int i = 1;
            while (i <= numbers)
            {
                meList.AddAt(i++, Convert.ToInt32(Console.ReadLine()));
            }
            return meList;
        }

        public static CLL<int> TakeInputList_CLL()
        {
            CLL<int> meList = new CLL<int>();
            Console.WriteLine("Enter the number of elements in List");
            int numbers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of List\n ");
            int i = 1;
            while (i <= numbers)
            {
                meList.Insert(Convert.ToInt32(Console.ReadLine()), false);
                i++;
            }
            return meList;
        }
    }
}

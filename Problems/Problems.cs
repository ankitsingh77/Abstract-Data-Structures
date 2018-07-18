// -----------------------------------------------------------------------
// <copyright file="Problems.cs" company="None">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Problems
{
    using System;
    using System.Collections.Generic;
    using InputOutputManger;
    using Abstract_Data_Structures;
    using Stack;
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
        public static void DeletionDemo()
        {
            var meList = TakeInputList();
            meList.Print();
            Console.WriteLine("Enter the position at which you want to delete a node");
            int nth = Convert.ToInt32(Console.ReadLine());
            meList.RemoveAt(nth);
            meList.Print();
        }

        public static void DeletionDemo_DLL()
        {
            var meList = TakeInputList_DLL();
            meList.Print();
            Console.WriteLine("Enter the position at which you want to delete a node");
            int nth = Convert.ToInt32(Console.ReadLine());
            meList.RemoveAt(nth);
            meList.Print();
        }

        public static void DeletionDemo_CLL()
        {
            var meList = TakeInputList_CLL();
            meList.Print();
            //Console.WriteLine("Enter the position at which you want to delete a node");
            //int nth = Convert.ToInt32(Console.ReadLine());
            meList.Delete(true);
            meList.Print();
        }

        public static void NthNumberfromEndDemo()
        {
            var meList = TakeInputList();
            meList.Print();
            Console.WriteLine("Enter the position from end which you want to see");
            int nth = Convert.ToInt32(Console.ReadLine());
            int nodeContent = meList.NthNodeFromEnd(nth).NodeContent;
            Console.WriteLine("{0}th number from end is {1}", nth, nodeContent);
        }

        public static void CyclicLinkDemo()
        {
            InputGenerator ioGenerator = new InputGenerator();
            ioGenerator.MaxContentLength = 20;
            ioGenerator.MinContentLength = 10;
            var list1 = TakeInputList();
            var list2 = TakeInputList_CLL();
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

        public static void CycleLengthDemo()
        {
            var list = TakeInputList();
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

        public static void ReversalDemo()
        {
            var meList = TakeInputList();
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

        public static void IntersectingListsDemo()
        {
            var list1 = TakeInputList();
            Console.WriteLine("****************First List********************");
            list1.Print();
            Console.WriteLine("\n\n");
            var list2 = TakeInputList();
            Console.WriteLine("****************Second List********************");
            list2.Print();
            Console.WriteLine("Enter Merge index ");
            int n = Convert.ToInt32(Console.ReadLine());
            list1.MergeListsAt(ref list2, true, n);
            Node<int> intersectingNode = list1.IntersectionNode(list2);
            Console.WriteLine("Intersecting Node: {0}", intersectingNode.NodeContent);
        }

        public static void FindMiddleDemo()
        {
            var meList = TakeInputList();
            meList.Print();
            Console.WriteLine("Middle node ::");
            Console.WriteLine(meList.FindMiddle().NodeContent);
        }

        public static void EvenLengthListDemo()
        {
            var meList = TakeInputList();
            meList.Print();
            Console.WriteLine(string.Format("List is of {0} length", meList.IsEvenLength() ? "Even" : "Odd"));
        }

        public static void ReverseListinPairsDemo()
        {
            var meList = TakeInputList();
            meList.Print();
            meList.ReverseListInPairs();
            Console.WriteLine("Paired reversed list::");
            meList.Print();
        }

        public static void ReverseListInBlocksDemo()
        {
            var meList = TakeInputList();
            meList.Print();
            int blockSIze = new Random().Next(2, meList.Count());
            meList.ReverseListinBlocks(blockSIze);
            Console.WriteLine("Reversed list in block of {0}::",blockSIze);
            meList.Print();
        }

        public static void BalancingSymbolsDemo()
        {
            Console.WriteLine("Enter the expression");
            string expression = Console.ReadLine();
            bool balanced = StackApplication.BalancingSymbols(expression);
            Console.WriteLine(string.Format("Symbols are {0} in this expression.",balanced?"balanced":"not balanced"));
        }

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

        public static MyList<int> TakeInputList(bool isRandom = true, int MinContentLegth = 10, int MaxContentLength = 20, int MaxValue = 20)
        {
            if (!isRandom)
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
            else
            {
                InputGenerator ioGenerator = new InputGenerator();
                ioGenerator.MaxContentLength = MaxContentLength;
                ioGenerator.MinContentLength = MinContentLegth;
                var meList = InputStream.ReadFileAsMyList(ioGenerator.GenerateIntegerInputFile(MaxValue));
                return meList;
            }
        }

        public static DLL<int> TakeInputList_DLL(bool isRandom = true, int MinContentLegth = 10, int MaxContentLength = 20, int MaxValue = 20)
        {
            if (!isRandom)
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
            else
            {
                InputGenerator ioGenerator = new InputGenerator();
                ioGenerator.MaxContentLength = MaxContentLength;
                ioGenerator.MinContentLength = MinContentLegth;
                var meList = InputStream.ReadFileAsDLL(ioGenerator.GenerateIntegerInputFile(MaxValue));
                return meList;
            }
        }

        public static CLL<int> TakeInputList_CLL(bool isRandom = true, int MinContentLegth = 10, int MaxContentLength = 20, int MaxValue = 20)
        {
            if (!isRandom)
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
            else
            {
                InputGenerator ioGenerator = new InputGenerator();
                ioGenerator.MaxContentLength = MaxContentLength;
                ioGenerator.MinContentLength = MinContentLegth;
                var meList = InputStream.ReadFileAsCLL(ioGenerator.GenerateIntegerInputFile(MaxValue));
                return meList;
            }
        }
    }
}

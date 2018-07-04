// -----------------------------------------------------------------------
// <copyright file="Problems.cs" company="None">
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
            var meList = TakeInputList();
            Console.WriteLine("Enter the position at which you want to delete a node");
            int nth = Convert.ToInt32(Console.ReadLine());
            meList.RemoveAt(nth);
            meList.Print();
        }

        public static void DeletionDemo_DLL()
        {
            var meList = TakeInputList_DLL();
            Console.WriteLine("Enter the position at which you want to delete a node");
            int nth = Convert.ToInt32(Console.ReadLine());
            meList.RemoveAt(nth);
            meList.Print();
        }

        public static void DeletionDemo_CLL()
        {
            var meList = TakeInputList_CLL();
            //Console.WriteLine("Enter the position at which you want to delete a node");
            //int nth = Convert.ToInt32(Console.ReadLine());
            meList.Delete(true);
            meList.Print();
        }

        #endregion

        #region nth number from end in a list
        public static void NthNumberfromEndDemo()
        {
            MyList<int> meList = TakeInputList();
            Console.WriteLine("Enter the position from end which you want to see");
            int nth = Convert.ToInt32(Console.ReadLine());
            int nodeContent = meList.NthNodeFromEnd(nth).NodeContent;
            Console.WriteLine("{0}th number from end is {1}", nth, nodeContent);
        }

        #endregion nth number from end in a list

        #region Find whether a list has a cycle or not. If yes at which node.
        public static void CyclicLinkDemo()
        {
            MyList<int> list1 = new MyList<int>();
            CLL<int> list2 = new CLL<int>();

            Console.WriteLine("Enter the number of elements in first List");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of First List\n ");
            int i = 1;
            while (i <= n1)
            {
                list1.AddAt(i++, Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine("Enter the number of elements in Second List");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of First List\n ");
            int j = 1;
            while (j <= n2)
            {
                list2.Insert(Convert.ToInt32(Console.ReadLine()), false);
                j++;
            }

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
            MyList<int> list = TakeInputList();

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
            MyList<int> meList = new MyList<int>();
            Console.WriteLine("Enter the number of elements in List");
            int numbers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of List\n ");
            int i = 1;
            while (i <= numbers)
            {
                meList.AddAt(i++, Convert.ToInt32(Console.ReadLine()));
            }

            MyList<int> reversedList = meList.ReverseList();

            Console.WriteLine("ReversedList : ");
            while (reversedList.Head != null)
            {
                Console.WriteLine(reversedList.Head.NodeContent);
                reversedList.Head = reversedList.Head.nextNode;
            }
        }
        #endregion reverse a list

        #region Intersecting Lists Demo

        public static void IntersectingListsDemo()
        {
            MyList<int> list1 = GetList(1);
            MyList<int> list2 = GetList(2);

            Console.WriteLine("Enter Merge index ");
            int n = Convert.ToInt32(Console.ReadLine());
            list1.MergeListsAt(ref list2, true, n);
            Node<int> intersectingNode = list1.IntersectionNode(list2);
            Console.WriteLine("Intersecting Node: {0}", intersectingNode.NodeContent);
        }

        #endregion

        #region GetList
        public static MyList<int> GetList(int listNo)
        {
            MyList<int> meList = new MyList<int>();
            Console.WriteLine("Enter the number of elements in List{0}", listNo);
            int numbers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter elements of List\n ");
            int i = 1;
            while (i <= numbers)
            {
                meList.AddAt(i++, Convert.ToInt32(Console.ReadLine()));
            }

            return meList;
        }
        #endregion GetList

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
                Console.Write(myList.Retrieve(i).NodeContent);
            }
        }

        public static void Print<T>(this DLL<T> myList)
        {
            for (int i = 1; i <= myList.Count; i++)
            {
                Console.Write(myList.Retrieve(i).NodeContent);
            }
        }

        public static void Print<T>(this CLL<T> myList)
        {
            for (int i = 1; i <= myList.Count; i++)
            {
                Console.Write(myList.Retrieve(i).NodeContent);
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

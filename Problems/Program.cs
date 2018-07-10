using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            while (ExecuteDemo())
            {
                Console.WriteLine("");
            }
        }

        private static bool ExecuteDemo()
        {
            Console.WriteLine("*********Demonstration of Data Structure Problem**********");
            Console.WriteLine("Select Option");
            Console.WriteLine("1. Deletion in Single Linked List.");
            Console.WriteLine("2. Nth Number from End in a Single Linked List.");
            Console.WriteLine("3. Find Cycle in a single Linked list.");
            Console.WriteLine("4. Find Length of cycle in a single linked list.");
            Console.WriteLine("5. Reverse a single linked list.");
            Console.WriteLine("6. Find if two lists have an intersection node.");
            Console.WriteLine("7. Deletion in doubly linked list(DLL).");
            Console.WriteLine("8. Deletion in circular linked list(CLL)");
            Console.WriteLine("9. Find middle element in single linked list");
            Console.WriteLine("10. Find if a list is of even/odd length");
            Console.WriteLine("11. Reverse a List in Pairs") ;
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Console.WriteLine("********* Deletion in Single Linked List***********");
                        Problems.DeletionDemo();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("*********Nth Number from End in a Single Linked List**********");
                        Problems.NthNumberfromEndDemo();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("*********Find Cycle in a single Linked list**********");
                        Problems.CyclicLinkDemo();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("*********Find Length of cycle in a single linked list***********");
                        Problems.CycleLengthDemo();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("********Reverse a single linked list************");
                        Problems.ReversalDemo();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("*********Find if two lists have an intersection node***********");
                        Problems.IntersectingListsDemo();
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("*********Deletion in doubly linked list(DLL)***********");
                        Problems.DeletionDemo_DLL();
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("*********Deletion in circular linked list(CLL)***********");
                        Problems.DeletionDemo_CLL();
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("*********Middle Element in single linked list***********");
                        Problems.FindMiddleDemo();
                        break;
                    }
                case 10:
                    {
                        Console.WriteLine("*********Even or Odd Length***********");
                        Problems.EvenLengthListDemo();
                        break;
                    }
                case 11:
                    {
                        Console.WriteLine("*********Reverse List in Pairs***********");
                        Problems.ReverseListinPairsDemo();
                        break;
                    }
                default:
                    break;

            }
            Console.WriteLine("Do You want to continue execution for other options(y/n)?");
            return Console.ReadKey().Key == ConsoleKey.Y;
        }
    }
}

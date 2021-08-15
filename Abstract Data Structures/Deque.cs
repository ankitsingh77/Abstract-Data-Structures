using System;
using Abstract_Data_Structures.Interfaces;

namespace Abstract_Data_Structures
{
    /// <summary>
    /// Double Ended Queue Linked List Implementation
    /// </summary>
    public class Deque<T> : IDeque<T>
    {
        class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
        }

        private Node _front = null;
        private Node _rear = null;
        private int _size = 0;

        int IDeque<T>.Count => _size;

        public void OfferFirst(T element)
        {
            var node = new Node() { Value = element};
            if (_front == null)
            {
                _front = node;
                _rear = node;
            }
            else
            {
                _front.Prev = node;
                node.Next = _front;
                _front = node;
            }
            _size++;
        }

        public void OfferLast(T element)
        {
            var node = new Node() { Value = element};
            if (_rear == null)
            {
                _rear = node;
                _front = node;
            }
            else
            {
                node.Prev = _rear;
                _rear.Next = node;
                _rear = node;
            }

            _size++;
        }

        public void PollFirst()
        {
            if (_front == null)
            {
                throw new Exception("Empty Deque, cannot poll");
            }

            if (_size == 1)
            {
                _front = null;
                _rear = null;
            }
            else
            {
                _front.Next.Prev = null;
                var node = _front;
                _front = _front.Next;
                node.Next = null;
            }

            _size--;
        }

        public void PollLast()
        {
            if (_rear == null)
            {
                throw new Exception("Empty Deque, cannot poll");
            }

            if (_size == 1)
            {
                _front = null;
                _rear = null;
            }
            else 
            {
                var node = _rear.Prev;
                _rear.Prev = null;
                node.Next = null;
                _rear = node;
            }

            _size--;
        }

        public T PeekFirst()
        {
            if (_front == null)
            {
                throw new Exception("Invalid Operation, Queue is empty");
            }

            return _front.Value;
        }

        public T PeekLast()
        {
            if (_rear == null)
            {
                throw new Exception("Invalid Operation, Queue is empty");
            }

            return _rear.Value;
        }

        bool IDeque<T>.IsEmpty()
        {
            return _size == 0;
        }
    }


}

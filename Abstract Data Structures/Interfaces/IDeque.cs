using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Data_Structures.Interfaces
{
    public interface IDeque<T>
    {
        /// <summary>
        /// Insert at Begining.
        /// </summary>

        void OfferFirst(T element);

        /// <summary>
        /// Insert at End.
        /// </summary>
        /// <param name="element"></param>
        void OfferLast(T element);

        /// <summary>
        /// Delete from Fisrt
        /// </summary>
        void PollFirst();

        /// <summary>
        /// Delete from Last
        /// </summary>
        void PollLast();

        /// <summary>
        /// Front Element.
        /// </summary>
        /// <returns></returns>
        T PeekFirst();

        /// <summary>
        /// Rear Element.
        /// </summary>
        /// <returns></returns>
        T PeekLast();

        /// <summary>
        /// Check if the queue is empty or not.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Return the size of queue.
        /// </summary>
        int Count { get; }
    }
}

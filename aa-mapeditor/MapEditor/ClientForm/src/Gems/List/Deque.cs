/**************************************************************/
//
//
//      Copyright (c) 2023 UNLIMITED LOOP ROOT-ONE
//
//
//      This software(and source code) is completely Unlicense.
//      see "LICENSE".
//
//
/**************************************************************/
//
//
//      Arthentic Action Map Editor (Csharp Edition)
//
//      File name       : Deque.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/26
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Gems.List
{
    /// <summary>
    ///  Implements like C++ 'deque' processing.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Deque<T>
    {
        private readonly LinkedList<T> _list = new();

        private bool IsEmpty => _list.Count == 0;

        internal int Count => _list.Count;

        internal void Clear() => _list.Clear();

        internal void AddFront(T item)
        {
            _list.AddFirst(item);
        }

        internal void AddRear(T item)
        {
            _list.AddLast(item);
        }

        internal T RemoveFront()
        {
            if (!IsEmpty)
            {
                T value = _list.First!.Value;
                _list.RemoveFirst();
                return value;
            }
            throw new InvalidOperationException("Deque is empty.");
        }

        internal T RemoveRear()
        {
            if (!IsEmpty)
            {
                T value = _list.Last!.Value;
                _list.RemoveLast();
                return value;
            }
            throw new InvalidOperationException("Deque is empty.");
        }

        internal T PeekFront()
        {
            if (!IsEmpty)
            {
                return _list.First!.Value;
            }
            throw new InvalidOperationException("Deque is empty.");
        }

        internal T PeekRear()
        {
            if (!IsEmpty)
            {
                return _list.Last!.Value;
            }
            throw new InvalidOperationException("Deque is empty.");
        }
    }
}

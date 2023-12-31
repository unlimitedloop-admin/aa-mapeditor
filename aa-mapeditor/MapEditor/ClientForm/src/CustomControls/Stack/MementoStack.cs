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
//      File name       : MementoStack.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/26
//
//      File version    : 3
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Gems.List;



/* sources */
namespace ClientForm.src.CustomControls.Stack
{
    /// <summary>
    ///  Custom stack with upper limit.
    /// </summary>
    /// <typeparam name="T">Typically you specify a custom command class</typeparam>
    /// <param name="maxCapacity">
    ///  It's max capacity.
    /// </param>
    public class MementoStack<T>(uint maxCapacity)
    {
        /// <summary>
        ///  Customized stack container (Pseudo Deque).
        /// </summary>
        private readonly Deque<T> _dequeuedStack = new();

        /// <summary>
        ///  <see cref="Deque{T}.Count"/>
        /// </summary>
        public int Count { get => _dequeuedStack.Count; }

        /// <summary>
        ///  Change capacity.
        /// </summary>
        internal uint MaxCapacity
        {
            get { return maxCapacity; }
            set
            {
                maxCapacity = value;
                AdjustCapacity();
            }
        }

        internal void Clear() => _dequeuedStack.Clear();

        /// <summary>
        ///  Insert the command and check if the stack is overflowing.
        /// </summary>
        /// <param name="item">Inherited commands</param>
        internal void Push(T item)
        {
            _dequeuedStack.AddRear(item);
            AdjustCapacity();
        }

        /// <summary>
        ///  Get the most recent command action.
        /// </summary>
        /// <returns>Inherited commands instance.</returns>
        internal T Pop()
        {
            return _dequeuedStack.RemoveRear();
        }

        /// <summary>
        ///  Trim the oldest commands.
        /// </summary>
        private void AdjustCapacity()
        {
            while (_dequeuedStack.Count > maxCapacity)
            {
                _ = _dequeuedStack.RemoveFront();
            }
        }
    }
}

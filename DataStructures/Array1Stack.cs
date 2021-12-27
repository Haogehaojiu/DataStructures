using System.Runtime.InteropServices;

namespace DataStructures
{
    //先进后出的数据栈——数组栈
    public class Array1Stack<E> : IStack<E>
    {
        private Array1<E> arr;

        public Array1Stack(int capacity)
        {
            arr = new Array1<E>(capacity);
        }

        public Array1Stack()
        {
            arr = new Array1<E>();
        }

        public int Count => arr.Count;
        public bool IsEmpty => arr.IsEmpty;
        public void Push(E e) => arr.AddLast(e);

        public E Pop() => arr.RemoveLast();

        public E Peek() => arr.GetLast();

        public override string ToString()
        {
            return $"Stack: {arr} top";
        }
    }
}
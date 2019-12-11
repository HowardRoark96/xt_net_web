using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>, IEnumerable, ICloneable
    {
        public CycledDynamicArray() : base()
        {
        }
        public CycledDynamicArray(int capacity) : base(capacity)
        {
        }
        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        {
        }

        public new object Clone()
        {
            CycledDynamicArray<T> clone = new CycledDynamicArray<T>(dynamicArray);
            return clone;
        }

        public new IEnumerator GetEnumerator()
        {
            return new CycledDynArrEnum(this);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new CycledDynArrEnum(this);
        }

        public class CycledDynArrEnum : IEnumerator<T>, IEnumerator
        {
            public T[] array;
            int position = -1;
            int length;

            public CycledDynArrEnum(CycledDynamicArray<T> arr)
            {
                array = arr.dynamicArray;
                length = arr.Length;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return array[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get => Current;
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                position++;
                if (position == length)
                {
                    Reset();
                }
                return true;
            }

            public void Reset()
            {
                position = 0;
            }
        }
    }
}

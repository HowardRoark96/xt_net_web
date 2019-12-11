using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        protected T[] dynamicArray;
        protected T[] temp;

        public DynamicArray()
        {
            dynamicArray = new T[8];
        }
        public DynamicArray(int capacity)
        {
            dynamicArray = new T[capacity];
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            dynamicArray = new T[collection.ToArray().Length * 2];
            Array.Copy(collection.ToArray(), dynamicArray, collection.ToArray().Length);
            Length = collection.ToArray().Length;
        }

        public int Length { get; private set; }
        public int Capacity
        {
            get => dynamicArray.Length;

            set
            {
                if (value < dynamicArray.Length && value > 0)
                {
                    temp = dynamicArray;
                    dynamicArray = new T[value];
                    Array.Copy(temp.Take(value).ToArray(), dynamicArray, value);
                    Length = dynamicArray.Length;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public T this[int n]
        {
            get
            {
                if (n >= Length || -n < -Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (n < 0 && -n < Length)
                {
                    n = Length + n;
                }
                return dynamicArray[n];
            }
            set
            {
                if (n >= dynamicArray.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                dynamicArray[n] = value;
            }
        }

        public void Add(T value)
        {
            if (Length == Capacity)
            {
                T[] tmpArray = dynamicArray;
                dynamicArray = new T[Capacity * 2];
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    dynamicArray[i] = tmpArray[i];
                }
            }
            dynamicArray[Length] = value;
            Length++;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if (Length + collection.ToArray().Length >= Capacity)
            {
                T[] tmpArray = dynamicArray;
                dynamicArray = new T[(Length + collection.ToArray().Length) * 2];
                Array.Copy(tmpArray, dynamicArray, tmpArray.Length);
            }

            Array.Copy(collection.ToArray(), 0, dynamicArray, Length, collection.ToArray().Length);
            Length = this.Length + collection.ToArray().Length;
        }
        public bool Remove(T value)
        {
            bool result = false;

            for (int i = 0; i < Length; i++)
            {
                if (dynamicArray[i].Equals(value))
                {
                    for (int j = i; j < Length; j++)
                    {
                        dynamicArray[j] = dynamicArray[j + 1];
                    }
                    Length--;
                    result = true;
                }
            }
            return result;
        }
        public bool Insert(T value, int index)
        {
            bool result = false;

            if (Length + 1 == Capacity)
            {
                T[] tmpArray = dynamicArray;
                dynamicArray = new T[Capacity * 2];
                Array.Copy(tmpArray, dynamicArray, tmpArray.Length);
            }

            if (index >= 0 && index <= Length)
            {
                for (int i = Length - 1; i >= index; i--)
                {
                    dynamicArray[i + 1] = dynamicArray[i];
                }
                dynamicArray[index] = value;
                Length++;
                result = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return result;
        }
        public object Clone()
        {
            DynamicArray<T> cloneArray = new DynamicArray<T>(dynamicArray);
            return cloneArray;
        }
        public T[] ToArray()
        {
            T[] tmpArr = new T[Length];
            Array.Copy(dynamicArray, 0, tmpArr, 0, Length);
            return tmpArr;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new DynArrEnum(this);
        }
        public IEnumerator GetEnumerator()
        {
            return new DynArrEnum(this);
        }
        public class DynArrEnum : IEnumerator<T>, IEnumerator
        {
            public T[] array;
            int position = -1;
            int length;

            public DynArrEnum(DynamicArray<T> arr)
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
                return (position < length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}

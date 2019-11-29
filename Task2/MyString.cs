using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Task2
{
    class MyString
    {
        private char[] _myString;


        public MyString(char[] charArray)
        {
            _myString = charArray;
        }

        public MyString(int length)
        {
            _myString = new char[length];
        }

        public MyString(string someString)
        {
            _myString = someString.ToCharArray();
        }

        public int Length
        {
            get => _myString.Length;
        }

        public char this[int n]
        {
            get => _myString[n];
            set
            {
                _myString[n] = value;
            }
        }

        public static MyString operator + (MyString string1, MyString string2)
        {
            MyString temp = new MyString(string1.Length + string2.Length);

            Array.Copy(string1._myString, 0, temp._myString, 0, string1.Length);
            Array.Copy(string2._myString, 0, temp._myString, string1.Length, string2.Length);

            return temp;
        }

        public static bool operator == (MyString string1, MyString string2)
        {
            if (string1.Length != string2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < string1.Length; i++)
                {
                    if (string1[i] != string2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static bool operator != (MyString string1, MyString string2)
        {
            if (string1.Length != string2.Length)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < string1.Length; i++)
                {
                    if (string1[i] != string2[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool operator <= (MyString string1, MyString string2)
        {
            if (string1.Length <= string2.Length)
            {
                return true;
            }
            return false;
        }

        public static bool operator >= (MyString string1, MyString string2)
        {
            if (string1.Length >= string2.Length)
            {
                return true;
            }
            return false;
        }

        public static bool operator < (MyString string1, MyString string2)
        {
            if (string1.Length < string2.Length)
            {
                return true;
            }
            return false;
        }

        public static bool operator > (MyString string1, MyString string2)
        {
            if (string1.Length > string2.Length)
            {
                return true;
            }
            return false;
        }

        public static implicit operator char(MyString string1)
        {
            return (char)string1[0];
        }

        public static explicit operator MyString(char num)
        {
            return new MyString(new char[] { num });
        }

        public override string ToString()
        {
            return new string(_myString);
        }

        public override bool Equals(object obj)
        {
            if (this.Length != ((MyString)obj).Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.Length; i++)
                {
                    if (this[i] != ((MyString)obj)[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public override int GetHashCode()
        {
            return BitConverter.ToInt32(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(this._myString)), 0);
        }
    }
}

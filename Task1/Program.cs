using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int select = 0, temp;
            do
            {
                try
                {

                    ShowMenu();

                    do
                    {
                        Console.Write("Select the number of task: ");
                    } while (!int.TryParse(Console.ReadLine(), out select));

                    Console.WriteLine(new string('-', 30));

                    switch (select)
                    {
                        case 1:
                            int x, y;

                            Console.WriteLine("Task 1 RECTANGLE");

                            CheckValue(out x, "Input length of a rectangle: ");

                            CheckValue(out y, "Input width of a rectangle: ");

                            Console.WriteLine(new string('-', 30));

                            Console.WriteLine("Area of the rectangle is {0}", x * y);

                            break;

                        case 2:
                            Console.WriteLine("Task 2 TRIANGLE");

                            CheckValue(out temp, "Input number of lines of a triangle(N): ");

                            Console.WriteLine(new string('-', 30));

                            ShowTriangle(temp);

                            break;

                        case 3:
                            Console.WriteLine("Task 3 ANOTHER TRIANGLE");

                            CheckValue(out temp, "Input number of lines of a triangle(N): ");

                            Console.WriteLine(new string('-', 30));

                            ShowAnotherTriangle(temp);

                            break;

                        case 4:
                            Console.WriteLine("Task 4 X-MAS TREE");

                            CheckValue(out temp, "Input number of triangles(N): ");

                            Console.WriteLine(new string('-', 30));

                            Show_X_masTree(temp);

                            break;

                        case 5:
                            Console.WriteLine("Task 5 SUM OF NUMBERS");

                            int sum = SumNumbers(temp = 1000);

                            Console.WriteLine("The sum of all numbers multiple of 5 and 3 in the range from 0 to 1000 is " + sum);

                            break;

                        case 6:
                            Console.WriteLine("Task 6 FONT ADJUSTMENT");

                            Choose c = Choose.none;

                            GetAllChooses();

                            do
                            {
                                Console.WriteLine("Label : " + c);
                                Console.WriteLine("\t 1: bold \n \t 2: italic \n \t 3: underline");

                                CheckValue(out temp, "Enter : ");

                                switch (temp)
                                {
                                    case 1:
                                        c ^= Choose.bold;
                                        break;

                                    case 2:
                                        c ^= Choose.italic;
                                        break;

                                    case 3:
                                        c ^= Choose.underline;
                                        break;

                                    case 4:
                                        break;

                                    default:
                                        throw new ArgumentException("Exception: Task with this number doesn\'t exist"); ;
                                }
                            } while (temp != 4);

                            break;

                        case 7:
                            Console.WriteLine("Task 7 ARRAY PROCESSING");

                            int[] array7 = GenerateRandomArray(15);

                            Console.Write("Unsorted array :");
                            ShowArray(array7);

                            Console.WriteLine("Max value is " + SearchMaxValueInArray(array7));

                            Console.WriteLine("Min value is " + SearchMinValueInArray(array7));

                            SortArray(array7);

                            Console.Write("Sorted array :");
                            ShowArray(array7);

                            break;

                        case 8:
                            Console.WriteLine("Task 8 NO POSITIVE");

                            int[,,] array8 = GenerateRandomArray(3, 3, 3, -11, 11);

                            Console.WriteLine("Origin 3D array(all negative numbers are green) : ");
                            ShowArray(array8);

                            NoPositiveNumber3DArray(array8);

                            Console.WriteLine("No positive 3D array(all negative numbers are green) : ");
                            ShowArray(array8);

                            break;

                        case 9:
                            Console.WriteLine("Task 9 NON-NEGATIVE SUM");

                            int[] array9 = GenerateRandomArray(15);

                            Console.Write("Array :");
                            ShowArray(array9);

                            Console.WriteLine("Sum of non-negative numbers is " + SumOfNonNegativenumbers(array9));

                            break;

                        case 10:
                            Console.WriteLine("Task 10 2D ARRAY");

                            int[,] array10 = GenerateRandomArray(3, 3, -11, 11);

                            Console.WriteLine("2D Array(3 x 3) :");

                            ShowArray(array10);

                            Console.WriteLine("Sum of numbers with an even position : " + SumNumbersEvenPosition(array10));

                            break;

                        case 11:
                            Console.WriteLine("Task 11 AVERAGE STRING LENGTH");
                            int counter = 0;

                            Console.Write("Enter some text : ");

                            string text = Console.ReadLine();

                            foreach (var item in text)
                            {
                                if (char.IsSeparator(item) || char.IsPunctuation(item))
                                    counter++;
                            }

                            char[] separators = new char[counter];
                            counter = 0;

                            foreach (var item in text)
                            {
                                if (char.IsSeparator(item) || char.IsPunctuation(item))
                                {
                                    separators[counter] = item;
                                    counter++;
                                }
                            }

                            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            counter = 0;

                            foreach (var item in words)
                            {
                                counter += item.Length;
                            }

                            Console.WriteLine("Average length of a word : " + Math.Ceiling((double)counter / words.Length));

                            break;

                        case 12:
                            Console.WriteLine("Task 12 CHAR DOUBLER");

                            Console.Write("Enter some text : ");

                            string firstText = Console.ReadLine();

                            Console.Write("Enter some another text : ");

                            string secondText = Console.ReadLine();

                            Console.WriteLine("Result : " + DoubleChar(firstText, secondText));

                            break;

                        case 0:
                            break;

                        default:
                            throw new ArgumentException("Exception: Task with this number doesn\'t exist");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Press any button to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (select != 0);
        }

        [Flags]
        enum Choose
        {
            none = 0,
            bold = 1,
            italic = 2,
            underline = 4
        } // Task 1.6

        static void GetAllChooses()
        {
            for (int i = 0; i < 8; i++)
                Console.WriteLine("int - {0} byte - {1} {2}", i, Convert.ToString(i, 2), (Choose)i);

            Console.WriteLine("!!!Press 4 to exit!!!");
            Console.WriteLine(new string('-', 30));
        }  // выводит все возможные перечисления Choose с их челочисленным и побитовым представлением

        static void ShowMenu()
        {
            Console.WriteLine("Task 01 C# BASICS");
            Console.WriteLine(" 1. RECTANGLE \n 2. TRIANGLE" +
                              " \n 3. ANOTHER TRIANGLE \n 4. X-MAS TREE" +
                              " \n 5. SUM OF NUMBERS \n 6. FONT ADJUSTMENT" +
                              " \n 7. ARRAY PROCESSING \n 8. NO POSITIVE" +
                              " \n 9. NON-NEGATIVE SUM \n 10. 2D ARRAY" +
                              " \n 11. AVERAGE STRING LENGTH \n 12. CHAR DOUBLER" +
                              " \n 0. Exit \n" + new string('-', 30));
        } // выводит "шапку" программы

        static void CheckValue(out int n, string str)
        {
            do
            {
                Console.Write(str);
            } while (!int.TryParse(Console.ReadLine(), out n));

            if (n <= 0)
                throw new ArgumentException("Exception: Invalid argument");
        } // Производит проверку n > 0 

        static void ShowTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('*', i));
            }

        } // Task 1.2

        static void ShowAnotherTriangle(int n)
        {
            for (int i = 1, stars = 1; i <= n; i++, stars += 2)
            {
                Console.WriteLine(new string(' ', n - i) + new string('*', stars));
            }
        } // Task 1.3

        static void Show_X_masTree(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1, stars = 1; j <= i; j++, stars += 2)
                {
                    Console.WriteLine(new string(' ', n - j) + new string('*', stars));
                }
            }

        } // Task 1.4

        static int SumNumbers(int n)
        {
            int sum = 0;

            for (int i = 3; i < n; i++) // Исходя из задания 1000 не входит в диапазон поиска, значит,
                                        // знак "<" строгий. К тому же, можно точно исключить из поиска "0", "1", "2",
                                        // т.к. они не кратны "3" и "5".
            {
                if (i % 5 == 0 || i % 3 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        } // Task 1.5

        static int[] GenerateRandomArray(int d1, int minValue = -101, int maxValue = 101)
        {
            int[] array = new int[d1];

            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(minValue, maxValue);
            }

            return array;
        } // генерирует одномерный массив со случайными значениями

        static int[,] GenerateRandomArray(int d1, int d2, int minValue = -101, int maxValue = 101)
        {
            int[,] array = new int[d1, d2];

            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(minValue, maxValue);
                }
            }

            return array;
        } // генерирует двухмерный массив со случайными значениями

        static int[,,] GenerateRandomArray(int d1, int d2, int d3, int minValue = -101, int maxValue = 101)
        {
            int[,,] array = new int[d1, d2, d3];

            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = rand.Next(minValue, maxValue);
                    }
                }
            }

            return array;
        } // генерирует трехмерный массив со случайными значениями

        static void ShowArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write("  {0}", item);
            }
            Console.WriteLine();
        } // выводит одномерный массив чисел

        static void ShowArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i + j != 0 && (i + j) % 2 == 0)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else
                        Console.ResetColor();

                    Console.Write("{0, 5}", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        } // выводит двухмерный массив чисел

        static void ShowArray(int[,,] array)
        {
            Console.WriteLine(new string('-', 30));

            Console.ForegroundColor = ConsoleColor.DarkRed;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] < 0)
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        else
                            Console.ResetColor();

                        Console.Write("{0, 5}", array[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
                Console.WriteLine(new string('-', 30));
            }
        } // выводит трехмерный массив чисел

        static int SearchMaxValueInArray(int[] array)
        {
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        } // возвращает максимальное значение в одномерном массиве

        static int SearchMinValueInArray(int[] array)
        {
            int min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        } // возвращает минимальное значение в одномерном массиве

        static void SortArray(int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
        } // производит сортировку одномерного массива

        static void NoPositiveNumber3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                            array[i, j, k] = 0;
                    }
                }
            }
        } // Task 1.8

        static int SumOfNonNegativenumbers(int[] array)
        {
            int sum = 0;

            foreach (var item in array)
            {
                if (item > 0)
                    sum += item;
            }

            return sum;
        } // Task 1.9

        static int SumNumbersEvenPosition(int[,] array)
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i + j != 0 && (i + j) % 2 == 0)
                        sum += array[i, j];
                }
            }

            return sum;
        } // Task 1.10

        static StringBuilder DoubleChar(string first, string second)
        {
            StringBuilder result = new StringBuilder(first.Length * 2);

            for (int i = 0; i < first.Length; i++)
            {
                if (second.Contains(first[i]))
                {
                    result.Append(first[i]);
                }
                result.Append(first[i]);
            }
            return result;
        }  // Task 1.12
    }
}

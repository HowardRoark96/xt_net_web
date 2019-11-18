using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladislavSafarovTasksEPAM
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            try
            {
                Console.WriteLine("Task 00 INTRO");
                Console.WriteLine(" 1. SEQUENCE \n 2. SIMPLE \n 3. SQUARE \n 4. ARRAY \n 0. Exit");
                Console.Write("Select the number of task: ");

                int selectTask = int.Parse(Console.ReadLine());
                int temp;

                switch (selectTask)
                {
                    case 1:
                        Console.WriteLine("Task 1 SEQUENCE");
                        Console.Write("Input length of a sequence: ");

                        temp = int.Parse(Console.ReadLine());

                        if (temp > 0)
                        {
                            Console.Write("N = {0}: ", temp);
                            int[] array = Sequence(temp);
                            for (int i = 0; i < array.Length; i++)
                            {
                                Console.Write(" {0}", array[i]);
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            throw new ArgumentException("Exception: Invalid argument");
                        }
                        goto Start;
                    case 2:
                        Console.WriteLine("Task 2 SIMPLE");
                        Console.Write("Input a positive number: ");

                        temp = int.Parse(Console.ReadLine());

                        if (temp <= 0)
                        {
                            throw new ArgumentException("Exception: The number isn\'t positive");
                        }
                        if (IsSimple(temp))
                        {
                            Console.WriteLine("{0} is prime(simple) number", temp);
                        }
                        else
                        {
                            Console.WriteLine("{0} isn\'t prime(simple) number", temp);
                        }
                        goto Start;
                    case 3:
                        Console.WriteLine("Task 3 SQUARE");
                        Console.Write("Input a positive odd number: ");

                        temp = int.Parse(Console.ReadLine());

                        if (temp <= 1 || temp % 2 == 0)
                        {
                            throw new ArgumentException("Exception: The number isn\'t positive or even number or number equals one");
                        }
                        else
                        {
                            Console.WriteLine("N = {0}", temp);
                            ShowSquare(temp);
                        }
                        goto Start;
                    case 4:
                        Console.WriteLine("Task 4 ARRAY");
                        Console.Write("Input a rank of array : ");

                        int rank = int.Parse(Console.ReadLine());

                        int[][] gearArray = new int[rank][];

                        for (int i = 0; i < rank; i++)
                        {
                            Console.Write("Input a rank of {0} array : ", i + 1);
                            gearArray[i] = new int[int.Parse(Console.ReadLine())];
                        }

                        gearArray = RandomFillArray(gearArray);

                        Console.WriteLine("Gear array(Rank is {0}) :", rank);

                        ShowArray(gearArray);

                        Console.WriteLine(" Choose the sorting method \n 1. By elements \n 2. By length \n 3. By elements and length");
                        Console.Write("Select the number of sorting: ");

                        temp = int.Parse(Console.ReadLine());

                        switch (temp)
                        {
                            case 1:
                                Console.WriteLine("Gear array with sorted arrays by elements :");

                                for (int i = 0; i < gearArray.Length; i++)
                                {
                                    SortArrayByElements(gearArray[i]);
                                }

                                ShowArray(gearArray);
                                break;
                            case 2:
                                Console.WriteLine("Gear array with sorted arrays by length :");

                                SortArrayByLength(gearArray);

                                ShowArray(gearArray);
                                break;
                            case 3:
                                Console.WriteLine("Gear array with sorted arrays by length and elements :");

                                SortArrayByLengthAndElements(gearArray);

                                ShowArray(gearArray);
                                break;
                            default:
                                throw new ArgumentException("Exception: Task with this number doesn\'t exist");
                        }
                        goto Start;
                    case 0:
                        break;
                    default:
                        throw new ArgumentException("Exception: Task with this number doesn\'t exist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Start;
            }
            finally
            {
                Console.WriteLine("Press any button to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static int[] Sequence(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            return array;
        }

        static bool IsSimple(int n)
        {
            if (n == 1)
            {
                return true;
            }
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void ShowSquare(int n)
        {
            int y = n / 2 + 1;

            for (int i = 1; i <= n; i++)
            {
                if (i != y)
                {
                    Console.WriteLine(new string('*', n));
                }
                else
                {
                    Console.WriteLine(new string('*', y - 1) + " " + new string('*', y - 1));
                }
            }
        }

        static int[][] RandomFillArray(int[][] gearArray)
        {
            Random rand = new Random();
            for (int i = 0; i < gearArray.Length; i++)
            {
                for (int j = 0; j < gearArray[i].Length; j++)
                {
                    gearArray[i][j] = rand.Next(0, 101);
                }
            }
            return gearArray;
        }

        static void ShowArray(int[][] gearArray)
        {
            Console.Write("{ ");
            for (int i = 0; i < gearArray.Length; i++)
            {
                Console.Write("{");
                for (int j = 0; j < gearArray[i].Length; j++)
                {
                    if (j == gearArray[i].Length - 1 && i == gearArray.Length - 1) // условие проверки является ли элемент самым последним в массиве и в зубчатом массиве
                    {
                        Console.Write("{0}}} ", gearArray[i][j]);
                    }
                    else if (j == gearArray[i].Length - 1) // условие проверки является ли элемент самым последним в массиве
                    {
                        Console.Write("{0}}} , ", gearArray[i][j]);
                    }
                    else
                    {
                        Console.Write("{0},", gearArray[i][j]);
                    }
                }
            }
            Console.WriteLine("}");
        }

        static void SortArrayByElements(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static void SortArrayByLength(int[][] gearArray)
        {
            int[] temp;
            for (int i = 0; i < gearArray.Length; i++)
            {
                for (int j = i + 1; j < gearArray.Length; j++)
                {
                    if (gearArray[i].Length > gearArray[j].Length)
                    {
                        temp = gearArray[i];
                        gearArray[i] = gearArray[j];
                        gearArray[j] = temp;
                    }
                }
            }
        }

        static void SortArrayByLengthAndElements(int[][] gearArray)
        {
            SortArrayByLength(gearArray);

            int lenghtArray = 0;

            for (int i = 0; i < gearArray.Length; i++) // не нашел свойства возврата суммы кол-ва элементов всех массивов зубчатого массива. Здесь происходит расчет этого значения.
            {
                lenghtArray += gearArray[i].Length;
            }

            int[] temp = new int[lenghtArray]; 

            for (int i = 0, cntr = 0; i < gearArray.Length; i++)
            {
                for (int j = 0; j < gearArray[i].Length; j++, cntr++)
                {
                    temp[cntr] = gearArray[i][j];
                }
            }

            SortArrayByElements(temp);

            for (int i = 0, cntr = 0; i < gearArray.Length; i++)
            {
                for (int j = 0; j < gearArray[i].Length; j++, cntr++)
                {
                    gearArray[i][j] = temp[cntr];
                }
            }
        }
    }
}

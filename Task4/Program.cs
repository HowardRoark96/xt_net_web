using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int select = 0;

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
                        case 2:
                            Console.WriteLine("Task 2 CUSTOM SORT DEMO");

                            string[] names = { "Влад", null, null, "Николай", null, "Валентин", "Константин", "Ярик", "Анна", "Аням" };

                            Console.WriteLine("Original collection : ");
                            ShowCollection(names);

                            SortCollection(names, StringComparator);

                            Console.WriteLine("Sordet by length and alphabet: ");
                            ShowCollection(names);

                            break;

                        case 3:
                            Console.WriteLine("Task 3 SORTING UNIT");

                            SortHelper<string> collect1 = new SortHelper<string>(new[] { "Влад", "Анна", "Николай", "Валентин", "Константин", "Ярик" });

                            SortHelper<int> collect2 = new SortHelper<int>(new[] { 1, 91, 82, 66, 37, 5, 47, 66 });

                            collect1.Sorted += Sorted;
                            collect2.Sorted += Sorted;

                            Console.WriteLine("Original collection 1 : ");
                            collect1.ShowCollection();
                            Console.WriteLine(new string('-', 30));
                            Console.WriteLine("Original collection 2 : ");
                            collect2.ShowCollection();

                            Console.WriteLine(new string('-', 30));
                            Console.Write("Press any button to start sorting collection 1");
                            Console.ReadLine();

                            collect1.SortCollectionWithEvent(StringComparator);
                            Console.WriteLine("Sorted collection 1 : ");
                            collect1.ShowCollection();

                            Console.WriteLine(new string('-', 30));
                            Console.Write("Press any button to start sorting collection 2");
                            Console.ReadLine();

                            collect2.SortAsync((x, y) => x > y);

                            Console.WriteLine("Sorted collection 1 : ");
                            collect1.ShowCollection();
                            Console.WriteLine("Sorted collection 2 : ");
                            collect2.ShowCollection();
                            break;

                        case 4:
                            Console.WriteLine("Task 4 NUMBER ARRAY SUM");

                            int[] numbers1 = { 1, 8, 29, 38, 11, 2 };
                            Console.WriteLine("Original collection : ");
                            ShowCollection(numbers1);

                            Console.WriteLine("Sum of all elements : " + numbers1.SumOfElements());

                            double[] numbers2 = { 1.66, 8.95, 29, 38, 11, 2 };
                            Console.WriteLine("Original collection : ");
                            ShowCollection(numbers1);

                            Console.WriteLine("Sum of all elements : " + numbers2.SumOfElements());

                            break;

                        case 5:
                            Console.WriteLine("Task 5 TO INT OR NOT TO INT?");

                            string s = "-050";
                            Console.WriteLine("{0} {1}", s, s.IsIntegerAndPositiveNumber());

                            s = "050";
                            Console.WriteLine("{0} {1}", s, s.IsIntegerAndPositiveNumber());

                            s = "+5995";
                            Console.WriteLine("{0} {1}", s, s.IsIntegerAndPositiveNumber());

                            s = "+00000000";
                            Console.WriteLine("{0} {1}", s, s.IsIntegerAndPositiveNumber());

                            s = "00000000";
                            Console.WriteLine("{0} {1}", s, s.IsIntegerAndPositiveNumber());

                            s = "+++34200000";
                            Console.WriteLine("{0} {1}", s, s.IsIntegerAndPositiveNumber());

                            break;

                        case 6:
                            List<double>[] time = new List<double>[5];
                            time[0] = new List<double>();
                            time[1] = new List<double>();
                            time[2] = new List<double>();
                            time[3] = new List<double>();
                            time[4] = new List<double>();

                            Random rnd = new Random();

                            Stopwatch timer = new Stopwatch();

                            int lap = 0;

                            do
                            {
                                List<int> lst = new List<int>();

                                for (int i = 0; i < 500; i++)
                                {
                                    lst.Add(rnd.Next(-100, 100));
                                }

                                // используем метод непосредственно реализующей поиск
                                timer.Start();
                                GetPositive(lst);
                                timer.Stop();
                                time[0].Add(timer.Elapsed.TotalMilliseconds);

                                // используем метод, которому условие поиска передаётся через экземпляр делегата
                                timer.Restart();
                                GetElement(lst, GetNegative);
                                timer.Stop();
                                time[1].Add(timer.Elapsed.TotalMilliseconds);

                                // используем, которому условие поиска передаётся через делегат в виде лямбда-выражения
                                timer.Restart();
                                GetElement(lst, x => x % 2 != 0);
                                timer.Stop();
                                time[2].Add(timer.Elapsed.TotalMilliseconds);

                                // LINQ-выражения
                                timer.Restart();
                                var a = from item in lst
                                        where item.ToString().Length % 2 != 0
                                        select item;
                                timer.Stop();
                                time[3].Add(timer.Elapsed.TotalMilliseconds);

                                // используем метод, которому условие поиска передаётся через делегат в виде анонимного метода
                                timer.Restart();
                                GetElement(lst,
                                    delegate (int i)
                                    {
                                        return i * i % 2 == 0;
                                    });
                                timer.Stop();
                                time[4].Add(timer.Elapsed.TotalMilliseconds);

                                timer.Reset();

                                lap++;
                            }
                            while (lap != 50);

                            Console.WriteLine("Positive elements " +
                                "(using the method of directly implementing search): {0:F5}",
                                MediumValue(time[0]));

                            Console.WriteLine("All odd elements " +
                                "(using the method, which search condition is transmitted through a delegate): {0:F5}",
                                MediumValue(time[1]));

                            Console.WriteLine("All odd elements " +
                                "(using the method, which search condition is transmitted through a lambda expression): {0:F5}",
                                MediumValue(time[2]));

                            Console.WriteLine("All elements that count of characters is odd (using LINQ): {0:F5}",
                                MediumValue(time[3]));

                            Console.WriteLine("All elements whose square is an even number (using anonymous method): {0:F5}",
                                MediumValue(time[4]));

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

        static void ShowMenu()
        {
            Console.WriteLine("Task 04 DELEGATES AND EXTENSIONS");
            Console.WriteLine(" 2. CUSTOM SORT DEMO \n" +
                              " 3. SORTING UNIT \n" +
                              " 4. NUMBER ARRAY SUM \n" +
                              " 5. TO INT OR NOT TO INT? \n" +
                              " 6. I SEEK YOU \n" +
                              " 0. Exit \n" + new string('-', 30));
        } // выводит "шапку" программы

        static void ShowCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 30));
        } // Выводит все элементы коллекции на экран

        static void SortCollection<T>(T[] array, Func<T, T, bool> comparator)
        {
            T temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparator(array[i], array[j]))
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        } // Task 4.1

        static bool StringComparator(string first, string second)
        {
            if ((first?.Length < second?.Length) || (first == null && second != null))
            {
                return true;
            }

            if (first != null && second != null && first.Length == second.Length)
            {
                int i = 0;
                bool result = false;
                do
                {
                    if (first[i] > second[i])
                    {
                        result = true;
                        break;
                    }

                    i++;
                }
                while (i < first.Length);
                return result;
            }

            return false;
        } // Task 4.2

        public static void Sorted(object sender, EventArgs e)
        {
            Console.WriteLine("Collection is sorted!");
        }

        public static bool GetNegative(int a)
        {
            return a < 0;
        }

        public static IEnumerable<int> GetPositive(List<int> list)
        {
            var pos = list.Where(item => item > 0);
            return pos;
        }

        public static List<T> GetElement<T>(List<T> list, Func<T, bool> comparer)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                if (comparer(item))
                {
                    result.Add(item);
                }
            }
            return result;
        } // Поиск элементов по делегату

        public static double MediumValue(IEnumerable<double> collection)
        {
            var a = from item in collection
                    orderby item descending
                    select item;
            return a.ElementAt(a.Count() / 2);
        } // Поиск среднего значения в коллекции используя LINQ
    }
}

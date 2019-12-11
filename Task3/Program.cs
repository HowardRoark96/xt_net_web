using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
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
                        case 1:
                            Console.WriteLine("Task 1 LOST");

                            Console.Write("Enter the number of people in the circle : ");

                            int countOfPeople = 0;
                            int.TryParse(Console.ReadLine(), out countOfPeople);

                            if (countOfPeople > 0)
                            {
                                Queue<int> people = new Queue<int>(countOfPeople);

                                for (int i = 1; i <= countOfPeople; i++)
                                {
                                    people.Enqueue(i);
                                }

                                while (people.Count > 1)
                                {
                                    people.Enqueue(people.Dequeue());
                                    people.Dequeue();
                                }

                                Console.WriteLine("Only one person left with number = {0}: ", people.Peek());

                            }
                            else
                            {
                                throw new ArgumentException("Exception: Invalid argument");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Task 2 WORD FREQUENCY");

                            Console.Write("Enter some text : ");

                            List<string> text = (Console.ReadLine()).ToLower().Split
                                (new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                            int counter;

                            Console.WriteLine(new string('-', 30));

                            Console.WriteLine("*Word* *Frequency*");

                            for (int i = 0; i < text.Count; i++)
                            {
                                counter = 1;

                                for (int j = i + 1; j < text.Count; j++)
                                {
                                    if (text[i] == text[j])
                                    {
                                        counter++;
                                        text.RemoveAt(j);
                                        j--;
                                    }
                                }

                                Console.WriteLine("{0}  {1}", text[i], counter);
                            }
                            break;

                        case 3:
                            Console.WriteLine("Task 3 DYNAMIC ARRAY. *Test of some functions*");

                            DynamicArray<int> myArray = new DynamicArray<int>();
                            Console.WriteLine("An instance of the DynamicArray class was created.");

                            myArray.Add(55);
                            Console.WriteLine("The {0} was added to the array.", 55);

                            myArray.Add(14);
                            Console.WriteLine("The {0} was added to the array.", 14);

                            myArray.Add(6);
                            Console.WriteLine("The {0} was added to the array.", 6);

                            myArray.Add(8);
                            Console.WriteLine("The {0} was added to the array.", 8);

                            myArray.Add(10);
                            Console.WriteLine("The {0} was added to the array.", 10);

                            ShomMyArray(myArray);

                            List<int> list = new List<int> { 44, 58, 98 };
                            myArray.AddRange(list);
                            Console.WriteLine(@"Collection { 44, 58, 98 } was added to the array.");

                            ShomMyArray(myArray);

                            myArray.Remove(8);
                            Console.WriteLine("Value {0} was removed from the array.", 8);

                            ShomMyArray(myArray);

                            myArray.Insert(29, 6);
                            Console.WriteLine("Value {0} was inserted in {1} position.", 29, 6 + 1);

                            ShomMyArray(myArray);

                            myArray.Insert(13, 1);
                            Console.WriteLine("Value {0} was inserted in {1} position.", 13, 1 + 1);

                            ShomMyArray(myArray);

                            break;

                        case 4:
                            Console.WriteLine("Task 4 DYNAMIC ARRAY (HARDCORE MODE). *Test of some functions*");

                            DynamicArray<int> dynamicArray = new DynamicArray<int>() { 1, 2, 3, 4 };

                            CycledDynamicArray<int> cycledDynamicArray = new CycledDynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                            Console.WriteLine("An instance of the DynamicArray class was created.");
                            ShomMyArray(dynamicArray);

                            Console.WriteLine("Element {0} with index {1}.", dynamicArray[-3], -3);
                            Console.WriteLine("Element {0} with index {1}.", dynamicArray[-2], -2);

                            Console.WriteLine("An instance of the CycledDynamicArray class was created.");
                            ShomMyArray(cycledDynamicArray);

                            Console.WriteLine("Press any button to show next element of array or press 0 to exit.");

                            foreach (var item in cycledDynamicArray)
                            {
                                Console.Write(item);
                                if (Console.ReadLine() == "0")
                                    break;
                            }

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
            Console.WriteLine("Task 03 COLLECTIONS");
            Console.WriteLine(" 1. LOST \n" +
                              " 2. WORD FREQUENCY \n" +
                              " 3. DYNAMIC ARRAY \n" +
                              " 4. *DYNAMIC ARRAY (HARDCORE MODE) \n" +
                              " 0. Exit \n" + new string('-', 30));
        } // выводит "шапку" программы

        static void ShomMyArray<T>(DynamicArray<T> array)
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Length : {0}\t Capacity : {1}", array.Length, array.Capacity);
            foreach (var item in array)
            {
                Console.Write("{0,4}", item);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Figures;

namespace Task2
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
                            double x, y, radius;

                            Console.WriteLine("Task 1 ROUND");

                            CheckValue(out x, "Input X coordinate of center of round: ");
                            CheckValue(out y, "Input Y coordinate of center of round: ");
                            CheckValue(out radius, "Input radius of round: ");

                            Console.WriteLine(new string('-', 30));

                            Round round = new Round(x, y, radius);

                            round.Parametres();

                            break;

                        case 2:
                            double a, b, c;

                            Console.WriteLine("Task 2 TRIANGLE");

                            CheckValue(out a, "Input value of first side of triangle: ");
                            CheckValue(out b, "Input value of second side of triangle: ");
                            CheckValue(out c, "Input value of third side of triangle: ");

                            Console.WriteLine(new string('-', 30));

                            Triangle triangle = new Triangle(a, b, c);

                            triangle.Parametres();

                            break;

                        case 3:
                            Console.WriteLine("Task 3 USER");

                            User user = new User("Vladislav", "Safarov", "Andreevich", new DateTime(1996, 1, 31));

                            Console.WriteLine("{0} {1} {2}\n" +
                                              "Birthday : {3}\n" +
                                              "Age : {4}",
                                              user.LastName, user.FirstName, user.Patronymic, user.Birthday.ToShortDateString(), user.Age);

                            break;

                        case 4:
                            Console.WriteLine("Task 4 MY STRING");

                            MyString myString1 = new MyString(new char[] { '1', 'r', 'v', 'a' });
                            MyString myString2 = new MyString(2);

                            myString2[0] = 'g';
                            myString2[1] = '1';

                            MyString result = myString1 + myString1;

                            Console.WriteLine(myString1 != myString2);

                            MyString sameString = myString1;

                            Console.WriteLine(myString1 == sameString);

                            Console.WriteLine(myString1 >= result);

                            MyString myString3 = new MyString(new char[] { '1', 't', 'n' });

                            Console.WriteLine(myString1.Equals(myString3));

                            myString1 = new MyString(new char[] { '1', '5' });

                            int num = (int)myString1;

                            int t = int.Parse("15");

                            Console.WriteLine(num);

                            myString1 = (MyString)num;

                            Console.WriteLine(myString1);

                            Console.WriteLine(myString3.ToString());

                            int hash = result.GetHashCode();

                            break;

                        case 5:
                            Console.WriteLine("Task 5 EMPLOYEE");

                            Employee Ivan = new Employee("Ivan", "Rasskazov", "Sergeevich", new DateTime(1999, 6, 20), "Engineer", 3);

                            Console.WriteLine("{0} {1} {2}\n" +
                                              "Birthday : {3}\n" +
                                              "Age : {4}\n" +
                                              "Post : {5}\n" +
                                              "Seniority : {6}",
                                              Ivan.LastName, Ivan.FirstName, Ivan.Patronymic, Ivan.Birthday.ToShortDateString(), Ivan.Age, Ivan.Post, Ivan.Seniority);

                            break;

                        case 6:
                            double xRing, yRing, outerRadius, innerRadius;

                            Console.WriteLine("Task 6 RING");

                            CheckValue(out xRing, "Input X coordinate of center of ring: ");
                            CheckValue(out yRing, "Input Y coordinate of center of ring: ");
                            CheckValue(out outerRadius, "Input outer radius of ring: ");
                            CheckValue(out innerRadius, "Input inner radius of ring: ");

                            Console.WriteLine(new string('-', 30));

                            Ring ring = new Ring(xRing, yRing, outerRadius, innerRadius);

                            ring.Parametres();

                            break;

                        case 7:
                            List<Figure> figures = new List<Figure>();

                            Console.WriteLine("Task 7 VECTOR GRAPHICS EDITOR");

                            Console.WriteLine(" 1. Line\n" +
                                              " 2. Rentangle\n" +
                                              " 3. Circle\n" +
                                              " 4. Round\n" +
                                              " 5. Ring\n" +
                                              " 6. Show all figures\n" +
                                              " 7. Exit");

                            do
                            {

                                do
                                {
                                    Console.Write("Create a figure : ");
                                } while (!int.TryParse(Console.ReadLine(), out select));

                                switch (select)
                                {
                                    case 1:
                                        figures.Add(new Line(12, 15, 19, -8));

                                        Console.WriteLine("Line was created.");
                                        Console.WriteLine(new string('-', 30));
                                        break;

                                    case 2:
                                        figures.Add(new Rectangle(18, 9, 6, 18));

                                        Console.WriteLine("Rectangle was created.");
                                        Console.WriteLine(new string('-', 30));
                                        break;

                                    case 3:
                                        figures.Add(new Circle(19, 88, 3.88));

                                        Console.WriteLine("Circle was created.");
                                        Console.WriteLine(new string('-', 30));
                                        break;

                                    case 4:
                                        figures.Add(new Round(71, 91, 21));

                                        Console.WriteLine("Round was created.");
                                        Console.WriteLine(new string('-', 30));
                                        break;

                                    case 5:
                                        figures.Add(new Ring(18, 91, 91, 5));

                                        Console.WriteLine("Ring was created.");
                                        Console.WriteLine(new string('-', 30));
                                        break;

                                    case 6:
                                        if (figures.Count == 0)
                                        {
                                            Console.WriteLine("Nothing has been created yet.");
                                            Console.WriteLine(new string('-', 30));
                                        }
                                        else
                                        {
                                            Console.WriteLine(new string('-', 30));
                                            foreach (var item in figures)
                                            {
                                                item.Parametres();
                                                Console.WriteLine(new string('-', 30));
                                            }
                                        }
                                        break;

                                    case 7:
                                        break;

                                    default:
                                        throw new ArgumentException("Exception: Figure with this number doesn\'t exist");
                                }

                            } while (select != 7);

                            break;

                        case 8:
                            Console.WriteLine("Task 8 GAME");

                            Console.WriteLine("Check code");

                            Console.WriteLine(new string('-', 30));

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
            Console.WriteLine("Task 02 OOP BASICS");
            Console.WriteLine(" 1. ROUND \n" +
                              " 2. TRIANGLE \n" +
                              " 3. USER \n" +
                              " 4. MY STRING \n" +
                              " 5. EMPLOYEE \n" +
                              " 6. RING \n" +
                              " 7. VECTOR GRAPHICS EDITOR \n" +
                              " 8. GAME \n" +
                              " 0. Exit \n" + new string('-', 30));
        } // выводит "шапку" программы
        static void CheckValue(out double n, string str)
        {
            do
            {
                Console.Write(str);
            } while (!double.TryParse(Console.ReadLine(), out n));

        } // бесконечный цикл, пока не введем значение типа double
    }
}

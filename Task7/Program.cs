using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            int select = 0;
            string text;

            while (true)
            {
                try
                {
                    ShowMenu();

                    do
                    {
                        Console.Write("Select the number of task: ");
                    } while (!int.TryParse(Console.ReadLine(), out select));

                    switch (select)
                    {
                        case 1:
                            text = GetText();
                            DataExistance(text);
                            break;
                        case 2:
                            text = GetText();
                            HTMLReplacer(text);
                            break;
                        case 3:
                            text = GetText();
                            EmailFinder(text);
                            break;
                        case 4:
                            text = GetText();
                            NumberValidator(text);
                            break;
                        case 5:
                            text = GetText();
                            TimeCounter(text);
                            break;
                        case 0:
                            return;
                        default:
                            throw new ArgumentException("Invalid input value. Try again.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Press any button to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Task 07 REGULAR EXPRESSIONS");
            Console.WriteLine(" 1. DATE EXISTANCE\n" +
                              " 2. HTML REPLACER\n" +
                              " 3. EMAIL FINDER\n" +
                              " 4. NUMBER VALIDATOR\n" +
                              " 5. TIME COUNTER\n" +
                              " 0. Exit \n" +
                              new string('-', 30));
        }
        static string GetText()
        {
            Console.WriteLine("Write a text: ");
            return Console.ReadLine();
        }
        static void DataExistance(string text)
        {
            Regex regex = new Regex(@"(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]\d{4}");

            if (regex.IsMatch(text))
                Console.WriteLine("In the text there is date");
            else
                Console.WriteLine("In the text there isn't date.");
        }
        static void HTMLReplacer(string text)
        {
            Regex regex = new Regex(@"<[^<>]+>");

            if (regex.IsMatch(text))
                Console.WriteLine(regex.Replace(text, "_"));
            else
                Console.WriteLine("In the text there isn't tegs.");
        }
        static void EmailFinder(string text)
        {
            Regex regex = new Regex(@"\b(([a-zA-Z0-9][a-zA-Z0-9/-_\.]*[a-zA-Z0-9])|[a-zA-Z0-9]+)@[a-zA-Z0-9][a-zA-Z0-9/-]+[a-zA-Z0-9]\.[a-zA-Z]{2,6}\b");

            if (regex.IsMatch(text))
            {
                Console.WriteLine("In the text there is Email :");
                foreach (var item in regex.Matches(text))
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
                Console.WriteLine("In the text there isn't Email.");
        }
        static void NumberValidator(string text)
        {
            Regex NormalFormat = new Regex(@"(\b-?(?:[0-9]+)|(?:[0-9]+\.[0-9]+)|(?:[0-9]+,[0-9]+))\b");
            Regex ScienceFormat = new Regex(@"\b(-?((?:[0-9]+)|(?:[0-9]+\.[0-9]+)|(?:[0-9]+,[0-9]+))e-?[0-9]+)\b");

            if (ScienceFormat.IsMatch(text))
                Console.WriteLine("This is science format.");
            else if (NormalFormat.IsMatch(text))
                Console.WriteLine("This is normal format.");
            else
                Console.WriteLine("In the text there isn't number.");
        }
        static void TimeCounter(string text)
        {
            Regex regex = new Regex(@"([0-9]|[01][0-9]|2[0-3]):[0-5][0-9]");

            if (regex.IsMatch(text))
            {
                Console.WriteLine("In the text there is time :");
                foreach (var item in regex.Matches(text))
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
                Console.WriteLine("In the text there isn't time.");
        }
    }
}

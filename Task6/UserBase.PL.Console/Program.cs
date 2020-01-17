using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;
using UserBase.BLL;
using UserBase.Interfaces.BLL;


namespace UserBase_PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserBaseBLL logic = new Logic();

            int select = 0;

            while (true)
            {
                try
                {
                    ShowMenu();

                    while (!int.TryParse(Console.ReadLine(), out select)) ;

                    switch (select)
                    {
                        case 1: PathToStore(); break;
                        case 2: CreateUser(logic); break;
                        case 3: CreateAwards(logic); break;
                        case 4: DeleteUser(logic); break;
                        case 5: RemoveAward(logic); break;
                        case 6: ShowUsers(logic); break;
                        case 7: ShowUserAwards(logic); break;
                        case 8: ShowAwards(logic); break;
                        case 9: AddAwardToUser(logic); break;
                        case 10: RemoveUserAward(logic); break;
                        case 0: return;
                        default: Console.WriteLine("Invalid command"); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : " + e.Message);
                    PressAndClear();
                }
                finally
                {
                    PressAndClear();
                }
            }

        }

        public static void ShowMenu()
        {
            Console.WriteLine("Task 06 DESIGN PATTERNS");
            Console.WriteLine(" 1. Show pathes to storage.\n" +
                              " 2. Create user.\n" +
                              " 3. Create award.\n" +
                              " 4. Remove user.\n" +
                              " 5. Remove award.\n" +
                              " 6. Show all users.\n" +
                              " 7. Show all user's awards.\n" +
                              " 8. Show all award.\n" +
                              " 9. Add award to the user.\n" +
                              " 10. Remove award from the user.\n" +
                              " 0. Exit. \n" +
                              new string('-', 30));
        }
        static void PathToStore()
        {
            Console.WriteLine("Path to store user base: {0}", AppDomain.CurrentDomain.BaseDirectory + "users.xml");
            Console.Write("Path to store award base: {0}", AppDomain.CurrentDomain.BaseDirectory + "awards.xml");
        }
        static void ShowUsers(IUserBaseBLL logic)
        {
            var users = logic.GetAllUsers();
            if (users.ToList().Count == 0)
            {
                Console.WriteLine("No one user found");
            }
            else
            {
                foreach (var item in users)
                {
                    Console.WriteLine("User {0} {1} age {2} awards {3} ID {4}.", item.FirstName, item.LastName, item.Age, item.Awards.Count, item.ID);
                }
            }

        }
        static void ShowAwards(IUserBaseBLL logic)
        {
            var awards = logic.GetAllAwards();
            if (awards.ToList().Count == 0)
            {
                Console.WriteLine("No one award found");
            }
            else
            {
                foreach (var item in awards)
                {
                    Console.WriteLine("Title: {0} ID: {1}", item.Title, item.ID);
                }
            }
        }
        static void ShowUserAwards(IUserBaseBLL logic)
        {
            int id;

            Console.WriteLine("All users:");
            ShowUsers(logic);
            Console.WriteLine(new string('-', 30));

            do
            {
                Console.WriteLine("Input user id: ");
            } while (!int.TryParse(Console.ReadLine(), out id));

            var awards = logic.GetAllUserAwards(id);
            if (awards.Count() == 0)
            {
                Console.WriteLine("This user has no one award.");
            }
            else
            {
                foreach (var item in awards)
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void CreateUser(IUserBaseBLL logic)
        {
            Console.WriteLine("Input first name: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Input last name: ");
            string lName = Console.ReadLine();
            DateTime bday;
            do
            {
                Console.WriteLine("Input Birthday(dd.mm.yyyy): ");


            } while (!DateTime.TryParse(Console.ReadLine(), out bday));
            int id = 0; ;
            do
            {
                Console.WriteLine("Input not occupied id");
            } while (!int.TryParse(Console.ReadLine(), out id));
            Console.WriteLine(logic.AddUser(fName, lName, bday, id));
        }
        static void CreateAwards(IUserBaseBLL logic)
        {
            Console.WriteLine("Input award tittle:");
            string title = Console.ReadLine();
            int id;
            do
            {
                Console.WriteLine("Input not occupited id: ");
            } while (!int.TryParse(Console.ReadLine(), out id));
            Console.WriteLine(logic.AddAward(title, id));
        }
        static void AddAwardToUser(IUserBaseBLL logic)
        {
            int userid;
            int awardid;

            Console.WriteLine("All users:");
            ShowUsers(logic);
            Console.WriteLine(new string('-', 30));

            do
            {
                Console.WriteLine("Input user id:");
            } while (!int.TryParse(Console.ReadLine(), out userid));

            Console.WriteLine("All awards:");
            ShowAwards(logic);
            Console.WriteLine(new string('-', 30));

            do
            {
                Console.WriteLine("Input award id:");
            } while (!int.TryParse(Console.ReadLine(), out awardid));
            Console.WriteLine(logic.AddAwardToUser(userid, awardid));
        }
        static void RemoveUserAward(IUserBaseBLL logic)
        {
            int userId;
            int awardId;

            Console.WriteLine("All users:");
            ShowUsers(logic);
            Console.WriteLine(new string('-', 30));

            do
            {
                Console.WriteLine("Input user id:");
            } while (!int.TryParse(Console.ReadLine(), out userId));

            Console.WriteLine("All user's awards:");

            var awards = logic.GetAllUserAwards(userId);
            if (awards.Count() == 0)
            {
                Console.WriteLine("This user has no one award.");
                return;
            }
            else
            {
                foreach (var item in awards)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine(new string('-', 30));

            do
            {
                Console.WriteLine("Input award id:");
            } while (!int.TryParse(Console.ReadLine(), out awardId));
            Console.WriteLine(logic.RemoveUserAward(userId, awardId));
        }
        static void RemoveAward(IUserBaseBLL logic)
        {
            int awardId;

            Console.WriteLine("All awards:");
            ShowAwards(logic);
            Console.WriteLine(new string('-', 30));
            if (logic.GetAllAwards().Count() == 0)
            {
                return;
            }
            do
            {
                Console.WriteLine("Input award id:");
            } while (!int.TryParse(Console.ReadLine(), out awardId));
            Console.WriteLine(logic.RemoveAward(awardId));
        }
        static void DeleteUser(IUserBaseBLL logic)
        {
            int id;

            Console.WriteLine("All users:");
            ShowUsers(logic);
            Console.WriteLine(new string('-', 30));

            if (logic.GetAllUsers().Count() == 0)
            {
                return;
            }

            do
            {
                Console.WriteLine("Input user id:");
            } while (!int.TryParse(Console.ReadLine(), out id));
            Console.WriteLine(logic.RemoveUser(id));
        }
        static void ChangeUser(IUserBaseBLL logic)
        {
            DateTime birthday;
            int id;

            Console.WriteLine("Enter the Id of user which you want to correct : ");
            while (!int.TryParse(Console.ReadLine(), out id)) ;

            var tmp = logic.FindByID(id);

            if (tmp != null)
            {
                Console.WriteLine("Enter new first name : ");
                tmp.FirstName = Console.ReadLine();

                Console.WriteLine("Enter new last name : ");
                tmp.LastName = Console.ReadLine();

                Console.WriteLine("Enter new date of birth(dd.MM.yyyy): ");
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.AllowInnerWhite, out birthday)) ;
                tmp.DateOfBirth = birthday;

                Console.WriteLine("User {0} {1} age {2} with ID {3} is corected.", tmp.FirstName, tmp.LastName, tmp.Age, tmp.ID);

            }
        }
        public static void PressAndClear()
        {
            Console.WriteLine("Press any key...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

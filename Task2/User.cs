using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public int Age
        {
            get
            {
                if (DateTime.Now.Month - Birthday.Month < 0 || (DateTime.Now.Month - Birthday.Month == 0 && DateTime.Now.Day - Birthday.Day < 0))
                {
                    return DateTime.Now.Year - Birthday.Year - 1;
                }
                else
                    return DateTime.Now.Year - Birthday.Year;
            }
        }

        public User(string fName, string lName, string patronomic, DateTime birthday)
        {
            FirstName = fName;
            LastName = lName;
            Patronymic = patronomic;
            Birthday = birthday;
        }
    }
}

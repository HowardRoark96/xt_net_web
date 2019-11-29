using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Employee : User
    {
        private string _post;
        private int _seniority;

        public string Post
        {
            get => _post;

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Exception: Empty string");
                }
                _post = value;
            }
        }
        public int Seniority
        {
            get => _seniority;
            set
            {
                if (value <= Age - 14 && Age > 14)
                {
                    _seniority = value;
                }
                else
                {
                    throw new ArgumentException("Exception: Official employment is possible only from the age of 14 years");
                }
            }
        }

        public Employee(string fName, string lName, string patronymic, DateTime birthday, string post, int seniority) : base(fName, lName, patronymic, birthday)
        {
            Post = post;
            Seniority = seniority;
        }
    }
}

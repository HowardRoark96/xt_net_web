using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBase.Entities
{
    [Serializable]
    public class UserDTO
    {
        private string _name;
        private string _lastName;
        private DateTime _birthday;
        public List<AwardDTO> Awards { get; set; }

        public int ID { get; set; }

        public string FirstName
        {
            get => _name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Incorrect value.");
                }
                _name = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Incorrect value.");
                }
                _lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => _birthday;
            set
            {
                if (value.Year < DateTime.Now.Year && value.Year < DateTime.Now.Year - 14)
                    // A user with an age of less than 14 years is not allowed to be stored in the database
                {
                    _birthday = value;
                }
                else
                {
                    throw new InvalidOperationException("Incorrect value. A user's age have to be more than 14.");
                }
            }
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Month > _birthday.Month || (DateTime.Now.Month == _birthday.Month &&
                    DateTime.Now.Day > _birthday.Day) ? DateTime.Now.Year - _birthday.Year : DateTime.Now.Year - _birthday.Year - 1;
            }
        }
        private UserDTO()
        {
            Awards = new List<AwardDTO>();
        }

        public UserDTO(string firstName, string lastName, DateTime birthday, int id)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = birthday;
            Awards = new List<AwardDTO>();

        }

        public override string ToString()
        {
            return String.Format("{0}. {1} {2}, {3} - {4} years; {5} awards", ID, FirstName, LastName, _birthday.ToShortDateString(), Age, Awards.Count);
        }
    }
}

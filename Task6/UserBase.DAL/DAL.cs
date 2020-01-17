using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBase.Interfaces.DAL;
using UserBase.Entities;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace UserBase.DAL
{
    public class DAL : IUserBaseDAL
    {
        private List<UserDTO> _users;
        private List<AwardDTO> _awards;
        private XmlSerializer _userXml;
        private XmlSerializer _awardXml;

        public DAL()
        {
            _users = new List<UserDTO>();
            _awards = new List<AwardDTO>();

            _userXml = new XmlSerializer(typeof(List<UserDTO>));
            _awardXml = new XmlSerializer(typeof(List<AwardDTO>));
            LoadData();
        }

        public void CreateUser(UserDTO user)
        {
            if (!CheckID(user.ID))
            {
                _users.Add(user);
                SaveData();
            }
            else
            {
                throw new Exception("Person with that ID already exists.");
            }
        }
        public void RemoveUser(UserDTO user)
        {
            if (CheckID(user.ID))
            {
                _users.Remove(_users.Find(x => x.ID == user.ID));
                SaveData();
            }
            else
            {
                throw new Exception("Person with that ID doesn't exist.");
            }
        }
        public void UpdateUser(UserDTO user)
        {
            if (!CheckID(user.ID))
            {
                var tmpUser = _users.First(x => x.ID == user.ID);

                tmpUser.FirstName = user.FirstName;
                tmpUser.LastName = user.LastName;
                tmpUser.DateOfBirth = user.DateOfBirth;
                SaveData();
            }
            else
            {
                throw new Exception("Person with that ID doesn't exist.");
            }
        }


        public void CreateAward(AwardDTO award)
        {
            _awards.Add(award);
            SaveData();
        }
        public void RemoveAward(AwardDTO award)
        {
            _awards.Remove(award);
            foreach (var item in _users)
            {
                if (item.Awards.Contains(award))
                {
                    item.Awards.Remove(award);
                }
            }
            SaveData();
        }

        public void AddAwardToUser(UserDTO user, AwardDTO award)
        {
            _users.FirstOrDefault(x => x == user).Awards.Add(award);
            SaveData();
        }
        public void RemoveAwardFromUser(UserDTO user, AwardDTO award)
        {
            _users.FirstOrDefault(x => x == user).Awards.Remove(award);
            SaveData();
        }


        public IEnumerable<UserDTO> GetAllUsers()
        {
            foreach (var item in _users)
            {
                yield return item;
            }
        }
        public IEnumerable<AwardDTO> GetAllAwards()
        {
            foreach (var item in _awards)
            {
                yield return item;
            }
        }
        public IEnumerable<AwardDTO> GetAllUserAwards(UserDTO user)
        {
            var tmpUser = _users.FirstOrDefault(x => x == user);
            foreach (var item in tmpUser.Awards)
            {
                yield return item;
            }
        }
        public IEnumerable<UserDTO> GetAllUsersWithAward(AwardDTO award)
        {
            var usersWithAward = _users.Where(x => x.Awards.Any(y => y == award));
            foreach (var item in usersWithAward)
            {
                yield return item;
            }
        }

        private bool CheckID(int id)
        {
            bool result = (from item in _users
                           where item.ID == id
                           select true).FirstOrDefault();
            return result;
        }

        public void LoadData()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "users.xml"))
            {
                using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "users.xml"))
                {
                    _users = _userXml.Deserialize(sr) as List<UserDTO>;
                }
            }
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "awards.xml"))
            {
                using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "awards.xml"))
                {
                    _awards = _awardXml.Deserialize(sr) as List<AwardDTO>;
                }
            }
        }
        public void SaveData()
        {
            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "users.xml"))
            {
                _userXml.Serialize(sw, _users);
            }
            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "awards.xml"))
            {
                _awardXml.Serialize(sw, _awards);
            }
        }

    }
}

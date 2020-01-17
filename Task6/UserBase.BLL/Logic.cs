using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBase.Interfaces.BLL;
using UserBase.Interfaces.DAL;
using UserBase.Entities;
using System.Configuration;
using System.IO;

namespace UserBase.BLL
{
    public class Logic : IUserBaseBLL
    {
        private IUserBaseDAL _DAL = new DAL.DAL();

        public string AddUser(string firstName, string lastName, DateTime birthday, int id)
        {
            if (!CheckUserId(id))
            {
                var user = new UserDTO(firstName, lastName, birthday, id);
                _DAL.CreateUser(user);
                return "User added successfully";
            }
            else
                return "Id occupied. Try again";
        }
        public string AddAward(string title, int id)
        {
            if (!CheckAwardId(id))
            {
                var award = new AwardDTO(id, title);
                _DAL.CreateAward(award);
                return "Award added successfully";
            }
            else
                return "Id occupied. Try again";
        }
        public string RemoveUser(int id)
        {
            if (CheckUserId(id))
            {
                _DAL.RemoveUser(GetAllUsers().First(x => x.ID == id));
                return "User was deleted";
            }
            else
                return "Invalid user id";
        }
        public string RemoveAward(int id)
        {
            if (CheckAwardId(id))
            {
                _DAL.RemoveAward(GetAllAwards().First(x => x.ID == id));
                return "Award was deleted";
            }
            else
                return "Invalid award id";
        }
        public string AddAwardToUser(int userID, int awardID)
        {
            if (CheckUserId(userID))
            {
                if (CheckAwardId(awardID))
                {
                    _DAL.AddAwardToUser(GetAllUsers().First(x => x.ID == userID), GetAllAwards().First(x => x.ID == awardID));
                    return "Award was added to user";
                }
                else
                    return "Invalid award id";
            }
            else
                return "Invalid user id";

        }
        public string RemoveUserAward(int userID, int awardID)
        {
            if (CheckUserId(userID))
            {
                if (CheckAwardId(awardID))
                {
                    if (_DAL.GetAllUserAwards(GetAllUsers().First(x => x.ID == userID)).Any(x => x.ID == awardID))
                    {
                        _DAL.RemoveAwardFromUser(GetAllUsers().First(x => x.ID == userID), GetAllAwards().First(x => x.ID == awardID));
                        return "Award was removed from user";
                    }
                    return "The user has not such award.";
                }
                else
                    return "Invalid award id";
            }
            else
                return "Invalid user id";
        }
        public string UpdateUser(UserDTO user)
        {
            if (CheckUserId(user.ID))
            {
                _DAL.UpdateUser(user);
                return "User was updated";
            }
            else
                return "Invalid user id";
        }

        public UserDTO FindByID(int id)
        {
            try
            {
                var user = _DAL.GetAllUsers().FirstOrDefault(x => x.ID == id);
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _DAL.GetAllUsers();
        }
        public IEnumerable<UserDTO> GetUsersByAge()
        {
            try
            {
                var usersByAge = from item in _DAL.GetAllUsers()
                                 orderby item.Age
                                 select item;
                return usersByAge.ToArray();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<UserDTO> GetUsersByCondition(Func<UserDTO, bool> condition)
        {
            try
            {
                var users = _DAL.GetAllUsers().Where(x => condition(x));
                return users.ToArray();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<UserDTO> GetAllUsersWithAward(int idAward)
        {
            if (CheckAwardId(idAward))
            {
                return _DAL.GetAllUsersWithAward(GetAllAwards().First(x => x.ID == idAward));
            }
            else
                return null;
        }
        public IEnumerable<AwardDTO> GetAllAwards()
        {
            return _DAL.GetAllAwards();
        }
        public IEnumerable<AwardDTO> GetAllUserAwards(int idUser)
        {
            if (CheckUserId(idUser))
            {
                return _DAL.GetAllUserAwards(GetAllUsers().First(x => x.ID == idUser));
            }
            else
                return null;
        }

        private bool CheckUserId(int id)
        {
            return _DAL.GetAllUsers().Any(x => x.ID == id);
        }
        private bool CheckAwardId(int id)
        {
            return _DAL.GetAllAwards().Any(x => x.ID == id);
        }
    }
}

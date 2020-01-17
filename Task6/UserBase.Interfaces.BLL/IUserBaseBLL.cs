using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBase.Entities;

namespace UserBase.Interfaces.BLL
{
    public interface IUserBaseBLL
    {
        string AddUser(string firstName, string lastName, DateTime birthday, int id);
        string AddAward(string title, int id);
        string RemoveUser(int id);
        string RemoveAward(int id);
        string AddAwardToUser(int userID, int awardID);
        string RemoveUserAward(int userID, int awardID);
        string UpdateUser(UserDTO user);

        UserDTO FindByID(int id);

        IEnumerable<UserDTO> GetAllUsers();
        IEnumerable<UserDTO> GetUsersByAge();
        IEnumerable<UserDTO> GetUsersByCondition(Func<UserDTO, bool> condition);
        IEnumerable<UserDTO> GetAllUsersWithAward(int idAward);
        IEnumerable<AwardDTO> GetAllAwards();
        IEnumerable<AwardDTO> GetAllUserAwards(int idUser);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBase.Entities;


namespace UserBase.Interfaces.DAL
{
    public interface IUserBaseDAL
    {
        void CreateUser(UserDTO user);
        void CreateAward(AwardDTO award);
        void AddAwardToUser(UserDTO user, AwardDTO award);

        void RemoveUser(UserDTO user);
        void RemoveAward(AwardDTO award);
        void UpdateUser(UserDTO user);
        void RemoveAwardFromUser(UserDTO user, AwardDTO award);


        IEnumerable<UserDTO> GetAllUsers();
        IEnumerable<AwardDTO> GetAllAwards();
        IEnumerable<AwardDTO> GetAllUserAwards(UserDTO user);
        IEnumerable<UserDTO> GetAllUsersWithAward(AwardDTO award);

        void LoadData();
        void SaveData();
    }
}

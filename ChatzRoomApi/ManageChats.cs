using System;
using System.Collections.Generic;
using System.Text;

namespace ChatzRoomApi
{
    public interface IManageChats
    {
        void GetUsers();
        void GetUser(string userName);
        void AddUserFollower(string userName);
        void DeleteUserFollower(string userName);        
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.DataLayer.Entities.User;
using TopLearn.ViewModel.UserViewModels;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAllUser(int skip, int take, int userOnline, bool isDelete);
        List<UserInactiveViewModel> GetUsersInactive(int skip, int take);
        User GetUserById(int userId);
        int UserCount(bool isActive);
        bool UserEmialIsExist(string email);
        string GetUserFristNameById(int userId);
        string GetUserLastNameById(int userId);
        string GetUserImageById(int userId);
        User GetUserByEmail(string email);
        User GetUserByActiveCode(string activeCode);
        bool LoginUser(LoginViewModel login);
        bool UserIsExist(int userId);
        bool UserNameIsExist(string userName);
        List<string> GetUserRolesTitle(int userId);

        bool ActivateUser(int userId, string userEmail,string description,bool isActiva);
        void DisposeUser();
    }

    public interface IUserRepository
    {
        bool InsertRolesToUser(int userId, List<int> rolesId);
        int InsertUser(User user);

        bool UpdateUser(User user);

        string DeleteUser(int userId);


        void SaveUser();

        void DisposeUser();

    }
}

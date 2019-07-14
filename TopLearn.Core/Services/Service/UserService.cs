﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.User;
using TopLearn.Utility.Hasher;
using TopLearn.ViewModel.UserViewModels;

namespace TopLearn.Core.Services.Service
{
    public class UserService : IUserService
    {
        private TopLearnContext _context;



        public UserService(TopLearnContext context)
        {
            _context = context;
        }

        public int UserCount(bool isActive)
        {
            return _context.Users.Where(u => u.UserIsActive == isActive && u.isDelete == false).Count();
        }
        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.UserID == userId);
        }

        public bool UserEmialIsExist(string email)
        {
            return _context.Users.Any(u => u.UserEmail == email);
        }

        public void DisposeUser()
        {
            _context.Dispose();
        }

        public bool LoginUser(LoginViewModel login)
        {
            return _context.Users.Any(u => u.UserEmail == login.UserEmail.ToLower() && u.UserPassword == login.UserPassword.ToEncodePasswordMd5() && u.UserIsActive==true && u.isDelete==false);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.UserEmail == email);
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.UserEmailConfigurationCode == activeCode && u.isDelete==false);
        }

        public string GetUserFristNameById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.UserID == userId).UserFristName;
        }

        public string GetUserLastNameById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.UserID == userId).UserLastName;
        }

        public string GetUserImageById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.UserID == userId).UserImage;
        }

        public bool UserNameIsExist(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName && u.isDelete==false);
        }

        public List<UserInactiveViewModel> GetUsersInactive(int skip, int take)
        {
            return _context.Users.Where(u => u.UserIsActive == false && u.isDelete==false).Select(u => new UserInactiveViewModel
            {
                UserDateTime = u.UserDateTime,
                UserDescription = u.UserDescription,
                UserEmail = u.UserEmail,
                UserId = u.UserID,
                UserLastUpdateDateTime = u.UserLastUpdateDateTime
            }).OrderByDescending(o => o.UserDateTime).Skip(skip).Take(take).ToList();
        }

        public List<UserViewModel> GetAllUser(int skip, int take, int userOnline, bool isDelete)
        {
            return _context.Users.Where(u=>u.UserID != userOnline && u.UserIsActive==true && u.isDelete == isDelete).Select(u => new UserViewModel
            {
                UserId = u.UserID,
                UserEmail = u.UserEmail,
                UserFristName = u.UserFristName,
                UserLastName = u.UserLastName,
                UserBirthday = u.UserBirthday,
                UserDateTime = u.UserDateTime,
                UserEmailConfigurationDateTime = u.UserEmailConfigurationDateTime,
                UserImage = u.UserImage,
                UserIsActive = u.UserIsActive,
                UserName = u.UserName,
                UserRol = "کاربر",
                UserAbout = u.UserAbout
            }).OrderByDescending(o => o.UserDateTime).Skip(skip).Take(take).ToList();
        }
    }


    public class UserRepository : IUserRepository
    {
        private TopLearnContext _context;

        public UserRepository(TopLearnContext context)
        {
            _context = context;
        }
        public int InsertUser(User user)
        {
            try
            {
                _context.Users.Add(user);

                return user.UserID;
            }
            catch 
            {
                return 0;
            }

        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                User user = _context.Users.Where(u => u.UserID == userId).SingleOrDefault();
                user.isDelete = true;
                UpdateUser(user);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void SaveUser()
        {
            _context.SaveChanges();
        }

        public void DisposeUser()
        {
            _context.Dispose();
        }

        public bool InsertRolesToUser(int userId, List<int> rolesId)
        {

            try
            {
                foreach (int roleId in rolesId)
                {
                    _context.UserRoles.Add(new UserRole()
                    {
                        RoleID = roleId,
                        UserID = userId,
                        UserRoleDateTime = DateTime.Now
                    });
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

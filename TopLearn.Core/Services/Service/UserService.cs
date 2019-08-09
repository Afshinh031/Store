using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return _context.Users.Any(u => u.UserEmail == login.UserEmail.ToLower() && u.UserPassword == login.UserPassword.ToEncodePasswordMd5() && u.UserIsActive == true && u.isDelete == false);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.UserEmail == email);
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.UserEmailConfigurationCode == activeCode && u.isDelete == false);
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
            return _context.Users.Any(u => u.UserName == userName && u.isDelete == false);
        }

        public List<UserInactiveViewModel> GetUsersInactive(int skip, int take)
        {
            return _context.Users.Where(u => u.UserIsActive == false && u.isDelete == false).Select(u => new UserInactiveViewModel
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
            return _context.Users.Where(u => u.UserID != userOnline && u.isDelete == isDelete).Select(u => new UserViewModel
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
                UserDescription = u.UserDescription,
                UserAbout = u.UserAbout
            }).OrderByDescending(o => o.UserDateTime).Skip(skip).Take(take).ToList();
        }

        public List<string> GetUserRolesTitle(int userId)
        {
            List<int> rolesId = new List<int>();
            rolesId = _context.UserRoles.Where(r => r.UserID == userId).Select(r => r.RoleID).ToList();
            List<string> rolesTitle = new List<string>();
            foreach (var roleId in rolesId)
            {
                rolesTitle.Add(_context.Roles.Where(x => x.RoleID == roleId).Select(x => x.RoleTitle).SingleOrDefault());
            }
            return rolesTitle;
        }

        public bool ActivateUser(int userId, string userEmail, string description, bool isActiva)
        {
            User user = GetUserById(userId);
            if (user == null || user.UserEmail != userEmail)
                return false;
            UserRepository _userRepository = new UserRepository(_context);
            user.UserIsActive = isActiva;
            user.UserDescription = description;
            if (_userRepository.UpdateUser(user))
            {
                _userRepository.SaveUser();
                return true;
            }
            return false;
        }

        public bool UserIsExist(int userId)
        {
            return _context.Users.Any(u => u.UserID == userId);
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
                _context.SaveChanges();
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

        public string DeleteUser(int userId)
        {
            try
            {
                User user = GetUserById(userId);
                user.isDelete = true;
                UpdateUser(user);
                SaveUser();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
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


        private User GetUserById(int userId) {
            return _context.Users.SingleOrDefault(u => u.UserID == userId);
        }
    }
}

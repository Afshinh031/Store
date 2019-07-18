﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Services.Interfaces;
using TopLearn.Utility.Hasher;
using TopLearn.Utility.TextTools;
using TopLearn.ViewModel.UserViewModels;

namespace TopLearn.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IUserRepository _userRepository;
        public UsersController(IUserService userService, IRoleService roleService,IUserRepository userRepository)
        {
            _userService = userService;
            _roleService = roleService;
            _userRepository = userRepository;
        }

        [Route("Admin/Users")]
        public IActionResult Index(int pageNumber = 1)
        {
            return View(GetUserInfo(pageNumber));
        }

        [HttpPost]
        [Route("Admin/Users")]
        public IActionResult Index([Bind("UserEmail,UserPassworld,roleId,PageNumber")] UserAdminPanelViewModel userAdminPanelViewModel)
        {
            string error = CheckUserInfo(userAdminPanelViewModel);
            if (!string.IsNullOrEmpty(error))
            {
                ModelState.AddModelError("UserEmail", error);
                return View(GetUserInfo(userAdminPanelViewModel.PageNumber));
            }
            var user = new DataLayer.Entities.User.User()
            {
                UserImage = "Defult.jpg",
                UserIsActive = true,
                UserEmailConfigurationCode = TextTools.GenerateUniqCode(),
                UserEmailConfigurationDateTime = DateTime.Now,
                UserDateTime = DateTime.Now,
                UserPassword = userAdminPanelViewModel.UserPassworld.ToEncodePasswordMd5(),
                UserEmail = userAdminPanelViewModel.UserEmail.TextFix(),
                UserLastUpdateDateTime = DateTime.Now,
                UserDescription = "ثبت نام توسط مدیر",
            };
            int userId = _userRepository.InsertUser(user);
            if (userId <= 0)
            {
                ModelState.AddModelError("UserEmail", "خطا در ثبت اطلاعات");
                return View(GetUserInfo(userAdminPanelViewModel.PageNumber));
            }
            _userRepository.InsertRolesToUser(userId, userAdminPanelViewModel.roleId);
            _userRepository.SaveUser();
            return View(GetUserInfo(userAdminPanelViewModel.PageNumber));


        }


        private UserAdminPanelViewModel GetUserInfo(int pageNumber = 1)
        {
            int skip = (pageNumber - 1) * 10;
            UserAdminPanelViewModel userAdminPanelViewModel = new UserAdminPanelViewModel();
            userAdminPanelViewModel.UserModel = _userService.GetAllUser(skip, 10, Convert.ToInt32(User.Identity.Name), false);
            userAdminPanelViewModel.UserInactiveCount = userAdminPanelViewModel.UserModel.Where(u => u.UserIsActive == false).Count();
            userAdminPanelViewModel.UserCount = userAdminPanelViewModel.UserModel.Count;
            userAdminPanelViewModel.roleViewModels = _roleService.GetAllRoles();
            userAdminPanelViewModel.PageNumber = pageNumber;
            return userAdminPanelViewModel;
        }
        private string CheckUserInfo(UserAdminPanelViewModel userAdminPanelViewModel)
        {
            string error = null;
            if (!ModelState.IsValid)
            {
                error = "اطلاعات ارسالی صحیح نمی باشد";
                return error;

            }
            if (string.IsNullOrEmpty(userAdminPanelViewModel.UserEmail) || !(userAdminPanelViewModel.UserEmail.IsValidEmail()))
            {
                error = "ایمیل وارد شده معتبر نیست";
                return error;
            }
            if (userAdminPanelViewModel.roleId == null)
            {
                error = "نقش حتما باید برای کاربر انتخاب شود";
                return error;
            }    
            if (string.IsNullOrEmpty(userAdminPanelViewModel.UserPassworld))
            {
                error = "کلمه عبور معتبر نیست";
                return error;
            }
            if (userAdminPanelViewModel.UserPassworld.Length<6)
            {
                error = "طول کلمه عبور باید بیشتر از 6 کاراکتر باشد";
                return error;
            }
            return error;
        }
    }
}
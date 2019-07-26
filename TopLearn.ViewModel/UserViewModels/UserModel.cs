using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TopLearn.ViewModel.PermissionViewModel;

namespace TopLearn.ViewModel.UserViewModels
{
    #region UserPanel
    public class UserModel
    {


    }

    public class UserViewModel
    {

        public int UserId { get; set; }
        public string UserFristName { get; set; }

        public string UserLastName { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }
        public DateTime UserEmailConfigurationDateTime { get; set; }

        public string UserBirthday { get; set; }

        public string UserImage { get; set; }
        public string UserDescription { get; set; }

        public string UserAbout { get; set; }
        public List<string> UserRol { get; set; }

        public bool UserIsActive { get; set; }

        public DateTime UserDateTime { get; set; }
    }
    public class UserEditProFileViewModel
    {
        public int UserID { get; set; }

        [Display(Name = "نام")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از 200 کاراکتر باشد .")]
        public string UserFristName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از 200 کاراکتر باشد .")]
        public string UserLastName { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از 200 کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "درباره من")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از 500 کاراکتر باشد .")]
        public string UserAbout { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از 300 کاراکتر باشد .")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
        public string UserEmail { get; set; }


        public IFormFile UserImage { get; set; }

        [Display(Name = "تاریخ تولد")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از 10 کاراکتر باشد .")]
        public string UserBirthday { get; set; }
    }

    public class UserinfoViewModel
    {
        public UserViewModel UserViewModel { get; set; }
        public UserEditProFileViewModel UserEditProFileViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
    }
    #endregion

    #region AdminPanel
    public class UserInactiveViewModel
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserDescription { get; set; }
        public DateTime UserDateTime { get; set; }
        public DateTime UserLastUpdateDateTime { get; set; }
    }

    public class UserAdminPanelViewModel
    {
        public int PageNumber { get; set; }
        public List<UserViewModel> UserModel { get; set; }
        public List<UserInactiveViewModel> userInactiveViewModels { get; set; }
        public int UserInactiveCount { get; set; }
        public int UserCount { get; set; }
        public List<RoleViewModel> roleViewModels { get; set; }
        public AddUserAdminPanelViewModel addUserAdminPanelViewModel { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
        public string UserEmail { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserPassworld { get; set; }

        public List<int> roleId { get; set; }

        public bool isSubPermissionsAddUser { get; set; }
        public bool isSubPermissionsEditUser { get; set; }
        public bool isSubPermissionsDeleteUser { get; set; }
    }
    public class AddUserAdminPanelViewModel
    {

    }


    #endregion
}

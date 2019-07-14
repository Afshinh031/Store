using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.ViewModel.UserViewModels
{
    class RoleModel
    {
    }
    public class CreateRoleViewModel {
        public string RoleTitle { get; set; }
        public List<int> PermissionsId { get; set; }
    }
    public class RoleViewModel
    {

        public int RoleID { get; set; }

        [Display(Name = "عنوان نقش")]
        public string RoleTitle { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime RoleDateTime { get; set; }


        [Display(Name = "تاریخ آخرین ویرایش")]
        public Nullable<DateTime> RoleEditeDateTime { get; set; }


        [Display(Name = " آخرین کاربر ویرایش")]
        public Nullable<int> UserEditorID { get; set; }

        [Display(Name = "وضعیت")]
        public bool RoleActive { get; set; }
    }
}

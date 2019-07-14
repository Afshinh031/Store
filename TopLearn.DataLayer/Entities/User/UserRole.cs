using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.DataLayer.Entities.User
{
    public class UserRole
    {
        public UserRole()
        {

        }



        [Key]
        public int URID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int RoleID { get; set; }


        public Nullable<int> UserRegisterID { get; set; }

        public DateTime UserRoleDateTime { get; set; }



        #region Relations

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        #endregion
    }
}

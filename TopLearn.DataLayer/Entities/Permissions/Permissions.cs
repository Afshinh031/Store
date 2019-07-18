using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DataLayer.Entities.Permissions
{
    public class Permissions
    {
        [Key]
        public int PermissionId { get; set; }

        [Display(Name = "عنوان دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PermissionTitle { get; set; }
        public int? ParentID { get; set; }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        [ForeignKey("ParentID")]
        public List<Permissions> Permission { get; set; }

        public List<RolePermissions> RolePermissions { get; set; }

    }
}

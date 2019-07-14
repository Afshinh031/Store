using System;
using System.Collections.Generic;
using System.Text;

namespace TopLearn.ViewModel.PermissionViewModel
{
    class PermissionsModel
    {
    }
    public class PermissionsViewModel
    {
        public int PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public Nullable<int> ParentID { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IRolePermissionsService
    {
    }
    public interface IRolePermissionsRepository
    {
        void InsertRolePermissions(int roleId, List<int> permissionsId);
        void SaveRolePermissions();
    }
}

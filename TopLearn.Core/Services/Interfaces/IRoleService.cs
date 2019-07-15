using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.DataLayer.Entities.User;
using TopLearn.ViewModel.UserViewModels;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IRoleService
    {
        List<RoleViewModel> GetAllRoles();
        RoleViewModel GetAllRoleByRileId(int roleId);
        List<string> GetRolePermissions(int roleId);
    }
    public interface IRoleRepository {
        int InsertRole(string roleName,int userId);

        void SaveRoles();
    }
}

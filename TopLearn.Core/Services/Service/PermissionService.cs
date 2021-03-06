﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.User;
using TopLearn.ViewModel.PermissionViewModel;

namespace TopLearn.Core.Services.Service
{
    public class PermissionService : IPermissionService
    {
        private TopLearnContext _context;

        public PermissionService(TopLearnContext context)
        {
            _context = context;
        }

        public bool CheckPermission(string permissionName, int userId)
        {
            bool isPermission = false;
            List<int> userRolesId = new RoleService(_context).GetUserRolesId(userId);

            if (!userRolesId.Any())
                return isPermission;

            List<int> rolesPermission = GetAllRolesPermission(permissionName);
            if (rolesPermission.Any(p => userRolesId.Contains(p)))
                isPermission = true;
            return isPermission;
        }


        public List<PermissionsViewModel> GetAllPermissions()
        {
            return _context.Permissions.Select(p => new PermissionsViewModel()
            {
                ParentID = p.ParentID,
                PermissionId = p.PermissionId,
                PermissionTitle = p.PermissionTitle
            }).ToList();

        }
        private List<int> GetAllRolesPermission(string permissionName) {
            return _context.RolePermissions.Where(p => p.Permission.PermissionName == permissionName).Select(p => p.RoleId).ToList();
        }
    }
    public class PermissionRepository : IPermissionRepository
    {

    }
}

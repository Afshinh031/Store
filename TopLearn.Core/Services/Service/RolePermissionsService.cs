using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Permissions;

namespace TopLearn.Core.Services.Service
{
    public class RolePermissionsService
    {
    }
    public class RolePermissionsRepository : IRolePermissionsRepository
    {
        private TopLearnContext _cntext;

        public RolePermissionsRepository(TopLearnContext context)
        {
            _cntext = context;
        }

        public void InsertRolePermissions(int roleId, List<int> permissionsId)
        {
            using (var dbContextTransaction = _cntext.Database.BeginTransaction())
            {
                foreach (var item in permissionsId)
                {
                    try
                    {
                        _cntext.RolePermissions.Add(new RolePermissions()
                        {
                            RoleId = roleId,
                            PermissionId = item
                        });
                    }
                    catch {
                        dbContextTransaction.Rollback();
                    }
                }
                dbContextTransaction.Commit();
            }
        }

        public void SaveRolePermissions()
        {
            _cntext.SaveChanges();
        }
    }
}

using System;
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
        public List<PermissionsViewModel> GetAllPermissions()
        {
            return _context.Permissions.Select(p => new PermissionsViewModel()
            {
                ParentID = p.ParentID,
                PermissionId = p.PermissionId,
                PermissionTitle = p.PermissionTitle
            }).ToList();

        }
    }
    public class PermissionRepository : IPermissionRepository
    {

    }
}

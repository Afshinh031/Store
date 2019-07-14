using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.DataLayer.Entities.User;
using TopLearn.ViewModel.PermissionViewModel;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        List<PermissionsViewModel> GetAllPermissions();
    }
    public interface IPermissionRepository
    {

    }
}

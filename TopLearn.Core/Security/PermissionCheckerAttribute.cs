using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Core.Security
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IPermissionService _permissionService;
        private string _permissionName;
        public PermissionCheckerAttribute(string permissionName)
        {
            _permissionName = permissionName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                _permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));
                int userId =Convert.ToInt32(context.HttpContext.User.Identity.Name);
                if(! _permissionService.CheckPermission(_permissionName, userId))
                    context.Result = new RedirectResult("/Login");
            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
    }
}

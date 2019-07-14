using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Services.Interfaces;
using TopLearn.Utility.TextTools;
using TopLearn.ViewModel.PermissionViewModel;
using TopLearn.ViewModel.UserViewModels;

namespace TopLearn.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RolesController : Controller
    {
        private IRoleService _roleService;
        private IRoleRepository _roleRepository;
        private IPermissionService _permissionService;
        private IRolePermissionsRepository _rolePermissionsRepository;
        public RolesController(IRoleService roleService, IRoleRepository roleRepository, IPermissionService permissionService, IRolePermissionsRepository rolePermissionsRepository)
        {
            _roleService = roleService;
            _permissionService = permissionService;
            _roleRepository = roleRepository;
            _rolePermissionsRepository = rolePermissionsRepository;
        }

        [Route("Admin/Roles")]
        public IActionResult Index()
        {
            return View(_roleService.GetAllRoles());
        }


        [Route("Admin/CreateRole")]
        public IActionResult CreateRole()
        {
            ViewBag.Permissions = _permissionService.GetAllPermissions();
            return View();
        }

        [Route("Admin/CreateRole")]
        [HttpPost]
        public IActionResult CreateRole(CreateRoleViewModel role)
        {
            if ((role.RoleTitle == "" || role.RoleTitle == null))
                return RedirectToAction("CreateRole");
            int roleId = _roleRepository.InsertRole(role.RoleTitle.TextFix(), Convert.ToInt32(User.Identity.Name));
            if (roleId > 0 && role.PermissionsId != null)
            {
                _rolePermissionsRepository.InsertRolePermissions(roleId, role.PermissionsId);
                _rolePermissionsRepository.SaveRolePermissions();
                return RedirectToAction("Index");
            }
            if (roleId > 0)
                return RedirectToAction("Index");
            return RedirectToAction("CreateRole");
        }

        [Route("Admin/RoleInfo/{roleId}")]
        public IActionResult RoleInfo(int roleId)
        {
            return View(_roleService.GetAllRoleByRileId(roleId));
        }

    }
}
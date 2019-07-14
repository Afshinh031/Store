using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.User;
using TopLearn.ViewModel.UserViewModels;

namespace TopLearn.Core.Services.Service
{
    public class RoleService: IRoleService
    {
        private TopLearnContext _context;

        public RoleService(TopLearnContext context)
        {
            _context = context;
        }

        public List<RoleViewModel> GetAllRoles()
        {
           return _context.Roles.Where(r => r.isDelete == false).OrderByDescending(r=>r.RoleDateTime).Select(r => new RoleViewModel()
            {
                RoleActive=r.RoleActive,
                RoleDateTime=r.RoleDateTime,
                RoleEditeDateTime=r.RoleEditeDateTime,
                RoleID=r.RoleID,
                RoleTitle=r.RoleTitle,
                UserEditorID=r.UserEditorID

            }).ToList();
        }



        public RoleViewModel GetAllRoleByRileId(int roleId)
        {
            return _context.Roles.Where(r => r.RoleID == roleId).Select(r=>new RoleViewModel() {
                RoleActive = r.RoleActive,
                RoleDateTime = r.RoleDateTime,
                RoleEditeDateTime = r.RoleEditeDateTime,
                RoleID = r.RoleID,
                RoleTitle = r.RoleTitle,
                UserEditorID = r.UserEditorID
            }).SingleOrDefault();
        }


    }
    public class RoleRepository : IRoleRepository

    {
        private TopLearnContext _context;

        public RoleRepository(TopLearnContext context)
        {
            _context = context;
        }
        public int InsertRole(string roleName, int userId)
        {
            Role role = new Role() { 
                RoleActive=true,
                RoleTitle=roleName,
                RoleDateTime=DateTime.Now,
                isDelete=false,
                UserID=userId,
            };
            _context.Roles.Add(role);
            SaveRoles();
            return role.RoleID;
        }

        public void SaveRoles()
        {
            _context.SaveChanges();
        }
    }
}

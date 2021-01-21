using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskProject.Bussiness.Models;
using TaskProject.DataAccess;

namespace TaskProject.Bussiness
{
    public class MerbershipService
    {
        public List<Role> GetRoles()
        {
            using (var context = new TPContext())
            {
                List<Role> roles = (from e in context.Roles where e.IsActive == true select new Role { Id = e.Id, Name = e.Name, IsActive = e.IsActive,CreatedDate = e.CreatedDate }).ToList();
                return roles;
            }
        }
        public string GetUserRole(string username)
        {
            using (var context = new TPContext())
            {
                var temp = (from e in context.Memberships where e.UserName == username select e.RoleId).First();
                var temp2 = (from e in context.Roles where e.Id == temp.Id select e.Name).First();
                return temp2;
            }
        }
        public LoginModel Login(string username, string password)
        {
            LoginModel returndata = new LoginModel();
            using (var context = new TPContext())
            {
                var data = context.Memberships.Where(x => x.UserName == username && x.Password == password).ToList();
                if (data.Count > 0)
                {
                    if (data.First().IsActive == true)
                    {
                        returndata.LoginMessage = "User Found";
                        returndata.UserName = data.First().UserName;
                    }
                    else
                    {
                        returndata.LoginMessage = "User Inactive";
                        returndata.UserName = data.First().UserName;
                    }
                }
                else
                {
                    returndata.LoginMessage = "No User Found";
                    returndata.UserName = null;
                }
                return returndata;
            }
        }
    }
}

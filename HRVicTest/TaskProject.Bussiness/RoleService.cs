using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.DataAccess;
using TaskProoject.DataAccess.Models;

namespace TaskProject.Bussiness
{
    public class RoleService
    {
        public string RegisterUser(Membership membership)
        {
            string returndata = "";
            using (var context = new TPContext())
            {
                Membership membership1 = new Membership();

                context.Memberships.Add(membership1);
                returndata = "Data Created";
            }
            return returndata;

        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using KoohTajrobe.Model.User.Entities;

namespace KoohTajrobe.Model.User
{
    public class Role : IdentityRole
    {
        public DateTime RecordCreateDate { get; set; }

        public List<UserRole> UserRoles { get; set; }
       
    }
}

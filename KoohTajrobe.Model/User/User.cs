using System.Collections.Generic;
using KoohTajrobe.Model.User.Entities;
using Microsoft.AspNetCore.Identity;


namespace KoohTajrobe.Model.User
{
    public class User : IdentityUser
    {
        public List<UserRole> UserRoles { get; set; }
    }
}

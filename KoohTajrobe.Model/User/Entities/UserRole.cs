using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoohTajrobe.Model.User.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        public int Id { get; set; }
        public DateTime STartTime{ get; set; }
        public DateTime EndTime { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }

    }
}

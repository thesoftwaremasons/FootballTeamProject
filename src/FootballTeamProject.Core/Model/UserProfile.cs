using FootballTeamProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamProject.Core.Model
{
    public class UserProfile:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportUrl { get; set; }
        public string IdentityId { get; set; }
    }
   
}

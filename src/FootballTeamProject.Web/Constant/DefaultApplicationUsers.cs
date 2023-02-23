using FootballTeamProject.Infrastructure.Authentication;
using FootballTeamProject.Web.Models;

namespace FootballTeamProject.Web.Constant
{
    public class DefaultApplicationUsers
    {
        public static ApplicationUser GetAdmin()
        {
            var defaultUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "femi-ogundipe@outlook.com",
                FirstName = "Babafemi",
                LastName = "Ogundipe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            return defaultUser;
        }
    }
}

using FootballTeamProject.Infrastructure.Authentication;
using FootballTeamProject.Web.Models;
using System.Security.Claims;

namespace FootballTeamProject.Web.Constant
{
    public class DefaultApplicationRoles
    {
        public const string Admin = "Admin";
        public const string TeamOwner = "TeamOwner";
        public const string TeamCoach = "TeamCoach";
        public const string Player = "Player";

        public static List<ApplicationRole> GetDefaultRoles()
        {
            var roles = new List<ApplicationRole>
            {

                new(Admin),
                new(TeamOwner),
                new(TeamCoach),
                new(Player)
            };
            return roles;
        }

        public static List<Claim> GetDefaultRoleClaims()
        {
            var roles = GetDefaultRoles();
            var claims = roles.Select(role => new Claim(ClaimTypes.Role, role.Name)).ToList();
            return claims;
        }
    }
}

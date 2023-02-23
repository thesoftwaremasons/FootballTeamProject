using FootballTeamProject.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;

namespace FootballTeamProject.Web.Models
{
    public class AppRole : ApplicationRole
    {
        public AppRole(string name) : base(name)
        {
        }
       // public string Description { get; set; }
    }
}

using FootballTeamProject.Core.Model;
using FootballTeamProject.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FootballTeamProject.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);

            builder.Entity<UserProfile>().HasQueryFilter(p => !p.IsDelete);
            builder.Entity<Team>().HasQueryFilter(p => !p.IsDelete);
            builder.Entity<UserTeam>().HasQueryFilter(p => !p.IsDelete);
        }
        public UserProfile UserProfiles { get; set; }
        public Team Teams { get; set; }
        public UserTeam UserTeams { get; set; }
    }
}

﻿using FootballTeamProject.Web.Constant;
using FootballTeamProject.Web.Models;
using FootballTeamProject.Web.Permissions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using FootballTeamProject.Infrastructure.Data;
using FootballTeamProject.Infrastructure.Authentication;

namespace FootballTeamProject.Web
{
    public static class IdentityMigrationManager
    {
        public static IHost MigrateAndSeed(this IHost host)
        {
            MigrateDatabaseAsync(host).GetAwaiter().GetResult();
            SeedDatabaseAsync(host).GetAwaiter().GetResult();
            return host;
        }

        public static async Task MigrateDatabaseAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            await using var identityContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            try
            {
                await identityContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ". " + ex.Source);
                throw;
            }
        }

        public static async Task SeedDatabaseAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            try
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                await SeedDefaultUserRolesAsync(userManager, roleManager, PermissionHelper.GetAllPermissions());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ". " + ex.Source);
                throw;
            }
        }

        private static async Task SeedDefaultUserRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, List<Claim> permissions)
        {
            var defaultRoles = DefaultApplicationRoles.GetDefaultRoles();
            if (!await roleManager.Roles.AnyAsync())
            {
                foreach (var defaultRole in defaultRoles)
                {
                    await roleManager.CreateAsync(defaultRole);
                }
            }
            if (!await roleManager.RoleExistsAsync(DefaultApplicationRoles.Admin))
            {
                await roleManager.CreateAsync(new ApplicationRole(DefaultApplicationRoles.Admin));
            }
            var defaultUser = DefaultApplicationUsers.GetAdmin();
            var userByName = await userManager.FindByNameAsync(defaultUser.UserName);
            var userByEmail = await userManager.FindByEmailAsync(defaultUser.Email);
            if (userByName == null && userByEmail == null)
            {
                await userManager.CreateAsync(defaultUser, "Admin");
                foreach (var defaultRole in defaultRoles)
                {
                    await userManager.AddToRoleAsync(defaultUser, defaultRole.Name);
                }
            }

            var role = await roleManager.FindByNameAsync(DefaultApplicationRoles.Admin);
            var rolePermissions = await roleManager.GetClaimsAsync(role);
            var allPermissions = permissions;
            foreach (var permission in allPermissions)
            {
                if (rolePermissions.Any(x => x.Value == permission.Value && x.Type == permission.Type) == false)
                {
                    await roleManager.AddClaimAsync(role, permission);
                }
            }
        }
    }
}

using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
    public static class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            // Returns true If there is any existing user, return
            if (await userManager.Users.AnyAsync()) return;

            // Create Users
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;

            users.UniqueMainPhotoUrl();

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Moderator"}
            };

            foreach(var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach( var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }

            // Create Admin
            var admin = new AppUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator"});

        }
    }

    static class SeedUserExtension
    {
        public static List<AppUser> UniqueMainPhotoUrl(this List<AppUser> users)
        {
            int counter = 1;
            var men = users.Where(u => u.Gender.ToLower() == "male").ToList();
            foreach (var x in men)
            {
                foreach(var photo in x.Photos)
                {
                    photo.Url = "https://randomuser.me/api/portraits/men/" + counter++ + ".jpg";
                }
            }
            // Women
            counter = 1;
            var women = users.Where(u => u.Gender.ToLower() == "female").ToList();
            foreach (var x in women)
            {
                foreach (var photo in x.Photos)
                {
                    photo.Url = "https://randomuser.me/api/portraits/women/" + counter++ + ".jpg";
                }
            }

            return users;
        }
    }
}

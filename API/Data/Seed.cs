﻿using API.Entities;
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
        public static async Task SeedUsers(DataContext context)
        {
            // If there is an existing user, return
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach( var user in users)
            {
                user.UserName = user.UserName.ToLower();

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}

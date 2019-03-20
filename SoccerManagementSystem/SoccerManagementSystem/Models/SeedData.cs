
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerManagementSystem.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDBContext context = app.ApplicationServices.GetRequiredService<AppDBContext>();
            context.Database.Migrate();
            if (!context.Players.Any())
            {
                context.Players.AddRange(
                     new Player
                     {
                         Name = "Player A",
                         Position = "Attacker"
                     }
                );
            };
            if (!context.Clubs.Any())
            {
                context.Clubs.AddRange(
                     new Club
                     {
                         Name = "Flamengo",
                         Foundation = new DateTime(1895, 11, 19),
                         CresteLinkAddress = "/images/flamengo_logo.png",
                         City = "Rio de Janeiro",
                         Country = "Brazil",
                         //TODO: load players
                         //players = context.Players.ToList()
                     },
                    new Club
                    {
                        Name = "Real Madrid",
                        Foundation = new DateTime(1902, 03, 06),
                        CresteLinkAddress = "/images/real_madrid.jpg",
                        City = "Madrid",
                        Country = "Spain"
                    }
                );
            }
            context.SaveChanges();
        }
    }
}

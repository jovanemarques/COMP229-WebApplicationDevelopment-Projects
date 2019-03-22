
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
                         Players = new List<Player>()
                         {
                            new Player
                            {
                                Name = "Player A",
                                Position = "Defender",
                                hasTeam = true
                            },
                            new Player
                            {
                                Name = "Player B",
                                Position = "Goalkeeper",
                                hasTeam = true
                            }
                         }
                     },
                    new Club
                    {
                        Name = "Real Madrid",
                        Foundation = new DateTime(1902, 03, 06),
                        CresteLinkAddress = "/images/real_madrid.jpg",
                        City = "Madrid",
                        Country = "Spain",
                        Players = new List<Player>()
                         {
                            new Player
                            {
                                Name = "Player C",
                                Position = "Midfielder",
                                hasTeam = true
                            },
                            new Player
                            {
                                Name = "Player D",
                                Position = "Forward",
                                hasTeam = true
                            },
                            new Player
                            {
                                Name = "Player E",
                                Position = "Winger",
                                hasTeam = true
                            }
                         }
                    }
                );
                //context.Clubs.FirstOrDefault(c => c.ClubID == 1).Players.AddRange(context.Players.Where(p => p.PlayerID == 1 || p.PlayerID == 2));
                //context.Clubs.FirstOrDefault(c => c.ClubID == 2).Players.AddRange(context.Players.Where(p => p.PlayerID == 3 || p.PlayerID == 4));
            }
            context.SaveChanges();
        }
    }
}

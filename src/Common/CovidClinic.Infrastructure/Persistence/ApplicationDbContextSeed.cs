using System.Linq;
using System.Threading.Tasks;
using CovidClinic.Infrastructure.Identity;
using CovidClinic.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CovidClinic.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var defaultUser = new ApplicationUser { UserName = "akazad", Email = "akazad@demo.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "11!!qqQQ");
                await userManager.AddToRolesAsync(defaultUser, new[] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleCityDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Cities.Any())
            {
                context.Cities.Add(new City
                {
                    Rank = 1,
                    Name = "Newark",
                    Population = 306247
                });

                context.Cities.Add(new City
                {
                    Rank = 2,
                    Name = "Jersey City",
                    Population = 287146
                });

                context.Cities.Add(new City
                {
                    Rank= 3,
                    Name = "Paterson",
                    Population = 157927
                });

                context.Cities.Add(new City
                {
                    Rank = 4,
                    Name = "Elizabeth",
                    Population = 135772
                });

                context.Cities.Add(new City
                {
                    Rank = 5,
                    Name = "Lakewood",
                    Population = 130221
                });

                context.Cities.Add(new City
                {
                    Rank = 6,
                    Name = "Edison",
                    Population = 106909
                });

                context.Cities.Add(new City
                {
                    Rank = 7,
                    Name = "Woodbridge",
                    Population = 103353
                });

                context.Cities.Add(new City
                {
                    Rank = 8,
                    Name = "Toms River",
                    Population = 95002
                });

                context.Cities.Add(new City
                {
                    Rank = 9,
                    Name = "Hamilton township",
                    Population = 91557
                });

                context.Cities.Add(new City
                {
                    Rank = 10,
                    Name = "Trenton",
                    Population = 90097
                });

                context.Cities.Add(new City
                {
                    Rank = 11,
                    Name = "Clifton",
                    Population = 89460
                });

                context.Cities.Add(new City
                {
                    Rank = 12,
                    Name = "Cherry Hill",
                    Population = 74203
                });

                context.Cities.Add(new City
                {
                    Rank = 13,
                    Name = "Brick",
                    Population = 73745
                });

                context.Cities.Add(new City
                {
                    Rank = 14,
                    Name = "Camden",
                    Population = 72381
                });

                context.Cities.Add(new City
                {
                    Rank = 15,
                    Name = "Bayonne",
                    Population = 70553
                });

                context.Cities.Add(new City
                {
                    Rank = 16,
                    Name = "Passaic",
                    Population = 70308
                });

                context.Cities.Add(new City
                {
                    Rank = 17,
                    Name = "East Orange",
                    Population = 68918
                });

                context.Cities.Add(new City
                {
                    Rank =18,
                    Name = "Union City",
                    Population = 67903
                });

                context.Cities.Add(new City
                {
                    Rank =19,
                    Name = "Franklin township",
                    Population = 67867
                });

                context.Cities.Add(new City
                {
                    Rank = 20,
                    Name = "Middletown",
                    Population = 67007
                });

                await context.SaveChangesAsync();
            }
        }
    }
}

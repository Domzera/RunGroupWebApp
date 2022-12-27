using RunGroupWebApp.Data.Enum;
using RunGroupWebApp.Models;
using System.Reflection;

namespace RunGroupWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Club
                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Running Club 1",
                            Description = "This is the description of the first cinema",
                            Image = "",
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            },
                            ClubCategory = ClubCategory.City
                         },
                        new Club()
                        {
                            Title = "Running Club 2",
                            Description = "This is the description of the first cinema",
                            Image = "",
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            },
                            ClubCategory = ClubCategory.Endurance
                        },
                        new Club()
                        {
                            Title = "Running Club 3",
                            Description = "This is the description of the first club",
                            Image = "",
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            },
                            ClubCategory = ClubCategory.Trail
                        },
                        new Club()
                        {
                            Title = "Running Club 3",
                            Description = "This is the description of the first club",
                            Image = "",
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Michigan",
                                State = "NC"
                            },
                            ClubCategory = ClubCategory.City
                        }
                    });
                    context.SaveChanges();
                }
                //Racess
                if (!context.Races.Any())
                {
                    context.AddRange(new List<Race>()
                    {
                        new Race()
                        {
                            Title = "Running Race 1",
                            Image = "",
                            Description = "This is the description of the first race",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Race()
                        {
                            Title = "Running Race 2",
                            Image = "",
                            Description = "This is the description of the first race",
                            RaceCategory = RaceCategory.Ultra,
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

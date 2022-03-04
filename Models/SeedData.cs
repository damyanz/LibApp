using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            SeedMembershipTypes(serviceProvider);
            SeedCustomers(serviceProvider);
            SeedGenres(serviceProvider);
            SeedBooks(serviceProvider);
        }

        public static void SeedMembershipTypes(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("Database already seeded with MemberShipTypes");
                    return;
                }

                context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name = "Pay as you go",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name = "Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name = "Quarterly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name = "Annual",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    });
                context.SaveChanges();
            }
        }

        public static void SeedCustomers(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Customers.Any())
                {
                    Console.WriteLine("Database already seeded with Customers");
                    return;
                }

                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Artur Ridley",
                        HasNewsletterSubscribed = false,
                        Birthdate = DateTime.Today,
                        MembershipType = context.MembershipTypes.Single(mt => mt.Id == 1),
                        MembershipTypeId = 1,
                    },
                    new Customer
                    {
                        Name = "Denis Jacobs",
                        HasNewsletterSubscribed = false,
                        Birthdate = DateTime.Today,
                        MembershipType = context.MembershipTypes.Single(mt => mt.Id == 2),
                        MembershipTypeId = 2,
                    },
                    new Customer
                    {
                        Name = "Huma Klein",
                        HasNewsletterSubscribed = false,
                        Birthdate = DateTime.Today,
                        MembershipType = context.MembershipTypes.Single(mt => mt.Id == 3),
                        MembershipTypeId = 3,
                    });

                context.SaveChanges();
            }
        }

        public static void SeedGenres(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Genre.Any())
                {
                    Console.WriteLine("Database already seeded with Genres");
                    return;
                }

                context.Genre.AddRange(
                     new Genre
                     {
                        Id = 1,
                        Name = "Horror",
                     },
                     new Genre
                     {
                        Id = 2,
                        Name = "Romance",
                     },
                     new Genre
                     {
                        Id = 3,
                        Name = "Historical Fiction",
                     });

                context.SaveChanges();
            }
        }

        public static void SeedBooks(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Books.Any())
                {
                    Console.WriteLine("Database already seeded with Books");
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        Name = "Sword of Fire",
                        AuthorName = "Arley Strickland",
                        DateAdded = DateTime.Now,
                        ReleaseDate = DateTime.Today,
                        NumberInStock = 10,
                        NumberAvailable = 10,
                        Genre = context.Genre.Single(g => g.Id == 1),
                        GenreId = 1,
                    },
                    new Book
                    {
                        Name = "The Gold in the Abyss",
                        AuthorName = "Romany Sweet",
                        DateAdded = DateTime.Now,
                        ReleaseDate = DateTime.Today,
                        NumberInStock = 10,
                        NumberAvailable = 10,
                        Genre = context.Genre.Single(g => g.Id == 2),
                        GenreId = 2,
                    },
                    new Book
                    {
                        Name = "Judged for death",
                        AuthorName = "Travis Rennie",
                        DateAdded = DateTime.Now,
                        ReleaseDate = DateTime.Today,
                        NumberInStock = 10,
                        NumberAvailable = 10,
                        Genre = context.Genre.Single(g => g.Id == 3),
                        GenreId = 3,
                    });

                context.SaveChanges();
            }
        }
    }
}
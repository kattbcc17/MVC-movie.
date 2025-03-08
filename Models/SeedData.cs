using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "17 Miracles",
                    ReleaseDate = DateTime.Parse("2011-6-3"),
                    Genre = "Drama/History",
                    Rating = "PG",
                    Price = 5.99M
                },
                new Movie
                {
                    Title = "The Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-12-14"),
                    Genre = "Drama/Adventure",
                    Rating = "PG",
                    Price = 6.99M
                },
                new Movie
                {
                    Title = "Once I Was a Beehive",
                    ReleaseDate = DateTime.Parse("2015-8-14"),
                    Genre = "Comedy/Family",
                    Rating = "PG",
                    Price = 4.99M
                },
                new Movie
                {
                    Title = "The Saratov Approach",
                    ReleaseDate = DateTime.Parse("2013-10-9"),
                    Genre = "Thriller/Drama",
                    Rating = "PG-13",
                    Price = 9.49M
                }
            );
            context.SaveChanges();
        }
    }
}
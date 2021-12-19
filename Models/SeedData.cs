using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CapstoneProject.Data;

namespace CapstoneProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CapstoneProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CapstoneProjectContext>>()))
            {
                // Look for any albums.
                if (context.Album.Any())
                {
                    return; // DB has been seeded
                }

                context.Album.AddRange(
                    new Album
                    {
                        Artist = "Nirvana",
                        AlbumName = "Nevermind",
                        Genre = "Alternative Rock",
                        ReleaseDate = 1991,
                        AlbumStatus = "Diamond"
                    },

                    new Album 
                    {
                        Artist = "The Eagles",
                        AlbumName = "Hotel California",
                        Genre = "Classic Rock",
                        ReleaseDate = 1976,
                        AlbumStatus = "Platinum"
                    },

                    new Album 
                    {
                        Artist = "Michael Jackson",
                        AlbumName = "Bad",
                        Genre = "Pop",
                        ReleaseDate = 1987,
                        AlbumStatus = "Platinum"
                    },

                    new Album
                    {
                        Artist = "Boston",
                        AlbumName = "Boston",
                        Genre = "Classic Rock",
                        ReleaseDate = 1976,
                        AlbumStatus = "Gold"
                    });
                context.SaveChanges();

            }
        }
    }
}

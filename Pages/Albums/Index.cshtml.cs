using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Data;
using CapstoneProject.Models;

namespace CapstoneProject.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly CapstoneProject.Data.CapstoneProjectContext _context;

        public IndexModel(CapstoneProject.Data.CapstoneProjectContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string ArtistSort { get; set; }
        [BindProperty(SupportsGet = true)]
        public string AlbumGenres { get; set; }
        public SelectList Genre { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            ArtistSort = sortOrder;

            IQueryable<string> genreQuery = from g in _context.Album
                                            orderby g.Genre
                                            select g.Genre;

            var albums = from m in _context.Album 
                         select m;

            if(!string.IsNullOrEmpty(SearchString))
            {
                albums = albums.Where(m => m.Artist.Contains(SearchString));
            }

            if (ArtistSort == "desc")
            {
                albums = albums.OrderByDescending(x => x.Artist);
            }
            
            else
            {
                albums = albums.OrderBy(x => x.Artist);
            }

            Album = await albums.AsNoTracking().ToListAsync();

            Genre = new SelectList(await genreQuery.Distinct().ToListAsync());
        }
    }
}

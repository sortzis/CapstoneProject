using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task OnGetAsync()
        {
            Album = await _context.Album.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.MvcMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.MvcMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        /*public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }*/
        /*public async Task<IActionResult> OnGetAsync(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                Movie = await _context.Movie.Where(s => s.Title.Contains(searchString)).ToListAsync();
            }
            else
            {
                Movie = await _context.Movie.ToListAsync();
            }
            return Page();
        }*/

        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();
        }
    }
}

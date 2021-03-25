using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages
{
    public class ShowAllModel : PageModel
    {
        private readonly RazorPagesMovie.Data.MvcMovieContext _context;

        public ShowAllModel(RazorPagesMovie.Data.MvcMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        /*public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }*/
        /*public async Task OnGetAsync(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString)) {
                Movie = await _context.Movie.Where(s => s.Title.Contains(searchString)).ToListAsync();
            } else {
                Movie = await _context.Movie.ToListAsync();
            }
        }*/

        public async Task<IActionResult> OnGetAsync(string searchString = "ghost")
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                Movie = await _context.Movie.Where(s => s.Title.Contains(searchString)).ToListAsync();
            } else
            {
                Movie = await _context.Movie.ToListAsync();
            }
            return Page();
        }

        /*public async Task<IActionResult> OnGetAsync(string searchString)
        {
            /*if (!String.IsNullOrEmpty(searchString))
            {
                Movie = await _context.Movie.Where(p => !Movie.Any(p2 => p2.Title == searchString)).ToListAsync();
                Movie = await _context.Movie.Where(s => s.Title.Contains(searchString)).ToListAsync();
            } else
            {
                Movie = await _context.Movie.ToListAsync();
            }

            return Page();
        }*/
    }
}

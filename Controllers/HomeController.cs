using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SongManagement.Data;
using SongManagement.Models;
using System.Diagnostics;

namespace SongManagement.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(string searchString)
        {
                        
            SongGenreViewModel viewModel = new SongGenreViewModel();
            viewModel.GenreList = context.Genres.OrderBy(g => g.Name).ToList();
            viewModel.SongList = context.Songs.OrderBy(s => s.Id).ToList();
                        
            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel.SongList = context.Songs.Where(s=> s.Title.Contains(searchString)).ToList();
                
            }
            return View(viewModel);
        }

        [Authorize]
        public IActionResult Add() {
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Action = "Add";
            return View("Edit", new Song());
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id) 
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Songs = context.Songs.OrderBy(s => s.Artist).ToList();
            var song = context.Songs.Find(id);
            return View(song);
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Song song) 
        { 
            if (ModelState.IsValid)
            {
                if (song.Id == 0)
                {
                    context.Songs.Add(song);
                }
                else
                {
                    context.Songs.Update(song);
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
                ViewBag.Songs = context.Songs.OrderBy(s => s.Artist).ToList();
                ViewBag.Action = (song.Id == 0) ? "Add" : "Edit";
                return View(song);
            }
        
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var song = context.Songs.Find(id);
            return View(song);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(Song song)
        {
            ViewBag.Action = "Delete";
            context.Songs.Remove(song);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
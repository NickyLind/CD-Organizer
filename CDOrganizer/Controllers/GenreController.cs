using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;

namespace CDOrganizer.Controllers
{
  public class GenreController : Controller
  {
    [HttpGet("/genres")]
    public ActionResult Index()
    {
      List<Genre> allGenres = Genre.GetAll();
      return View(allGenres);
    }

    [HttpGet("/genres/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/genres")]
    public ActionResult Create(string genreName)
    {
      Genre newGenre = new Genre(genreName);
      return RedirectToAction("Index");
    }

    // This creates new Albums within a given Genre, not new Genres
    [HttpPost("/genres/{genreId}/album")]
    public ActionResult Create(int genreId, string albumName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Genre foundGenre = Genre.Find(genreId);
      Album newAlbum = new Album(albumName);
      foundGenre.AddAlbum(newAlbum);
      List<Album> genreAlbums = foundGenre.Albums;
      model.Add("items", genreAlbums);
      model.Add("genre", foundGenre);
      return View("Show", model);
    }

    [HttpGet("/genres/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Genre selectedGenre = Genre.Find(id);
      List<Album> genreAlbums = selectedGenre.Albums;
      model.Add("genre", selectedGenre);
      model.Add("albums", genreAlbums);
      return View(model);
    }
  }
}
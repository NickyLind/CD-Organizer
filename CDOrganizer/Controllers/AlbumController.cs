using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;

namespace CDOrganizer.Controllers
{
  public class AlbumController : Controller
  {
    [HttpGet("/genres/{genreId}/album/new")]
    public ActionResult New(int genreId)
    {
      Genre genre = Genre.Find(genreId);
      return View(genre);
    }

    [HttpGet("/genres/{genreId}/album/{albumId}")]
    public ActionResult Show(int genreId, int albumId)
    {
      Album album = Album.Find(albumId);
      Genre genre = Genre.Find(genreId);
      Dictionary<string, object> model = new Dictionary<string, object> ();
      model.Add("album", album);
      model.Add("genre", genre);
      return View(model);
    }

    [HttpPost("/album/delete")]
    public ActionResult DeleteAll()
    {
      Album.ClearAll();
      return View();
    }
  }
}
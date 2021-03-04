using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;

namespace CDOrganizer.Controllers
{
  public class AlbumController : Controller
  {
    [HttpGet("/album")]
    public ActionResult Index()
    {
      List<Album> allAlbums = Album.GetAll();
      return View(allAlbums);
    }

    [HttpGet("/album/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/album")]
    public ActionResult Create(string albumName)
    {
      Album newAlbum = new Album(albumName);
      return RedirectToAction("Index");
    }

    [HttpGet("/album/{id}")]
    public ActionResult Show(int id)
    {
      Album foundAlbum = Album.Find(id);
      return View(foundAlbum);
    }

    [HttpPost("/album/delete")]
    public ActionResult DeleteAll()
    {
      Album.ClearAll();
      return View();
    }
  }
}
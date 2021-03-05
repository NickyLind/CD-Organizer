using Microsoft.VisualStudio.TestTools.UnitTesting;
using CDOrganizer.Models;
using System.Collections.Generic;
using System;

namespace CDOrganizer.Tests
{
  [TestClass]
  public class GenreTests : IDisposable
  {
    public void Dispose()
    {
      Genre.ClearAll();
    }

    [TestMethod]
    public void GenreContructor_CreatesInstanceOfGenre_Genre()
    {
      Genre newGenre = new Genre("rock");
      Assert.AreEqual(typeof(Genre), newGenre.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "rock";
      Genre newGenre = new Genre(name);
      string result = newGenre.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsGenreId_Int()
    {
      string name = "rock";
      Genre newGenre = new Genre(name);
      int result = newGenre.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllGenreObjects_GenreList()
    {
      string name01 = "rock";
      string name02 = "rap";
      Genre newGenre1 = new Genre(name01);
      Genre newGenre2 = new Genre(name02);
      List<Genre> newList = new List<Genre>{ newGenre1, newGenre2 };
      List<Genre> result = Genre.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectGenre_Genre()
    {
      string name01 = "rock";
      string name02 = "rap";
      Genre newGenre1 = new Genre(name01);
      Genre newGenre2 = new Genre(name02);
      Genre result = Genre.Find(2);
      Assert.AreEqual(newGenre2, result);
    }

    [TestMethod]
    public void AddAlbum_AssociatesAlbumWithGenre_AlbumList()
    {
      // Arrange
      string albumName = "Hybrid Theory";
      Album newAlbum = new Album(albumName);
      List<Album> newList = new List<Album> { newAlbum };
      string genreName = "rock";
      Genre newGenre = new Genre(genreName);
      newGenre.AddAlbum(newAlbum);

      // Act
      List<Album> result = newGenre.Albums;

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}
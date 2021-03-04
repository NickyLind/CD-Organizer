using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using CDOrganizer.Models;

namespace CDOrganizer.Tests
{
  [TestClass]
  public class AlbumTests : IDisposable
  {
    public void Dispose()
    {
      Album.ClearAll();
    }

    [TestMethod]
    public void AlbumConstructor_CreateInstanceOfAlbum_Album()
    {
      Album newAlbum = new Album("Test album");
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsAlbumName_String()
    {
      string name = "Meteora";
      Album newAlbum = new Album(name);
      string result = newAlbum.Name;
      Assert.AreEqual(name, result);
    }
    
    [TestMethod]
    public void GetId_ReturnAlbumId_Int()
    {
      string name = "Meteora";
      Album newAlbum = new Album(name);
      int result = newAlbum.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnAllInstanceOfAlbum_AlbumList()
    {
      string name01 = "Meteora";
      string name02 = "Hybrid Theory";
      Album newAlbum1 = new Album(name01);
      Album newAlbum2 = new Album(name02);
      List<Album> newList = new List<Album> {newAlbum1, newAlbum2};
      List<Album> result = Album.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectAlbum_Album()
    {
      string name01 = "Meteora";
      string name02 = "Hybrid Theory";
      Album newAlbum1 = new Album(name01);
      Album newAlbum2 = new Album(name02);
      Album result = Album.Find(2);
      Assert.AreEqual(newAlbum2, result);
    }
  }
}
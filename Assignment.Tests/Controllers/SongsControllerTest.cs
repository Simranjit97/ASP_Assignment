using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Assignment;
using Assignment.Controllers;

using NUnit;
using Moq;
using Assignment.Models;
using NUnit.Framework;
using Assignment.Core;

namespace Assignment.Tests.Controllers
{
    [TestFixture]
    public class SongsControllerTest
    {

        [Test]
        public void Index()
        {
            // Arrange
            SongsController _controller = new SongsController();

            // Act
            ViewResult result = _controller.Index() as ViewResult;

            // Assert
            NUnit.Framework.Assert.IsNotNull(result);

            NUnit.Framework.Assert.AreSame(result.ViewData["Message"], "I made this project to keep track of songs that I have.");
        }

        [Test]
        public void Create()
        {
            // Arrange
            SongsController controller = new SongsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreSame(controller.User.Identity.Name, "Abc@123");
            Assert.AreSame(controller.Create(), "Jason");
            Assert.AreSame(controller.Request.Headers["X-Requested-With"].ToString(), "XMLHttpRequest");
        }

        [Test]
        public void Edit()
        {
            // Arrange
            SongsController controller = new SongsController();

            // Act
            ViewResult result = controller.Edit(5) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void EditArtist()
        {
            // Arrange
            SongsController controller = new SongsController();

            // Act
            ViewResult result = controller.Edit(5) as ViewResult;

            // Assert
            Assert.AreEqual("ACDC", result.ViewBag.Artist);
            Assert.AreNotEqual("Greenday", result.ViewBag.Artist);
            Assert.IsNull(result.ViewBag.Artist);
            Assert.IsNotNull(result.ViewBag);
        }

        [Test]
        public void Delete()
        {
            // Arrange
            SongsController controller = new SongsController();

            // Act
            ViewResult result = controller.Delete(6) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MockTest()
        {
            var mock = new Mock<IGetDataRepository>();
            mock.Setup(p => p.GetSongById(1)).Returns("Summer of 69");
            SongsController song = new SongsController(mock.Object);
            string result = song.GetSongById(1);
            NUnit.Framework.Assert.AreEqual("Summer of 69", result);
        }

        [Test]
        public void MockTest_id()
        {
            var mock = new Mock<IGetDataRepository>();
            mock.Setup(p => p.GetSongById(2)).Returns("Get Low");
            SongsController song = new SongsController(mock.Object);
            string result = song.GetSongById(2);
            NUnit.Framework.Assert.AreEqual("Get Low", result);
        }

    }
}

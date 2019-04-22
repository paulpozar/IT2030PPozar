using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStore.Controllers;
using MovieStore.Models;
using System.Linq;
using Moq;
using System.Data.Entity;

namespace MovieStore.Tests.Controllers
{
    [TestClass]
    public class MovieStoreControllerTest
    {
        [TestMethod]
        public void MovieStore_Index_TestView()
        {
            MoviesController controller = new MoviesController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Create_TestView()
        {
            MoviesController controller = new MoviesController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Edit_TestView()
        {
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman"},
                new Movie() {MovieId = 2, Title = "Batman"}
            }.AsQueryable();
            Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.Setup(m => m.Find(It.IsAny<object>())).Returns(list.First());
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);
            MoviesController controller = new MoviesController(mockContext.Object);
            ViewResult result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Delete_TestView()
        {
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman"},
                new Movie() {MovieId = 2, Title = "Batman"}
            }.AsQueryable();
            Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.Setup(m => m.Find(It.IsAny<object>())).Returns(list.First());
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);
            MoviesController controller = new MoviesController(mockContext.Object);
            ViewResult result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_ListOfMovies_TestView()
        {
            MoviesController controller = new MoviesController();
            List<Movie> result = controller.ListOfMovies();
            Assert.IsNotNull(result);
            Assert.AreEqual("Iron Man", result[0].Title);
            Assert.AreEqual("Thor", result[1].Title);
            Assert.AreEqual("Captain America", result[2].Title);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_Success()
        {
            MoviesController controller = new MoviesController();
            RedirectToRouteResult result = controller.IndexRedirect(1) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.RouteValues["action"]);
            Assert.AreEqual("HomeController", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_BadRequest()
        {
            MoviesController controller = new MoviesController();
            HttpStatusCodeResult result = controller.IndexRedirect(0) as HttpStatusCodeResult;
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_ListFromDB()
        {
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman"},
                new Movie() {MovieId = 2, Title = "Batman"}
            }.AsQueryable();
            Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);
            MoviesController controller = new MoviesController(mockContext.Object);
            ViewResult result = controller.ListFromDB() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_FindFromDB()
        {
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman"},
                new Movie() {MovieId = 2, Title = "Batman"}
            }.AsQueryable();
            Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.Setup(m => m.Find(It.IsAny<object>())).Returns(list.First());
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);
            MoviesController controller = new MoviesController(mockContext.Object);
            ViewResult result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_IdIsNull()
        {
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman"},
                new Movie() {MovieId = 2, Title = "Batman"}
            }.AsQueryable();
            Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.Setup(m => m.Find(It.IsAny<object>())).Returns(list.First());
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);
            MoviesController controller = new MoviesController(mockContext.Object);
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_MovieIsNull()
        {
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman"},
                new Movie() {MovieId = 2, Title = "Batman"}
            }.AsQueryable();
            Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            Movie movie = null;
            mockSet.Setup(m => m.Find(It.IsAny<object>())).Returns(movie);
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);
            MoviesController controller = new MoviesController(mockContext.Object);
            HttpStatusCodeResult result = controller.Details(0) as HttpStatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }
    }
}

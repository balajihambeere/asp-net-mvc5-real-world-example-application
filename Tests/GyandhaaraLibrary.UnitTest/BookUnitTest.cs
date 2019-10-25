using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GyandhaaraLibrary.Service.Interfaces;
using GyandhaaraLibrary.Service;
using GyandhaaraLibrary.DataModel;
using System.Linq;
namespace GyandhaaraLibrary.UnitTest
{
    [TestClass]
    public class BookUnitTest
    {
        [TestMethod]
        public void CreateBook_saves_a_Book_via_context()
        {

            ////Arrange
            //IBookService service = new BookService();

            ////Act
            //var actual = DummyBookData();
            //var bookId = service.Add(actual);

            //var expected = service.FindBy(b => b.BookID == bookId);

            ////Assert
            //Assert.IsTrue(expected.BookID > 0);
            //Assert.AreEqual(expected.Code, actual.Code);
            //Assert.AreEqual(expected.Title, actual.Title);
            //Assert.AreEqual(expected.Description, actual.Description);
            //Assert.AreEqual(expected.Isbn, actual.Isbn);
            //Assert.AreEqual(expected.Edition, actual.Edition);
            //Assert.AreEqual(expected.Author, actual.Author);
            //Assert.AreEqual(expected.Price, actual.Price);
            //Assert.AreEqual(expected.Publisher, actual.Publisher);
            //Assert.AreEqual(expected.RackNumber, actual.RackNumber);

        }

        private Book DummyBookData()
        {
            return new Book
            {
                Code = "783161484100",
                Title = "Pro EntityFramework",
                Description = "EntityFramework",
                Isbn = "783161484100",
                TotalPages = 456,
                Edition = "2nd",
                Author = "Balaji Hambeere",
                Price = 450.00M,
                Publisher = "Gyandhaara",
                PublishDate = DateTime.Now,
                EntryDate = DateTime.Now,
                RackNumber = 2
            };
        }
    }
}

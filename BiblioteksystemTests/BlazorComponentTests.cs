using Bunit;
using LibrarySystem.Core;
using LibrarySystem.Data.Interfaces;
using LibrarySystem.Web.Components.Pages;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;


namespace BiblioteksystemTests
{
    public class BlazorComponentTests : BunitContext
    {
        [Fact]
        public void Books_ShouldRenderHeading()
        {
            // Arrange 
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Book>());

            Services.AddSingleton(mockRepo.Object);

            // Act 
            var cut = Render<Books>();

            // Assert 
            Assert.Contains("Böcker", cut.Find("h1").TextContent);
        }

        [Fact]
        public void Books_ShouldDisplayBookInTable()
        {
            //Arrange
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var books = new List<Book> { book };
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(books);

            Services.AddSingleton(mockRepo.Object);

            //Act
            var cut = Render<Books>();

            //Assert
            Assert.Contains("Hobbit", cut.Find("tbody").TextContent);
        }
        [Fact]
        public void Member_ShouldRenderHeading()
        {
            //Arrange
            var mockRepo = new Mock<IMemberService>();
            mockRepo.Setup(r => r.GetActiveMemberAsync())
                .ReturnsAsync(new List<Member>());

            Services.AddSingleton(mockRepo.Object);
            
            //Act
            var cut = Render<Members>();

            //Assert
            Assert.Contains("Medlem", cut.Find("h1").TextContent);
        }
    }
}
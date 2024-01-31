using globalmsgAPI.Controllers;
using globalmsgAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace globalmsgAPI.Tests;

public class MessageControllerTests
{   




    public class TestMessageContext : MessageContext
    {
        public TestMessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
        }

        public void SetTestMessages(IEnumerable<Message> messages)
        {
            Messages = new TestDbSet<Message>(messages);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class TestDbSet<T> : DbSet<T> where T : class
    {
        private readonly List<T> _data;

        public TestDbSet(IEnumerable<T> data)
        {
            _data = data.ToList();
        }

        public override IEntityType EntityType => throw new NotImplementedException();

        public override IQueryable<T> AsQueryable() => _data.AsQueryable();

        public override EntityEntry<T> Add(T entity)
        {
            _data.Add(entity);
            return null; 
        }
    }


    [Fact]
    public async Task PostMessage_ShouldCreateNewItem()
    {
        var options = new DbContextOptionsBuilder<MessageContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase")
               .Options;

        var testData = new List<Message> {};

        var mockMessageContext = new TestMessageContext(options);
        mockMessageContext.SetTestMessages(testData);

        var controller = new MessageController(mockMessageContext);


        var result = await controller.PostMessage(new Message { ID = 1, Content = "Hola, este es un mensaje de prueba.", User = "Usuario123" });

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.NotNull(createdAtActionResult);
    }


}
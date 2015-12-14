using Moq;
using System;
using System.Linq;
using DripScript.Models;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DripScript.Tests.Models
{
    [TestClass]
    public class DSRepositoryTests
    {   
        private DSRepository repository = new DSRepository();


        [TestMethod]
        public void DSContextEnsureICanCreateInstance()
        {
            DSContext context = new DSContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void DSRepositoryEnsureICanCreatInstance()
        {
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void DSRepositoryEnsureIHaveAContext()
        {
            // Arrange
            DSRepository repository = new DSRepository();

            // Act
            var actual = repository.Context;

            // Assert
            Assert.IsInstanceOfType(actual, typeof(DSContext));

        }

        [TestMethod]
        public void DSRepositoryEnsureICanGetAllEntries()
        {
            // Arrange
            var expected = new List<JournalEntry>
            {
                new JournalEntry {Title = "My Journal", Date = DateTime.Now, Body = "Hello, I love to devolope stuff."},
                new JournalEntry {Title = "My Second Journal", Date = DateTime.Now, Body = "I have this funny story to talk about."}

            };

            Mock<DSContext> mock_context = new Mock<DSContext>();

            Mock<DbSet<JournalEntry>> mock_set = new Mock<DbSet<JournalEntry>>();

            mock_set.Object.AddRange(expected);
            var data_source = expected.AsQueryable();

            mock_set.As<IQueryable<JournalEntry>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<JournalEntry>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<JournalEntry>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<JournalEntry>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(e => e.Entries).Returns(mock_set.Object);
            DSRepository repository = new DSRepository(mock_context.Object);

            // Act
            var actual = repository.GetAllEntries();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

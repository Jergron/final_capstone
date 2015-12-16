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
        Mock<DSContext> mock_context;
        Mock<DbSet<DSUser>> mock_user_set;
        Mock<DbSet<JournalEntry>> mock_set;
        private DSRepository repository;

        private void ConnectMocksToDataStore(IEnumerable<JournalEntry> data_store)
        {
            var data_source = data_store.AsQueryable();

            mock_set.As<IQueryable<JournalEntry>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<JournalEntry>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<JournalEntry>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<JournalEntry>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(e => e.Entries).Returns(mock_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<DSUser> data_store)
        {
            var data_source = data_store.AsQueryable();

            mock_set.As<IQueryable<DSUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<DSUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<DSUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<DSUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(e => e.DSUsers).Returns(mock_user_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<DSContext>();
            mock_user_set = new Mock<DbSet<DSUser>>();
            mock_set = new Mock<DbSet<JournalEntry>>();
            repository = new DSRepository(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_set = null;
            mock_user_set = null;
            repository = null;
        }

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

            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
           
            // Act
            var actual = repository.GetAllEntries();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DSRepositoryEnsureICanSearchByTitle()
        {
            // Arrange
            var expected = new List<JournalEntry>
            {
                new JournalEntry {Title = "Hello Love" },
                new JournalEntry {Title = "What are you waiting for?" },
                new JournalEntry {Title = "Big mistake" },
                new JournalEntry {Title = "You crack me up" },
                new JournalEntry {Title = "Love Language" }

            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            // Act
            string title = "Love";
            List<JournalEntry> expected_titles = new List<JournalEntry>
            {
                new JournalEntry {Title = "Hello Love" },
                new JournalEntry {Title = "Love Language" }
            };
            List<JournalEntry> actual_titles = repository.SearchByTitle(title);

            // Assert
            Assert.AreEqual(expected_titles[0].Title, actual_titles[0].Title);
            Assert.AreEqual(expected_titles[1].Title, actual_titles[1].Title);
        }

        [TestMethod]
        public void DSRepositoryEnsureICanSearchByDate()
        {
            // Arrange
            var expected = new List<JournalEntry>
            {
                new JournalEntry {Date = DateTime.Parse("12/15/2015")},
                new JournalEntry {Date = DateTime.Parse("December 15, 2015") },
                new JournalEntry {Date = DateTime.Parse("12/15/2013") },
                new JournalEntry {Date = DateTime.Parse("07/22/2013")}

            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            // Act
            string date = "12/15/2015";
            List<JournalEntry> expected_dates = new List<JournalEntry>
            {
                new JournalEntry {Date = DateTime.Parse("12/15/2015")},
                new JournalEntry {Date = DateTime.Parse("December 15, 2015") }
            };
            List<JournalEntry> actual_dates = repository.SearchByDate(date);

            // Assert
            Assert.AreEqual(expected_dates[0].Date, actual_dates[0].Date);
            Assert.AreEqual(expected_dates[1].Date, actual_dates[1].Date);
        }

        [TestMethod]
        public void DSRepositoryEnsureICanCreateAJournalEntry()
        {
            // Arrange
            List<JournalEntry> expected_entries = new List<JournalEntry>();
            ConnectMocksToDataStore(expected_entries);
            DSUser dripscript_user = new DSUser {FirstName = "Jeremy", LastName ="Grondahl" };
            string title = "The Zombie Apocolypse";
            string content = "London (AFP) - Are you afflicted by a shambling gait, a tendency to moan and the desire to bite and eat flesh? Watch out -- you could be becoming a zombie, according to the respected British Medical Journal (BMJ).A new article entitled 'Zombie infections: epidemiology, treatment and prevention' details everything from symptoms of infection-- 'people may clinically die and reanimate'-- to how 'zombiism' is transmitted -- 'via bite'.It urges more funding for research into zombie epidemics 'to tackle the looming threat of apocalyptic disease'.The study, by Tara Smith of Kent State University in the US, even comes with meticulous footnotes citing sources such as zombie movies '28 Days Later' and 'Night of the Living Dead'. A spokesman for the BMJ, one of the most respected forums for research in the medical world, explained that the article was part of a light-hearted tradition of running a special Christmas issue. 'All Christmas articles go thorough our usual peer-review processes,' the spokesman added. 'The subject matter is quirky and fun, but they use proper research methods and have to stand up scientifically.'";
            mock_set.Setup(e => e.Add(It.IsAny<JournalEntry>())).Callback((JournalEntry s) => expected_entries.Add(s));

            // Act
            bool successful = repository.CreateEntry(dripscript_user, content, title);

            // Assert
            Assert.IsTrue(successful);
            Assert.AreEqual(1, repository.GetAllEntries().Count);
        }
    }
}

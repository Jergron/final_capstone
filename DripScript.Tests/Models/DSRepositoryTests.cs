using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DripScript.Models;
using Moq;
using System.Data.Entity;

namespace DripScript.Tests.Models
{
    [TestClass]
    public class DSRepositoryTests
    {
        private Mock<DSContext> mock_context = new Mock<DSContext>();
        private Mock<DbSet<DSUser>> mock_set = new Mock<DbSet<DSUser>>();
        private Mock<DbSet<JournalEntry>> mock_entry_set = new Mock<DbSet<JournalEntry>>();
         
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
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DripScript.Models;
using System.Collections.Generic;

namespace DripScript.Tests.Models
{
    [TestClass]
    public class DSUserTests
    {
        [TestMethod]
        public void DSUserEnsureICanCreateInstance()
        {
            DSUser a_user = new DSUser();
            Assert.IsNotNull(a_user);
        }

        [TestMethod]
        public void DSUserEnsureHasAllThings()
        {
            // Arrange
            DSUser a_user = new DSUser();
            a_user.UserId = 13452;
            a_user.FirstName = "Jeremy";
            a_user.LastName = "Grondahl";
            a_user.Description = "I am a software developer";


            // Assert
            Assert.AreEqual(13452, a_user.UserId);
            Assert.AreEqual("Jeremy", a_user.FirstName);
            Assert.AreEqual("Grondahl", a_user.LastName);
            Assert.AreEqual("I am a software developer", a_user.Description);
        }

        [TestMethod]
        public void DSUserEnsureUserHasJournalEntries()
        {
            // Arrange 
            List<JournalEntry> list_of_entries = new List<JournalEntry>
            {
                new JournalEntry {Date = DateTime.Now, Title ="My Life", Body = "This is how I like to live my life" },
                new JournalEntry {Date = DateTime.Now, Title ="Funny Bones", Body = "I couldn't believe how funny clowns could be!" }
            };
            DSUser a_user = new DSUser { FirstName = "Jeremy", LastName = "Grondahl", Entries = list_of_entries };

            // Act
            List<JournalEntry> actual_entries = a_user.Entries;

            // Assert
            CollectionAssert.AreEqual(list_of_entries, actual_entries); 
        }
    }
}

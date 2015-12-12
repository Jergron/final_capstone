using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DripScript.Models;

namespace DripScript.Tests.Models
{
    [TestClass]
    public class JournalEntryTests
    {
        [TestMethod]
        public void JournalEntryEnsureICanCreateInstance()
        {
            JournalEntry entry = new JournalEntry();
            Assert.IsNotNull(entry);
        }

        [TestMethod]
        public void JournalEntryEnsureEntryHasAllThings()
        {
            // Arrange
            JournalEntry entry = new JournalEntry();
            entry.EntryId = 1234;
            entry.Title = "My New Journal";
            entry.Body = "I like to swim in the summer time.";

            // Assert
            Assert.AreEqual(1234, entry.EntryId);
            Assert.AreEqual("My New Journal", entry.Title);
            Assert.AreEqual("I like to swim in the summer time.", entry.Body);
        }

        [TestMethod]
        public void JournalEntryEnsureEntryIsPublic()
        {
            // Arrange
            JournalEntry entry = new JournalEntry();
            bool expected = true;

            // Act
            bool actual = false;
            actual = entry.isPublic();

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}

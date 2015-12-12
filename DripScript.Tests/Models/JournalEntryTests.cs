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
        public void JournalEntryEnsureEntryHasEntryId()
        {
            // Arrange
            JournalEntry entry = new JournalEntry();
            int expected = 1234;

            // Act
            entry.EntryId = 1234;
            int actual = entry.EntryId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JournalEntryEnsureEntryHasTitle()
        {
            // Arrange
            JournalEntry entry = new JournalEntry();
            string expected = "My New Journal";

            // Act
            entry.Title = "My New Journal";
            string actual = entry.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JournalEntryEnsureEntryHasBody()
        {
            // Arrange
            JournalEntry entry = new JournalEntry();
            string expected = "I like to swin in the summer time.";

            // Act
            entry.Body = "I like to swin in the summer time.";
            string actual = entry.Body;

            // Assert
            Assert.AreEqual(expected, actual);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DripScript.Models
{
    public class DSRepository
    {
        private DSContext _context;

        public DSContext Context { get { return _context; } }
        
        public DSRepository()
        {
            _context = new DSContext();
        }

        public DSRepository(DSContext a_context)
        {
            _context = a_context;
        }

        public List<DSUser> GetAllUsers()
        {
            var query = from users in _context.DSUsers select users;
            return query.ToList();
        }

        public List<JournalEntry> GetAllEntries()
        {
            var query = from entry in _context.Entries select entry;
            return query.ToList();
        }

        public List<JournalEntry> SearchByTitle(string title)
        {
            var query = from entry in _context.Entries select entry;

            List<JournalEntry> found_title = query.Where(entry => entry.Title.Contains(title)).ToList();
            

            return found_title;
        }

        public List<JournalEntry> SearchByDate(string date)
        {
           
             var query = from entry in _context.Entries select entry;

            List<JournalEntry> found_date = query.Where(entry => entry.Date == DateTime.Parse(date)).ToList();

            return found_date;
        }

        public bool CreateEntry(DSUser dripscript_user, string content, string title)
        {
            JournalEntry a_entry = new JournalEntry { Title = title, Body = content, Date = DateTime.Now, Author = dripscript_user };
            bool is_added = true;
            try
            {
                JournalEntry added_entry = _context.Entries.Add(a_entry);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }
    }
}
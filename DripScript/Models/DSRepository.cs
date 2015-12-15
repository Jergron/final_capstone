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

    }
}
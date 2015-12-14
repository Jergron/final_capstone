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

        public JournalEntry GetEntryById(DSUser user, int entry_id)
        {
            // IQueryable that contains a single DSUser
            var query = from u in _context.DSUsers where u.UserId == user.UserId select u;
            DSUser found_user = query.Single();
            var query2 = from entry in found_user.Entries where entry.EntryId == entry_id select entry;
            JournalEntry found_entry = query2.Single();
            return found_entry;

        }

        public List<JournalEntry> GetUserEntries(DSUser user)
        {
            var query = from u in _context.DSUsers where u.UserId == user.UserId select u;
            DSUser found_user = query.Single();
            return found_user.Entries;
        }

        public List<JournalEntry> GetAllEntries()
        {
            var query = from entry in _context.Entries select entry;
            return query.ToList();
        }

        public bool CreateEntry(DSUser dripscript_user, string content, string title)
        {
            JournalEntry a_entry = new JournalEntry { Title = title, Body = content, Date = DateTime.Now, Author = dripscript_user };
            bool is_added = true;
            try
            {
                JournalEntry added_entry = _context.Entries.Add(a_entry);
                _context.SaveChanges();
                
                if (added_entry == null)
                {
                    is_added = false;   
                }
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }
    }
}
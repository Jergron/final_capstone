using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNet.Identity;

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

        public List<JournalEntry> GetUserEntries(DSUser user)
        {
            if (user != null)
            {
                var query = from u in _context.DSUsers where u.UserId == user.UserId select u;

                var entry_query = from e in _context.Entries where e.Author.UserId == user.UserId select e;

                List<JournalEntry> my_entries = entry_query.ToList();

                DSUser found_user = query.SingleOrDefault();
                if (found_user == null)
                {
                    return new List<JournalEntry>();
                }
                if (my_entries == null)
                {
                    return new List<JournalEntry>();
                }
                return my_entries;
            }
            else
            {
                return new List<JournalEntry>();
            }
        }

        public bool CreateDSUser(ApplicationUser app_user)
        {
            DSUser new_user = new DSUser { RealUser = app_user };
            bool is_added = true;
            try
            {
                DSUser added_user = _context.DSUsers.Add(new_user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }

        public bool RemoveEntry(int id)
        {
            JournalEntry a_entry = Context.Entries.Where(e => e.EntryId == id).First();

            bool is_deleted = true;
            try
            {
                JournalEntry deleted_entry = _context.Entries.Remove(a_entry);
                _context.SaveChanges();
            } 
            catch (Exception)
            {
                is_deleted = false;
            }
            return is_deleted;
        }

        public bool UpdateUser(int id, DSUser update)
        {
            var query = from u in _context.DSUsers where u.UserId == id select u;
            foreach (DSUser u in query)
            {
                u.Description = update.Description;
                u.FirstName = update.FirstName;
                u.LastName = update.LastName;
            }
            bool is_updated = true;
            try
            {
                _context.SaveChanges();  
            }
            catch (Exception)
            {
                is_updated = false;
            }
            return is_updated;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DripScript.Models
{
    public class DSContext : ApplicationDbContext
    {
        public virtual DbSet<DSUser> DSUsers { get; set; }
        public virtual DbSet<JournalEntry> Entries { get; set; }
    }
}
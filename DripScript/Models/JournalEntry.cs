using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DripScript.Models
{
    public class JournalEntry
    {

        [Key]
        public int EntryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public bool isPublic()
        {
            return true;
        }
    }
}
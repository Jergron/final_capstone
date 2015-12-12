using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DripScript.Models
{
    public class JournalEntry : DSUser
    {
        [Key]
        public int EntryId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Author { get { return FirstName + " " + LastName; }}
        public bool isPublic()
        {
            return true;
        }
    }
}
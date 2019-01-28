using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVCApp.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Approval { get; set; }
        public bool HomePage { get; set; }

        // Navigation Properties
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
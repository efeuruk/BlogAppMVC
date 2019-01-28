using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVCApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Navigation Properties
        public List<Blog> Blogs { get; set; }
    }
}
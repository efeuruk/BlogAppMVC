using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMVCApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            // Test data
            List<Category> categories = new List<Category>()
            {
                new Category() { CategoryName="C#"},
                new Category() { CategoryName="Asp.Net MVC"},
                new Category() { CategoryName="Asp.Net Web Form"},
                new Category() { CategoryName="Windows Form"}
            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }

            context.SaveChanges();

            List<Blog> blogs = new List<Blog>()
            {
                new Blog() { Title = "About C# About C# About C# About C# About C# About C# About C# About C# About C# About C# About C# About C# ", Description="About C# About C#", Date = DateTime.Now.AddDays(-10), HomePage=true, Approval=true, Content="About C# About C# About C# About C#", Image="1.jpg", CategoryId=1 },
                new Blog() { Title = "About C# Trial", Description="About C# About C#", Date = DateTime.Now.AddDays(-10), HomePage=true, Approval=true, Content="About C# About C# About C# About C#", Image="1.jpg", CategoryId=1 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-30), HomePage=false, Approval=false, Content="About C# About C# About C# About C#", Image="1.jpg", CategoryId=1 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-20), HomePage=true, Approval=true, Content="About C# About C# About C# About C#", Image="2.jpg", CategoryId=2 },
                new Blog() { Title = "About C# Generic List", Description="About C# About C#", Date = DateTime.Now.AddDays(-5), HomePage=true, Approval=false, Content="About C# About C# About C# About C#", Image="1.jpg", CategoryId=2 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-10), HomePage=false, Approval=false, Content="About C# About C# About C# About C#", Image="2.jpg", CategoryId=2 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-10), HomePage=true, Approval=true, Content="About C# About C# About C# About C#", Image="2.jpg", CategoryId=3 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-10), HomePage=false, Approval=true, Content="About C# About C# About C# About C#", Image="2.jpg", CategoryId=3 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-15), HomePage=true, Approval=true, Content="About C# About C# About C# About C#", Image="1.jpg", CategoryId=3 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-17), HomePage=true, Approval=false, Content="About C# About C# About C# About C#", Image="2.jpg", CategoryId=4 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-10), HomePage=true, Approval=true, Content="About C# About C# About C# About C#", Image="1.jpg", CategoryId=4 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-10), HomePage=true, Approval=true, Content="About C# About C# About C# About C#", Image="1.jpg", CategoryId=4 },
                new Blog() { Title = "About C#", Description="About C# About C#", Date = DateTime.Now.AddDays(-10), HomePage=true, Approval=true, Content="About C# About C# About C# About C#", Image="1.jpg", CategoryId=4 },
            };

            foreach (var item in blogs)
            {
                context.Blogs.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
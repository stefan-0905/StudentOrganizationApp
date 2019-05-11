using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizationLibrary
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Post(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}

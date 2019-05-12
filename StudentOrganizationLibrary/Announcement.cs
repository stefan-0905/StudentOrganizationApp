﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizationLibrary
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Announcement() { }
        public Announcement(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizationLibrary
{
    public class Announcement
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Announcement(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}

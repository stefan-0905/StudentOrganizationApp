﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizationLibrary.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Announcement()
        {
            CreatedAt = DateTime.Now;
        }
        public Announcement(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
        }
    }
}

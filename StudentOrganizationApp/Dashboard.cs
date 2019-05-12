using StudentOrganizationControlLibrary;
using StudentOrganizationLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentOrganizationApp
{
    public partial class Dashboard : Form
    {
        public readonly StOrgDbContext _context = new StOrgDbContext();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void NavigationButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Gold;
        }

        private void NavigationButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.FromArgb(47, 100, 183);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            InitiateAnnouncements();
            dashboardPanel.BringToFront();
        }

        private void InitiateAnnouncements()
        {
            string myheading = "My new HeadinHeadingHeadingHeadingHeadingHeadingHeadingg";
            string mydescription = "My new description about announcement. And something more.";
            string myheading2 = "My new Heading";
            string mydescription2 = "My new description about announcement.";

            Announcement[] announcements = {
                new Announcement(myheading, mydescription),
                new Announcement(myheading2, mydescription2)
            };

            foreach (var announcement in announcements)
            {
                CardControl cardControl = new CardControl(announcement.Title, announcement.Description);
                
                flowLayoutPanel1.Controls.Add(cardControl);
            }
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            this.Text = "Student Organization - Dashboard";
            dashboardPanel.BringToFront();
        }

        private void AnnouncementsButton_Click(object sender, EventArgs e)
        {
            this.Text = "Student Organization - Announcements";
            announcementsPanel.BringToFront();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            CreateNewAnnouncementForm newAnnouncement = new CreateNewAnnouncementForm(this);
            newAnnouncement.Show();
        }
    }
}

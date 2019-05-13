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
        public BindingList<Announcement> Announcements = new BindingList<Announcement>();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void PopulateAnnouncements()
        {
            List<Announcement> announcements = _context.Announcements.ToList();
            foreach(Announcement announcement in announcements)
            {
                Announcements.Add(announcement);
            }
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
            PopulateAnnouncements();

            foreach (var announcement in Announcements.Take(3))
            {
                CardControl cardControl = new CardControl(announcement);
                flowLayoutPanel1.Controls.Add(cardControl);
            }

            announcementsListBox.DataSource = Announcements;
            announcementsListBox.DisplayMember = "Title";
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

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            var confirmDeletion = MessageBox.Show("Are you sure you want to delete this announcement?", "Confirm Delete", MessageBoxButtons.YesNo);
            if(confirmDeletion == DialogResult.Yes)
            {
                Announcement delAnnouncement = (Announcement)announcementsListBox.SelectedItem;
                // Delete announcement from db
                _context.Announcements.Remove(delAnnouncement);
                // Update ListBox 
                Announcements.Remove(delAnnouncement);
                // Update flowLayoutPanel
                foreach(CardControl control in flowLayoutPanel1.Controls)
                {
                    if((int)control.Tag == delAnnouncement.Id)
                    {
                        flowLayoutPanel1.Controls.Remove(control);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}

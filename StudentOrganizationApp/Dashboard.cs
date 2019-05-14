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
                announcementsFLPanel.Controls.Add(cardControl);
            }

            announcementsListBox.DataSource = Announcements;
            announcementsListBox.DisplayMember = "Title";
        }

        private void PopulateAnnouncements()
        {
            List<Announcement> announcements = _context.Announcements.OrderByDescending(x => x.CreatedAt).ToList();
            foreach (Announcement announcement in announcements)
            {
                Announcements.Add(announcement);
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
            CreateOrUpdateAnnouncementForm newAnnouncement = new CreateOrUpdateAnnouncementForm(this);
            newAnnouncement.Show();
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            Announcement delAnnouncement = (Announcement)announcementsListBox.SelectedItem;
            if(delAnnouncement != null)
            { 
                var confirmDeletion = MessageBox.Show("Are you sure you want to delete this announcement?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmDeletion == DialogResult.Yes)
                {

                    // Delete announcement from db
                    _context.Announcements.Remove(delAnnouncement);
                    await _context.SaveChangesAsync();

                    // Update ListBox 
                    Announcements.Remove(delAnnouncement);

                    // Update flowLayoutPanel
                    foreach (CardControl control in announcementsFLPanel.Controls)
                    {
                        if ((int)control.Tag == delAnnouncement.Id)
                        {
                            announcementsFLPanel.Controls.Remove(control);

                            // Reset panel with new set of recent announcements
                            announcementsFLPanel.Controls.Clear();
                            foreach (var announcement in Announcements.Take(3))
                            {
                                CardControl cardControl = new CardControl(announcement);
                                announcementsFLPanel.Controls.Add(cardControl);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No announcement that can be deleted.", "Error occured");
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Announcement announce = (Announcement)announcementsListBox.SelectedItem;
            if (announce != null)
            {
                CreateOrUpdateAnnouncementForm announcementForm = new CreateOrUpdateAnnouncementForm(this, announce);
                announcementForm.Show();
            }
            else
            {
                MessageBox.Show("No announce for edit.", "Error occured");
            }
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            Announcement announce = (Announcement)announcementsListBox.SelectedItem;
            if (announce != null)
            {
                ShowAnnouncementForm announcementShow = new ShowAnnouncementForm(announce);
                announcementShow.Show();
            }
            else
            {
                MessageBox.Show("No announce to show", "Error occured");
            }
        }
    }
}

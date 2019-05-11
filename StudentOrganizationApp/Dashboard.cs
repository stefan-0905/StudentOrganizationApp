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
        public Dashboard()
        {
            InitializeComponent();
            InitiateAnnouncements();
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
                flowLayoutPanel1.Controls.Add(new CardControl(announcement.Title, announcement.Description));
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
    }
}

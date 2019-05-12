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
    public partial class CreateNewAnnouncementForm : Form
    {
        private Dashboard myDashboard;
        public CreateNewAnnouncementForm(Dashboard dash)
        {
            myDashboard = dash;
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void CreateBtn_Click(object sender, EventArgs e)
        {

            if (ValidateForm())
            {
                myDashboard._context.Announcements.Add(new Announcement
                {
                    Title = titleValue.Text,
                    Description = descriptionValue.Text
                });
                await myDashboard._context.SaveChangesAsync();

                this.Close();

            }

        }

        private bool ValidateForm()
        {
            bool validated = true;

            if(string.IsNullOrEmpty(titleValue.Text))
            {
                validated = false;
                titleBackgroundRed.Visible = true;
            }
            else
            {
                titleBackgroundRed.Visible = false;
            }

            if(string.IsNullOrEmpty(descriptionValue.Text))
            {
                validated = false;
                descriptionBackRed.Visible = true;
            }
            else
            {
                descriptionBackRed.Visible = false;
            }

            return validated;
        }
    }
}

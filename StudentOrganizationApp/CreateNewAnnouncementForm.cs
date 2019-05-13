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
                Announcement newAnnounce = new Announcement
                {
                    Title = titleValue.Text,
                    Description = descriptionValue.Text
                };
                myDashboard._context.Announcements.Add(newAnnounce);
                myDashboard.flowLayoutPanel1.Controls.Add(new CardControl(newAnnounce));
                myDashboard.Announcements.Add(newAnnounce);

                await myDashboard._context.SaveChangesAsync();

                this.Close();
            }
        }

        /// <summary>
        /// Validate textbox input.
        /// </summary>
        /// <returns>True if all validates correctly</returns>
        private bool ValidateForm()
        {
            if(BoxIsEmpty(titleValue, titleBackRed) || BoxIsEmpty(descriptionValue, descriptionBackRed))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Check if TextBox is Empty.
        /// </summary>
        /// <param name="textBox">TextBox to check.</param>
        /// <param name="label">Label for displaying behind textbox if it is empty.</param>
        /// <returns>True if it's empty.</returns>
        private bool BoxIsEmpty(TextBox textBox, Label label)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                label.Visible = true;
                return true;
            }
            else
            {
                label.Visible = false;
                return false;
            }
        }

        /// <summary>
        /// Check if RichTextBox is Empty.
        /// </summary>
        /// <param name="textBox">TextBox to check.</param>
        /// <param name="label">Label for displaying behind textbox if it is empty.</param>
        /// <returns>True if it's empty.</returns>
        private bool BoxIsEmpty(RichTextBox textBox, Label label)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                label.Visible = true;
                return true;
            }
            else
            {
                label.Visible = false;
                return false;
            }
        }
    }
}

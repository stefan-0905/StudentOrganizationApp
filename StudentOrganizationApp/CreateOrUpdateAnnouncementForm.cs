using StudentOrganizationControlLibrary;
using StudentOrganizationLibrary.Models;
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
    public partial class CreateOrUpdateAnnouncementForm : Form
    {
        private Dashboard myDashboard;
        private Announcement editAnnounce = null;
        public CreateOrUpdateAnnouncementForm(Dashboard dash, Announcement announce = null)
        {
            myDashboard = dash;
            InitializeComponent();
            if(announce != null)
            {
                editAnnounce = announce;
                this.titleValue.Text = announce.Title;
                this.descriptionValue.Text = announce.Description;
                this.Text = "Edit Announcement";
                this.createBtn.Visible = false;
            }
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
                // Add to DB
                myDashboard._context.Announcements.Add(newAnnounce);
                await myDashboard._context.SaveChangesAsync();

                // Update announcements listBox
                myDashboard.Announcements.Insert(0, newAnnounce);

                // Update panel with new set of recent announcements
                myDashboard.announcementsFLPanel.Controls.Clear();
                foreach (var announcement in myDashboard.Announcements.Take(3))
                {
                    CardControl cardControl = new CardControl(announcement);
                    myDashboard.announcementsFLPanel.Controls.Add(cardControl);
                }
                
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                Announcement recordForUpdate = myDashboard._context.Announcements.SingleOrDefault(x => x.Id == editAnnounce.Id);

                editAnnounce.Title = titleValue.Text;
                editAnnounce.Description = descriptionValue.Text;

                if (recordForUpdate != null)
                {
                    recordForUpdate.Title = editAnnounce.Title;
                    recordForUpdate.Description = editAnnounce.Description;

                    myDashboard._context.SaveChanges();

                    myDashboard.Announcements.ResetBindings();

                    foreach (CardControl control in myDashboard.announcementsFLPanel.Controls)
                    {
                        if ((int)control.Tag == editAnnounce.Id)
                        {
                            ToolTip myToolTip = new ToolTip();
                            myToolTip.SetToolTip(control.headerLabel, editAnnounce.Title);

                            control.headerLabel.Text = editAnnounce.Title;
                            control.descriptionLabel.Text = editAnnounce.Description;
                        }
                    }

                    this.Close();
                }
            }
        }
    }
}

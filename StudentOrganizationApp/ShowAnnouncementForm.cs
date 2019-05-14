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
    public partial class ShowAnnouncementForm : Form
    {
        Announcement Announce;
        public ShowAnnouncementForm(Announcement announce)
        {
            Announce = announce;
            InitializeComponent();
        }

        private void ShowAnnouncementForm_Load(object sender, EventArgs e)
        {
            this.Text = Announce.Title;
            descriptionLabel.Text = Announce.Description;
        }
    }
}

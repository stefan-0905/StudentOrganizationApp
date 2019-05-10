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
        List<Button> navigationButtons = new List<Button>();
        public Dashboard()
        {
            InitializeComponent();
            navigationButtons.Add(dashboardButton);
            navigationButtons.Add(announcementsButton);
            navigationButtons.Add(coursesButton);
            navigationButtons.Add(messagesButton);
            navigationButtons.Add(forumButton);
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

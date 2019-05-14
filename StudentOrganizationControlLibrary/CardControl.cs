using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentOrganizationLibrary.Models;

namespace StudentOrganizationControlLibrary
{
    public partial class CardControl : UserControl
    {
        public CardControl()
        {
            InitializeComponent();
        }
        public CardControl(Announcement announce)
        {
            InitializeComponent();

            this.Tag = announce.Id;

            ToolTip myToolTip = new ToolTip();
            myToolTip.SetToolTip(headerLabel, announce.Title);

            headerLabel.Text = announce.Title;
            descriptionLabel.Text = announce.Description;
        }
    }
}

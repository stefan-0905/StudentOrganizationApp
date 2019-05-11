using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentOrganizationControlLibrary
{
    public partial class CardControl : UserControl
    {
        public CardControl()
        {
            InitializeComponent();
            
        }
        public CardControl(string heading, string description)
        {
            InitializeComponent();

            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(heading, headerLabel.Font);
            
            if (size.Width > 115)
            {
                heading = heading.Substring(0, 35);
                heading = string.Concat(heading, "...");
            }
            headerLabel.Text = heading;

            size = g.MeasureString(description, descriptionLabel.Font);

            if (size.Width > 294)
            {
                MessageBox.Show(size.ToString());
                description = description.Substring(0, 50);
                description = string.Concat(description, "...");
            }
            descriptionLabel.Text = description;
        }
    }
}

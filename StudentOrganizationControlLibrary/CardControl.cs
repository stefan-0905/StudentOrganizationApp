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

            ToolTip myToolTip = new ToolTip();
            myToolTip.SetToolTip(headerLabel, heading);

            headerLabel.Text = SubStringShortner(heading, headerLabel.Font, 126, 25);
            descriptionLabel.Text = SubStringShortner(description, descriptionLabel.Font, 294, 50);
        }

        private string SubStringShortner(string text, Font fontSize, int maxWidth, int charLength)
        {
            string resultString = text;
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(text, fontSize);

            if (size.Width > maxWidth)
            {
                resultString = text.Substring(0, charLength);
                resultString = string.Concat(resultString, "...");
            }

            return resultString;
        }
    }
}

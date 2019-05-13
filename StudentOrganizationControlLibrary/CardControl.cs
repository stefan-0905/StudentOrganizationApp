﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentOrganizationLibrary;

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

            headerLabel.Text = SubStringShortner(announce.Title, headerLabel.Font, 126, 25);
            descriptionLabel.Text = SubStringShortner(announce.Description, descriptionLabel.Font, 294, 50);
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

namespace StudentOrganizationApp
{
    partial class CreateOrUpdateAnnouncementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleValue = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionValue = new System.Windows.Forms.RichTextBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.titleBackRed = new System.Windows.Forms.Label();
            this.descriptionBackRed = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(42, 21);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title:";
            // 
            // titleValue
            // 
            this.titleValue.Location = new System.Drawing.Point(16, 35);
            this.titleValue.Name = "titleValue";
            this.titleValue.Size = new System.Drawing.Size(463, 29);
            this.titleValue.TabIndex = 1;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(13, 69);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(92, 21);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Description:";
            // 
            // descriptionValue
            // 
            this.descriptionValue.Location = new System.Drawing.Point(16, 94);
            this.descriptionValue.Name = "descriptionValue";
            this.descriptionValue.Size = new System.Drawing.Size(463, 251);
            this.descriptionValue.TabIndex = 3;
            this.descriptionValue.Text = "";
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.Color.MediumBlue;
            this.createBtn.FlatAppearance.BorderSize = 0;
            this.createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createBtn.ForeColor = System.Drawing.Color.White;
            this.createBtn.Location = new System.Drawing.Point(133, 365);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(94, 30);
            this.createBtn.TabIndex = 4;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.DimGray;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(263, 365);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 30);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // titleBackRed
            // 
            this.titleBackRed.BackColor = System.Drawing.Color.Red;
            this.titleBackRed.Location = new System.Drawing.Point(15, 34);
            this.titleBackRed.Name = "titleBackRed";
            this.titleBackRed.Size = new System.Drawing.Size(465, 31);
            this.titleBackRed.TabIndex = 6;
            this.titleBackRed.Visible = false;
            // 
            // descriptionBackRed
            // 
            this.descriptionBackRed.BackColor = System.Drawing.Color.Red;
            this.descriptionBackRed.Location = new System.Drawing.Point(15, 93);
            this.descriptionBackRed.Name = "descriptionBackRed";
            this.descriptionBackRed.Size = new System.Drawing.Size(465, 253);
            this.descriptionBackRed.TabIndex = 7;
            this.descriptionBackRed.Text = "label1";
            this.descriptionBackRed.Visible = false;
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.MediumBlue;
            this.updateBtn.FlatAppearance.BorderSize = 0;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.ForeColor = System.Drawing.Color.White;
            this.updateBtn.Location = new System.Drawing.Point(133, 365);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(94, 30);
            this.updateBtn.TabIndex = 8;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // CreateOrUpdateAnnouncementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 420);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.descriptionValue);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleValue);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleBackRed);
            this.Controls.Add(this.descriptionBackRed);
            this.Controls.Add(this.updateBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreateOrUpdateAnnouncementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Announcement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleValue;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.RichTextBox descriptionValue;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label titleBackRed;
        private System.Windows.Forms.Label descriptionBackRed;
        private System.Windows.Forms.Button updateBtn;
    }
}
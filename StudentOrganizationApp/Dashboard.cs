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
    public partial class Dashboard : Form
    {
        public readonly StOrgDbContext _context = new StOrgDbContext();
        public BindingList<Announcement> Announcements = new BindingList<Announcement>();
        public BindingList<Role> Roles = new BindingList<Role>();
        public BindingList<Department> Departments = new BindingList<Department>();
        public Dashboard()
        {
            InitializeComponent();
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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            InitiateAnnouncements();
            InitiateRolesAndDepartments();
            dashboardPanel.BringToFront();
        }

        private void InitiateAnnouncements()
        {
            PopulateAnnouncements();

            foreach (var announcement in Announcements.Take(3))
            {
                CardControl cardControl = new CardControl(announcement);
                announcementsFLPanel.Controls.Add(cardControl);
            }

            announcementsListBox.DataSource = Announcements;
            announcementsListBox.DisplayMember = "Title";
        }

        private void PopulateAnnouncements()
        {
            List<Announcement> announcements = _context.Announcements.OrderByDescending(x => x.CreatedAt).ToList();
            foreach (Announcement announcement in announcements)
            {
                Announcements.Add(announcement);
            }
        }

        private void InitiateRolesAndDepartments()
        {
            PopulateRolesAndDepartments();

            rolesListBox.DataSource = Roles;
            rolesListBox.DisplayMember = "Name";

            departmentsListBox.DataSource = Departments;
            departmentsListBox.DisplayMember = "Name";
        }

        private void PopulateRolesAndDepartments()
        {
            List<Role> roles = _context.Roles.OrderByDescending(x => x.CreatedAt).ToList();
            foreach (Role role in roles)
            {
                Roles.Add(role);
            }

            List<Department> departments = _context.Departments.OrderBy(x => x.Name).ToList();
            foreach (Department department in departments)
            {
                Departments.Add(department);
            }
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            this.Text = "Student Organization - Dashboard";
            dashboardPanel.BringToFront();
        }

        private void AnnouncementsButton_Click(object sender, EventArgs e)
        {
            this.Text = "Student Organization - Announcements";
            announcementsPanel.BringToFront();
        }

        private void MembersButton_Click(object sender, EventArgs e)
        {
            this.Text = "Student Organization - Members";
            membersPanel.BringToFront();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            this.Text = "Student Organization - Settings";
            settingsPanel.BringToFront();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            CreateOrUpdateAnnouncementForm newAnnouncement = new CreateOrUpdateAnnouncementForm(this);
            newAnnouncement.Show();
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            Announcement delAnnouncement = (Announcement)announcementsListBox.SelectedItem;
            if(delAnnouncement != null)
            { 
                var confirmDeletion = MessageBox.Show("Are you sure you want to delete this announcement?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmDeletion == DialogResult.Yes)
                {

                    // Delete announcement from db
                    _context.Announcements.Remove(delAnnouncement);
                    await _context.SaveChangesAsync();

                    // Update ListBox 
                    Announcements.Remove(delAnnouncement);

                    // Update flowLayoutPanel
                    foreach (CardControl control in announcementsFLPanel.Controls)
                    {
                        if ((int)control.Tag == delAnnouncement.Id)
                        {
                            announcementsFLPanel.Controls.Remove(control);

                            // Reset panel with new set of recent announcements
                            announcementsFLPanel.Controls.Clear();
                            foreach (var announcement in Announcements.Take(3))
                            {
                                CardControl cardControl = new CardControl(announcement);
                                announcementsFLPanel.Controls.Add(cardControl);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No announcement that can be deleted.", "Error occured");
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Announcement announce = (Announcement)announcementsListBox.SelectedItem;
            if (announce != null)
            {
                CreateOrUpdateAnnouncementForm announcementForm = new CreateOrUpdateAnnouncementForm(this, announce);
                announcementForm.Show();
            }
            else
            {
                MessageBox.Show("No announce for edit.", "Error occured");
            }
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            Announcement announce = (Announcement)announcementsListBox.SelectedItem;
            if (announce != null)
            {
                ShowAnnouncementForm announcementShow = new ShowAnnouncementForm(announce);
                announcementShow.Show();
            }
            else
            {
                MessageBox.Show("No announce to show", "Error occured");
            }
        }

        private void CreateRoleBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(newRoleValue.Text))
            {
                MessageBox.Show("You must enter role name.", "Error");
            }
            else
            {
                Role newRole = new Role
                {
                    Name = newRoleValue.Text
                };

                var existingRole = _context.Roles.Where(x => x.Name.ToLower() == newRole.Name.ToLower()).FirstOrDefault();
                if (existingRole != null)
                {
                    MessageBox.Show("Role already exists.", "Error");
                }
                else
                {
                    _context.Roles.Add(newRole);
                    _context.SaveChanges();

                    Roles.Insert(0, newRole);
                }
            }
        }

        private void DeleteRoleBtn_Click(object sender, EventArgs e)
        {
            Role selectedRole = (Role)rolesListBox.SelectedItem;

            if (selectedRole != null)
            {
                _context.Roles.Remove(selectedRole);
                _context.SaveChanges();

                Roles.Remove(selectedRole);
            }
        }

        private void CreateDepartmentBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newDepartmentValue.Text))
            {
                MessageBox.Show("You must enter department name.", "Error");
            }
            else
            {
                Department newDepartment = new Department
                {
                    Name = newDepartmentValue.Text
                };

                var existingDepartment = _context.Departments.Where(x => x.Name.ToLower() == newDepartment.Name.ToLower()).FirstOrDefault();
                if (existingDepartment != null)
                {
                    MessageBox.Show("Department already exists.", "Error");
                }
                else
                {
                    _context.Departments.Add(newDepartment);
                    _context.SaveChanges();

                    Departments.Insert(0, newDepartment);
                }
            }
        }

        private void DeleteDepartmentBtn_Click(object sender, EventArgs e)
        {
            Department selectedDepartment = (Department)departmentsListBox.SelectedItem;

            if (selectedDepartment != null)
            {
                _context.Departments.Remove(selectedDepartment);
                _context.SaveChanges();

                Departments.Remove(selectedDepartment);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contactList
{
    public partial class Form2 : Form
    {
        //Initialise form2 and fix window size.
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        //Returns to main menu when cancel button clicked.
        private void addContactCancelButton_Click(object sender, EventArgs e)
        {
            ReturnToMainMenu();
        }

        //Adds new contact when submit button clicked.
        private void addContactSubmitButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void AddContact()
        {
            bool contactAdded;
            if(CheckFieldsAreFilled() == true)  //Continues with submition only if all fields are filled.
            {
                //Determines if 'Active' radio button is checked or not.
                bool active;
                if (radioButtonActive.Checked)
                {
                    active = true;
                }
                else
                {
                    active = false;
                }
                //Adding the information from the textboxes to the list as a Contact object.
                ListOfContacts.Contacts.Add(
                    new Contact()
                    {
                        FName = firstNameTextBox.Text,
                        LName = lastNameTextBox.Text,
                        MInit = middleInitialTextBox.Text,
                        HomePH = homePHTextBox.Text,
                        MobilePH = mobilePHTextBox.Text,
                        OfficeExt = officeExtTextBox.Text,
                        IRDNum = IRDNumTextBox.Text,
                        Active = active
                    }
                );
                contactAdded = true;
            }
            else
            {
                //Error message if fields are left blank.
                MessageBox.Show("Error: Not all fields are filled.");
                contactAdded = false;
            }

            //Return to main menu if contact submitted successfully
            if(contactAdded == true)
            {
                ReturnToMainMenu();
            }
        }

        private bool CheckFieldsAreFilled()
        {
            //Returns false if any textboxes are left empty.
            if(
                firstNameTextBox.TextLength == 0 ||
                lastNameTextBox.TextLength == 0 ||
                middleInitialTextBox.TextLength == 0 ||
                homePHTextBox.TextLength == 0 ||
                mobilePHTextBox.TextLength == 0 ||
                officeExtTextBox.TextLength == 0 ||
                IRDNumTextBox.TextLength == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Shows Form1(the main menu) and hides Form2(new contact form).
        private void ReturnToMainMenu()
        {
            var frm = new Form1();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }
    }
}

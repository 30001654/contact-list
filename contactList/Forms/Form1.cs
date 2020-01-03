using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace contactList
{
    public partial class Form1 : Form
    {
        //Initialise the first form, initialise data grid view and fix window size.
        public Form1()
        {
            InitializeComponent();
            UpdateContactsDataGridView();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        //Redirect to contact add form if CheckNumberOfContacts returns true.
        private void addContactButton_Click(object sender, EventArgs e)
        {
            if(CheckNumberOfContacts() == true)
            {
                var frm = new Form2();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error: Max number of contacts reached.");
            }
        }

        //Checks if how many records exist in the list. Returns false if over 15.
        private bool CheckNumberOfContacts()
        {
            if(ListOfContacts.Contacts.Count >= 15)
            {
                return false;
            }
            return true;
        }

        //Updates the data grid view
        private void UpdateContactsDataGridView()
        {
            contactsDataGridView.DataSource = ListOfContacts.Contacts;
        }

        //Deletes selected record only if there are records existing to delete.
        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            if(ListOfContacts.Contacts.Count <= 0)
            {
                MessageBox.Show("Error: No entries to remove.");
            }
            else
            {
                DeleteSelected();
            }
            UpdateContactsDataGridView();
        }

        //Deletes the item in the list at the same index as the currently selected row in the data grid view.
        public void DeleteSelected()
        {
            int currentEntryIndex = contactsDataGridView.CurrentRow.Index;
            contactsDataGridView.DataSource = null;
            ListOfContacts.Contacts.RemoveAt(currentEntryIndex);
        }

        private void exportCSVButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = ".csv";
            DialogResult result = saveFileDialog1.ShowDialog();
            string selectedPath = "";   
            if (result == DialogResult.OK)
            {
                selectedPath = saveFileDialog1.FileName;    //Gets save file path from user input.
            }
            if (selectedPath != "")     //If file path is not empty(user has not cancelled selecting a save location) continues with export.
            {
                //Writes to the file created with the information formatted into CSV.
                using (StreamWriter sw = File.AppendText(selectedPath))
                {
                    sw.WriteLine("FName,MInit,LName,HomePH,MobilePH,OfficeExt,IRDNum,Active");
                    for (int i = 0; i < ListOfContacts.Contacts.Count; i++)
                    {
                        sw.WriteLine($"{ListOfContacts.Contacts[i].FName},{ListOfContacts.Contacts[i].MInit},{ListOfContacts.Contacts[i].LName},{ListOfContacts.Contacts[i].HomePH},{ListOfContacts.Contacts[i].MobilePH},{ListOfContacts.Contacts[i].OfficeExt},{ListOfContacts.Contacts[i].IRDNum},{ListOfContacts.Contacts[i].Active}");
                    }
                }
            }
        }

        private void printReportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog2 = new SaveFileDialog();
            saveFileDialog2.DefaultExt = ".txt";
            DialogResult result = saveFileDialog2.ShowDialog();
            string selectedPath = "";
            if (result == DialogResult.OK)
            {
                selectedPath = saveFileDialog2.FileName;    //Gets save file path from user input.
            }
            if (selectedPath != "")     //If file path is not empty(user has not cancelled selecting a save location) continues with export.
            {
                //Writes to the file created with the information formatted into a report.
                using (StreamWriter sw = File.AppendText(selectedPath))
                {
                    sw.WriteLine("Contacts");
                    sw.WriteLine("________________________________________________________________");
                    for (int i = 0; i < ListOfContacts.Contacts.Count; i++)
                    {
                        sw.WriteLine($"First Name:       {ListOfContacts.Contacts[i].FName}\n" +
                                     $"Middle Initial:   {ListOfContacts.Contacts[i].MInit}\n" +
                                     $"Last Name:        {ListOfContacts.Contacts[i].LName}\n" +
                                     $"Home Phone:       {ListOfContacts.Contacts[i].HomePH}\n" +
                                     $"Mobile Phone:     {ListOfContacts.Contacts[i].MobilePH}\n" +
                                     $"Office Extension: {ListOfContacts.Contacts[i].OfficeExt}\n" +
                                     $"IRD Number:       {ListOfContacts.Contacts[i].IRDNum}\n" +
                                     $"Active:           {ListOfContacts.Contacts[i].Active}\n\n");
                    }
                }
            }
        }
    }
}

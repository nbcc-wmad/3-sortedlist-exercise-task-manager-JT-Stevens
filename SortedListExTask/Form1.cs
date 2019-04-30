using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Jeremy Stevens
// Date: 2019/04/30
// Exercise: 3-sortedlist-exercise-task-manager

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        SortedList<DateTime, string> Tasks = new SortedList<DateTime, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate the user entered in text
                if (string.IsNullOrWhiteSpace(txtTask.Text))
                {
                    MessageBox.Show("You must enter a task", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Validate the user doesn't pick a date that is already assigned.
                if (Tasks.Keys.Contains(dtpTaskDate.Value))
                {
                    MessageBox.Show("Only one task per date is allowed.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Add task to SortedList
                Tasks.Add(dtpTaskDate.Value, txtTask.Text.Trim());
                   
                //Bind lstTasks with Tasks values
                lstTasks.DisplayMember = "key";
                lstTasks.ValueMember = "value";
                lstTasks.DataSource = new BindingSource(Tasks, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            


        }
    }
}

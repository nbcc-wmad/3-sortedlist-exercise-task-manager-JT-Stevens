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

        /// <summary>
        /// Adds user input into Tasks and lstTasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (Tasks.Keys.Contains(dtpTaskDate.Value.Date))
                {
                    MessageBox.Show("Only one task per date is allowed.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Add task to SortedList
                Tasks.Add(dtpTaskDate.Value.Date, txtTask.Text.Trim());

                //Add task to lstbox
                lstTasks.Items.Add(dtpTaskDate.Value.Date);

                //Clear txtTask
                txtTask.ResetText();
                //Reset DateTimePicker
                dtpTaskDate.Value = DateTime.Now.Date;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Displays selected task description in the label box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                lblTaskDetails.Text = Tasks[Convert.ToDateTime(lstTasks.SelectedItem)];
            }
        }


        //Playing around --ignore--
        private void dtpTaskDate_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show($"Now: {DateTime.Now}");
            //dtpTaskDate.ValueChanged -= new EventHandler(dtpTaskDate_ValueChanged);
            //dtpTaskDate.Value = dtpTaskDate.Value.Date;
            //MessageBox.Show(dtpTaskDate.Value.ToString());
            //dtpTaskDate.Value = dtpTaskDate.Value.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
            //MessageBox.Show(dtpTaskDate.Value.ToString());
            //dtpTaskDate.ValueChanged += new EventHandler(dtpTaskDate_ValueChanged);
        }


        /// <summary>
        /// Remove the selected task from lstTask and Tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            //Validate user selected an item
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a task to remove.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Remove item from lst and Tasks
            Tasks.Remove(Convert.ToDateTime(lstTasks.SelectedItem));
            lstTasks.Items.Remove(Convert.ToDateTime(lstTasks.SelectedItem));
            lstTasks.SelectedIndex = -1;
            lblTaskDetails.Text = string.Empty;
        }


        /// <summary>
        /// Display all saved Tasks in a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string msg = "";
            foreach (var task in Tasks)
            {
                msg += $"{task.Key.ToShortDateString()} {task.Value}{Environment.NewLine}";
            }
            MessageBox.Show(msg);
        }
    }
}

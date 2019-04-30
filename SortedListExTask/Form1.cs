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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTask.Text))
            {
                MessageBox.Show("You must enter a task", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

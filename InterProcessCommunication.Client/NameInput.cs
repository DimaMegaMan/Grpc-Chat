using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterProcessCommunication.Client
{
    /// <summary>
    /// Dialog form to 
    /// </summary>
    public partial class NameInput : Form
    {
        private NameInput()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Create dialog box and input user name 
        /// </summary>
        /// <returns></returns>
        public static string InputUserName()
        {
            //Creating form 
            var inputForm = new NameInput();
            //Show form for a user
            inputForm.ShowDialog();

            return inputForm.NameTextBox.Text;
        }

    }
}

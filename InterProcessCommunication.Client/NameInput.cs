using System;
using System.Windows.Forms;

namespace Chat.Client
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

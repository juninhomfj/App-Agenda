using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTE_DE_FORM_E_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();

                // Security: Validate email input before saving to prevent malformed data
                string email = emailTextBox.Text;
                if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.tableBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.database1DataSet);
            }
            catch (Exception)
            {
                // Security: Show a generic error message to the user instead of a stack trace
                // to avoid leaking internal system details.
                MessageBox.Show("An error occurred while saving the data. Please check your input and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Security: Set primary key field to ReadOnly to prevent manual modification in UI
            contactIdTextBox.ReadOnly = true;

            // TODO: esta linha de código carrega dados na tabela 'database1DataSet.Table'. Você pode movê-la ou removê-la conforme necessário.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);
        }

        /// <summary>
        /// Security: Basic email validation to ensure data integrity.
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Designed By:Juninhomfj \nV 1.0","About");
        }
    }
}

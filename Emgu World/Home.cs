using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Data.OleDb;
using System.IO;

namespace Emgu_World
{
    public partial class Home : MetroForm
    {
        // Attributes
        string userName, password;
        Hello hello;
        OleDbConnection connection;
        OleDbCommand cmd;
        OleDbDataAdapter dataAdapter;
        DataTable dataTable;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.GetFullPath("../../users.mdb");
                connection.Open();
            }
            catch (Exception)
            {
                
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroMessageBox.Show(this, "\nAre you sure to close this?", "Emgu World",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing && MetroMessageBox.Show(this, "\nAre you sure to quit?", "Emgu World",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                userName = metroTextBox1.Text;
                password = metroTextBox2.Text;
                hello = new Hello();

                cmd = new OleDbCommand("select username,password from users where username='" +
                    userName + "'and password='" + password + "'", connection);

                dataAdapter = new OleDbDataAdapter(cmd);

                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    hello.Show();
                    connection.Close();
                    Hide();
                }
                else
                {
                    MetroMessageBox.Show(this, "\nInvalid Access", "Emgu World",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}

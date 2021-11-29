using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class SetResultForm : Form
    {
        private string Theme;
        private string idresult;
        private string idstudent;

        private MySqlConnection conn;
        private MySqlDataAdapter mDA;

        private DataTable currentT;

        public SetResultForm(string theme, MySqlConnection connection, string idres, string idstud)
        {
            InitializeComponent();
            SetTimePicker();

            this.Theme = theme;
            this.idresult = idres;
            this.idstudent = idstud;

            this.conn = connection;
            this.mDA = new MySqlDataAdapter();
            currentT = new DataTable();

            if(theme != null)
            {
                ThemeComboBox.Items.Add(theme);
                ThemeComboBox.SelectedItem = theme;
                ThemeComboBox.Enabled = false;
            }
            else
            {
                if (conn.State == ConnectionState.Open)
                {
                    string q = "SELECT id, theme FROM coursework.workthemes where status = 0";
                    mDA.SelectCommand = new MySqlCommand(q, conn);
                    mDA.Fill(currentT);
                    foreach (DataRow mDA in currentT.Rows) ThemeComboBox.Items.Add(mDA[1].ToString());
                }
            }
        }
        private void SetTimePicker()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckInput()
        {
            if (ThemeComboBox.SelectedItem != null && MarkComboBox.SelectedItem != null) OkButton.Enabled = true;
            else OkButton.Enabled = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string q = "";
            if (ThemeComboBox.Enabled)
            {
                string idth="";
                for (int i = 0; i < currentT.Rows.Count; i++) if (currentT.Rows[i].ItemArray[1].ToString() == ThemeComboBox.SelectedItem.ToString())
                        idth = currentT.Rows[i].ItemArray[0].ToString();
                q = $"UPDATE `coursework`.`students` SET `idtheme` = '{idth}' WHERE (`id` = '{idstudent}');\n";
            }
            q += $"UPDATE `coursework`.`results` SET `mark` = '{MarkComboBox.SelectedItem.ToString()}'," +
                $" `date` = '{dateTimePicker1.Value.Year}/{dateTimePicker1.Value.Month}/{dateTimePicker1.Value.Day}' WHERE (`idresult` = '{idresult}')";

            MySqlCommand cmd = new MySqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            this.Close();
        }

        private void ThemeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void MarkComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckInput();
        }
    }
}

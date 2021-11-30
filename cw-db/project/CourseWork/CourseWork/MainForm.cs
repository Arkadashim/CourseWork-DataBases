using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class MainForm : Form
    {
        private MySqlConnection conn;
        private MySqlDataAdapter mDA;
        private DataTable table;
        public MainForm()
        {
            InitializeComponent();
            conn = dbutils.GetConnect();
            try
            {
                conn.Open();
                mDA = new MySqlDataAdapter();

                InitializeGroupBox();
                InitializeMarksBox();
                SetResults();
                ResultGridDropSelection();

                InitializeStudentGrid();

                InitializeReviewersGrid();

                InitializeGroupDataGrid();

                InitializeThemesGrid();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void DropStudentGridSelection()
        {
            StudentsGrid.ClearSelection();
        }
        private void InitializeMarksBox()
        {
            MarksBox.Items.Add("Any");
            for (int i = 5; i >= 2; i--) MarksBox.Items.Add(i.ToString());
            MarksBox.SelectedIndex = 0;
        }
        private void InitializeGroupBox()
        {
            string q = "SELECT name FROM coursework.groups;";
            mDA.SelectCommand = new MySqlCommand(q, conn);
            DataTable currentT = new DataTable();
            mDA.Fill(currentT);
            groupBox.Items.Clear();
            groupBox.Items.Add("By the whole faculty");
            foreach (DataRow mDA in currentT.Rows) groupBox.Items.Add(mDA[0].ToString());
            currentT.Dispose();
            groupBox.SelectedIndex = 0;
        }
        public void SetResults()
        {
            if (conn.State == ConnectionState.Open)
                try
                {
                    string q = "SELECT `r`.`idresult` AS `ID`, `s`.`id` AS `Student ID`, CONCAT(`s`.`surname`, ' ', `s`.`name`, ' ', " +
                    $"`s`.`patronymic`) AS `Student`, IFNULL(`r`.`mark`, 'Not set') AS `Mark`, IFNULL(`r`.`date`, 'Not Set') AS `Date`, " +
                    $"IFNULL(CONCAT(`rw`.`surname`, ' ', LEFT(`rw`.`name`, 1),'.', LEFT(`rw`.`patronymic`, 1), '.'), 'Not set') AS `Reviewer` " +
                    $"FROM ((`results` `r` JOIN `students` `s` ON((`r`.`idstud` = `s`.`id`))) JOIN `reviewers` `rw` ON((`r`.`idrev` = `rw`.`id`)))" +
                    $"WHERE 1";
                    if (NSRB.Checked) q += " AND isnull(r.mark)";
                    if (SRB.Checked) q += " AND !isnull(r.mark)";
                    if (SearchNameTextBox.Text != "") q += $" AND is_like_name(`s`.`surname`, `s`.`name`, `s`.`patronymic`, '{SearchNameTextBox.Text}')";
                    if (MarksBox.SelectedItem != null && MarksBox.SelectedIndex != 0) q += $" AND `r`.`mark` = {MarksBox.SelectedItem.ToString()}";
                    q += " ORDER BY `s`.`surname`";
                    mDA.SelectCommand = new MySqlCommand(q, conn);
                    table = new DataTable();
                    mDA.Fill(table);

                    ResultGridDropSelection();

                    ResultsGridView.DataSource = table;
                    ResultsGridView.Columns[0].Visible = false;
                    ResultsGridView.Columns[1].Visible = false;

                    ReviewerLabel.Text = "";

                    ResultsGridView.Columns[2].Width = 200;
                    ResultsGridView.Columns[3].Width = 59;
                    ResultsGridView.Columns[4].Width = 76;
                    ResultsGridView.Columns[5].Width = 138;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
        }
        public void SetResultWithGroup(string group)
        {
            string q = $"SELECT `r`.`idresult` AS `ID`, `s`.`id` AS `Student ID`, CONCAT(`s`.`surname`, ' ', `s`.`name`, ' ', " +
                $"`s`.`patronymic`) AS `Student`, IFNULL(`r`.`mark`, 'Not set') AS `Mark`, IFNULL(`r`.`date`, 'Not Set') AS `Date` "  +
                $"FROM (`results` `r` JOIN `students` `s` ON(`r`.`idstud` = `s`.`id`)) " +
                $"WHERE s.idgroup = get_group_id('{group}')";
            if (NSRB.Checked) q += " and isnull(r.mark)";
            if (SRB.Checked) q += " and !isnull(r.mark)";
            if (SearchNameTextBox.Text != "") q += $" AND is_like_name(`s`.`surname`, `s`.`name`, `s`.`patronymic`, '{SearchNameTextBox.Text}')";
            if (MarksBox.SelectedItem != null && MarksBox.SelectedIndex != 0) q += $" AND `r`.`mark` = {MarksBox.SelectedItem.ToString()}";
            q += " ORDER BY `s`.`surname`";
            string q2 = $"Select get_rev_by_group('{group}')";
            if (conn.State == ConnectionState.Open) 
                try
                {
                    mDA.SelectCommand = new MySqlCommand(q, conn);
                    table = new DataTable();
                    mDA.Fill(table);

                    ResultsGridView.DataSource = table;
                    ResultsGridView.Columns[0].Visible = false;
                    ResultsGridView.Columns[1].Visible = false;

                    ResultGridDropSelection();

                    mDA.SelectCommand = new MySqlCommand(q2, conn);
                    DataTable t = new DataTable();
                    mDA.Fill(t);
                    ReviewerLabel.Text = "Reviewer: " + t.Rows[0].ItemArray[0].ToString();

                    ResultsGridView.Columns[2].Width = 250;
                    ResultsGridView.Columns[3].Width = 81;
                    ResultsGridView.Columns[4].Width = 142;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
        }

        private void groupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox.SelectedItem == groupBox.Items[0]) SetResults(); 
            else SetResultWithGroup(groupBox.SelectedItem.ToString());

            SearchNameTextBox.Text = "";
        }

        private void RadioButtonChanged(object sender, EventArgs e)
        {
            if (groupBox.SelectedItem == groupBox.Items[0]) SetResults();
            else SetResultWithGroup(groupBox.SelectedItem.ToString());
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            ResultsGridView.ClearSelection();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            ResultGridDropSelection();
        }

        private void ResultsGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //string colinfo = "";
            //for (int i = 2; i < ResultsGridView.Columns.Count; i++) colinfo += ResultsGridView.Columns[i].Width.ToString() + "\n";
            //MessageBox.Show(colinfo);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (groupBox.SelectedIndex == 0) SetResults();
            else SetResultWithGroup(groupBox.SelectedItem.ToString());
        }

        private void SearchNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchNameTextBox.Text == "")
            {
                SearchButton.Enabled = false;
                CancelSearchButton.Enabled = false;
                if (groupBox.SelectedItem == groupBox.Items[0]) SetResults();
                else SetResultWithGroup(groupBox.SelectedItem.ToString());
            }
            else
            {
                SearchButton.Enabled = true;
                CancelSearchButton.Enabled = true;
            }
        }

        private void CancelSearchButton_Click(object sender, EventArgs e)
        {
            SearchNameTextBox.Text = "";
        }

        private void MarksBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox.SelectedIndex == 0) SetResults();
            else SetResultWithGroup(groupBox.SelectedItem.ToString());
        }
        private void ResultGridDropSelection()
        {
            ResultsGridView.ClearSelection();
        }

        private void ResultsGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    SetterResultButton.Enabled = true;
                    
                    string q = $"select ifnull(coursework.get_theme_by_studentsid({ResultsGridView[1,e.RowIndex].ToolTipText}),'Not Set')";
                    mDA.SelectCommand = new MySqlCommand(q, conn);
                    DataTable t = new DataTable();
                    mDA.Fill(t);
                    ThemeLabel.Text = $"Student's theme of work:\n{t.Rows[0].ItemArray[0].ToString()}";
                    t.Dispose();
                }
                catch
                {

                }
            }
        }

        private void ResultsGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (ResultsGridView.Rows.Count == 0)
            {
                SetterResultButton.Enabled = false;
                ThemeLabel.Text = "";
            }
        }

        private void SetterResultButton_Click(object sender, EventArgs e)
        {
            string q = $"select coursework.get_theme_by_studentsid({ResultsGridView.CurrentRow.Cells[1].ToolTipText})";
            var t = new DataTable();
            mDA.SelectCommand = new MySqlCommand(q, conn);
            mDA.Fill(t);
            string theme;
            bool okay = true;
            if (t.Rows[0].ItemArray[0].ToString() == "")
            {
                theme = null;
                string q2 = "select coursework.is_there_free_theme()";
                var tmDA = new MySqlDataAdapter();
                tmDA.SelectCommand = new MySqlCommand(q2, conn);
                var tDT = new DataTable();
                tmDA.Fill(tDT);
                if (tDT.Rows[0].ItemArray[0].ToString() == "False") okay = false;
                tmDA.Dispose(); tDT.Dispose();
            }
            else theme = t.Rows[0].ItemArray[0].ToString();
            if (okay)
            { 
                SetResultForm f = new SetResultForm(theme, conn, ResultsGridView.CurrentRow.Cells[0].ToolTipText, ResultsGridView.CurrentRow.Cells[1].ToolTipText);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Student has no theme, but there is no free theme.\n" +
                    "You should add new theme and set it for student to set result.");
            }
        }



        private void StudentsGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //string colinfo = "";
            //for (int i = 1; i < StudentsGrid.Columns.Count; i++) colinfo += StudentsGrid.Columns[i].Width.ToString() + "\n";
            //MessageBox.Show(colinfo);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            DropStudentGridSelection();
        }

        /////////////////tab 2/////////////////

        private Container c;
        private TextBox[] tbs;
        private ComboBox cmb;
        private DataTable tempTableTab2;

        private void InitializeStudentGrid()
        {
            string q = "SELECT `s`.`id` as ID, concat(`s`.`surname`,' ',`s`.`name`,' ',`s`.`patronymic`) as Student," +
                " `g`.`name` as 'Group', `get_theme_by_its_id`(`s`.`idtheme`) as 'Theme' from `students` `s` join `groups` `g`" +
                " on (`s`.`idgroup`=`g`.`id`) WHERE 1";

            if (SearchTB.Text != "") q += $" AND is_like_name(`s`.`surname`, `s`.`name`, `s`.`patronymic`, '{SearchTB.Text}')";

            mDA.SelectCommand = new MySqlCommand(q, conn);
            DataTable students = new DataTable();
            mDA.Fill(students);

            StudentsGrid.DataSource = students;
            StudentsGrid.Columns[0].Visible = false;
            // 269 61 100
            StudentsGrid.Columns[1].Width = 269;
            StudentsGrid.Columns[2].Width = 61;
            StudentsGrid.Columns[3].Width = 100;

            DropStudentGridSelection();
        }
        private void SetEditGroupBox(Container c)
        {
            Point poz = new Point(10, 30);
            EditingGroupBox.Controls.Clear();
            EditingGroupBox.Controls.Add(buttonOK);
            EditingGroupBox.Controls.Add(buttonCancel);
            foreach (Control temp in c.Components)
            {
                EditingGroupBox.Controls.Add(temp);
                temp.Location = poz;
                poz.Y += temp.Height + 5;
            }
        }

        private void SetPIButton_Click(object sender, EventArgs e)
        {
            EditingGroupBox.Visible = true;
            EditingGroupBox.Text = "Set new information";
            EditingGroupBox.Tag = "SetPI";

            c = new Container();
            tbs = new TextBox[3];
            Font tempfont = EditingGroupBox.Font;

            var l1 = new Label();
            l1.Text = "Surname";
            l1.Font = tempfont;
            c.Add(l1);

            var tb1 = new TextBox();
            tb1.Font = tempfont;
            tbs[0] = tb1;
            c.Add(tb1);

            var l2 = new Label();
            l2.Text = "Name";
            l2.Font = tempfont;
            c.Add(l2);

            var tb2 = new TextBox();
            tb2.Font = tempfont;
            tbs[1] = tb2;
            c.Add(tb2);

            var l3 = new Label();
            l3.Text = "Patronymic";
            l3.Font = tempfont;
            c.Add(l3);

            var tb3 = new TextBox();
            tb3.Font = tempfont;
            tbs[2] = tb3;
            c.Add(tb3);

            SetEditGroupBox(c);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EditingGroupBox.Visible = false;
            c.Dispose();
            if (cmb != null) cmb.Items.Clear();
            if (tbs!=null)
            foreach (TextBox temp in tbs) if (temp!=null) temp.Dispose();
            EditingGroupBox.Tag = "None";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string q = "";
            MySqlCommand cmd;
            switch(EditingGroupBox.Tag.ToString())
            {
                case "SetPI":
                    if (tbs[0].Text != "" && tbs[1].Text != "" && tbs[2].Text != "")
                    {
                        q = $"UPDATE `coursework`.`students` SET `surname` = '{tbs[0].Text}', `name` = '{tbs[1].Text}'," +
                            $" `patronymic` = '{tbs[2].Text}' WHERE (`id`='{StudentsGrid.CurrentRow.Cells[0].ToolTipText}')";
                        cmd = new MySqlCommand(q, conn);
                        cmd.ExecuteNonQuery();
                        buttonCancel_Click(sender, e);
                        InitializeStudentGrid();
                    }
                    else MessageBox.Show("There is not setted information");
                    break;
                case "NewStud":
                    if (tbs[0].Text != "" && tbs[1].Text != "" && tbs[2].Text != "" && cmb.SelectedItem != null)
                    {
                        q = $"INSERT INTO `coursework`.`students` (`surname`, `name`, `patronymic`, `idgroup`)" +
                            $" VALUES ('{tbs[0].Text}', '{tbs[1].Text}', '{tbs[2].Text}', `get_group_id`('{cmb.SelectedItem.ToString()}'))";
                        cmd = new MySqlCommand(q, conn);
                        cmd.ExecuteNonQuery();
                        buttonCancel_Click(sender, e);
                        InitializeStudentGrid();
                    }
                    else MessageBox.Show("Input all data.");
                        break;
                case "SetTheme":
                    if (cmb.SelectedItem != null)
                    {
                        string index = "";
                        foreach (DataRow dr in tempTableTab2.Rows) if (dr[2].ToString() == cmb.SelectedItem.ToString()) index = dr[1].ToString();
                        q = $"UPDATE `coursework`.`students` SET `idtheme` = '{index}' WHERE (`id` = '{StudentsGrid.CurrentRow.Cells[0].ToolTipText}')";
                        cmd = new MySqlCommand(q, conn);
                        cmd.ExecuteNonQuery();
                        buttonCancel_Click(sender, e);
                        InitializeStudentGrid();
                    }
                    else MessageBox.Show("Pick the theme.");
                    break;
                case "Remove":
                    q = $"DELETE FROM `coursework`.`students` WHERE (`id` = '{StudentsGrid.CurrentRow.Cells[0].ToolTipText}')";
                    cmd = new MySqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    buttonCancel_Click(sender, e);
                    InitializeStudentGrid();
                    break;
                default:
                    MessageBox.Show("Incorrect sets.");
                    break;
            }
        }

        private void StudentsGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (EditingGroupBox.Visible && EditingGroupBox.Tag.ToString() != "NewStud")
            buttonCancel_Click(sender, e);
        }

        private void AddStudButton_Click(object sender, EventArgs e)
        {

            EditingGroupBox.Visible = true;
            EditingGroupBox.Text = "Input information about new student";
            EditingGroupBox.Tag = "NewStud";

            c = new Container();
            tbs = new TextBox[3];
            cmb = new ComboBox();
            Font tempfont = EditingGroupBox.Font;

            var l1 = new Label();
            l1.Text = "Surname";
            l1.Font = tempfont;
            c.Add(l1);

            var tb1 = new TextBox();
            tb1.Font = tempfont;
            tbs[0] = tb1;
            c.Add(tb1);

            var l2 = new Label();
            l2.Text = "Name";
            l2.Font = tempfont;
            c.Add(l2);

            var tb2 = new TextBox();
            tb2.Font = tempfont;
            tbs[1] = tb2;
            c.Add(tb2);

            var l3 = new Label();
            l3.Text = "Patronymic";
            l3.Font = tempfont;
            c.Add(l3);

            var tb3 = new TextBox();
            tb3.Font = tempfont;
            tbs[2] = tb3;
            c.Add(tb3);

            var l4 = new Label();
            l4.Text = "Group";
            l4.Font = tempfont;
            c.Add(l4);

            tempTableTab2 = new DataTable();
            string q = "SELECT name FROM coursework.groups";
            mDA.SelectCommand = new MySqlCommand(q, conn);
            mDA.Fill(tempTableTab2);
            foreach (DataRow DR in tempTableTab2.Rows) cmb.Items.Add(DR[0].ToString());
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            c.Add(cmb);

            SetEditGroupBox(c);
        }

        private void RemoveStudButton_Click(object sender, EventArgs e)
        {
            EditingGroupBox.Visible = true;
            EditingGroupBox.Text = "Removing student";
            EditingGroupBox.Tag = "Remove";

            c = new Container();
            Font tempfont = EditingGroupBox.Font;

            var l1 = new Label();
            l1.Font = tempfont;
            l1.Text = "Confirm:";
            c.Add(l1);

            SetEditGroupBox(c);
        }

        private void SetThemeButton_Click(object sender, EventArgs e)
        {
            string q = "select coursework.is_there_free_theme()";
            mDA.SelectCommand = new MySqlCommand(q, conn);
            tempTableTab2 = new DataTable();
            mDA.Fill(tempTableTab2);
            if (tempTableTab2.Rows[0].ItemArray[0].ToString() == "True")
            {
                EditingGroupBox.Visible = true;
                EditingGroupBox.Text = "Set new theme";
                EditingGroupBox.Tag = "SetTheme";

                c = new Container();
                cmb = new ComboBox();
                Font tempfont = EditingGroupBox.Font;
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb.Width += 50;

                q = "SELECT id, theme FROM coursework.workthemes where status = 0";
                mDA.SelectCommand = new MySqlCommand(q, conn);
                tempTableTab2.Clear();
                mDA.Fill(tempTableTab2);
                foreach (DataRow mDA in tempTableTab2.Rows) cmb.Items.Add(mDA[2].ToString());

                c.Add(cmb);
                SetEditGroupBox(c);
            }
            else MessageBox.Show("There are no free themes, add new then try again.");
        }
        private void SearchTB_TextChanged(object sender, EventArgs e)
        {
            if (SearchTB.Text == "")
            {
                SearchB.Enabled = false;
                CancelSearchB.Enabled = false;
                InitializeStudentGrid();
            }
            else
            {
                SearchB.Enabled = true;
                CancelSearchB.Enabled = true;
            }
        }
        private void SearchB_Click(object sender, EventArgs e)
        {
            InitializeStudentGrid();
        }

        private void CancelSearchB_Click(object sender, EventArgs e)
        {
            SearchTB.Text = "";
        }

        /////////////////tab 3/////////////////
        ///

        private Container c2;
        private TextBox[] tbs2;
        private ComboBox cmb2;
        private DataTable tempTableTab3;

        private void InitializeReviewersGrid()
        {
            string q = "SELECT `id`,concat(`surname`,' ',`name`,' ',`patronymic`) as Revirewer from `coursework`.`reviewers` WHERE 1";
            if (SearchRevTB.Text != "") q += $" AND is_like_name(`surname`, `name`, `patronymic`, '{SearchRevTB.Text}')";

            mDA.SelectCommand = new MySqlCommand(q, conn);
            DataTable rev = new DataTable();
            mDA.Fill(rev);

            RevGridView.DataSource = rev;

            RevGridView.Columns[0].Visible = false;
            RevGridView.Columns[1].Width = RevGridView.Width - RevGridView.RowHeadersWidth;

            if (RevGridView.Rows.Count == 0)
            {
                EditButton.Enabled = false;
                RemoveButton.Enabled = false;
            } else
            {
                EditButton.Enabled = true;
                RemoveButton.Enabled = true;
            }
        }

        private void SetEditRevGroupBox(Container c)
        {
            Point poz = new Point(10, 30);
            EditRevGroupBox.Controls.Clear();
            EditRevGroupBox.Controls.Add(OKButton);
            EditRevGroupBox.Controls.Add(CancelButton);
            foreach (Control temp in c.Components)
            {
                EditRevGroupBox.Controls.Add(temp);
                temp.Location = poz;
                poz.Y += temp.Height + 5;
                if (temp is Label) temp.Width = EditRevGroupBox.Width - (poz.X + 1); 
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (RevGridView.Rows.Count > 0)
            {
                EditRevGroupBox.Tag = "Edit";
                EditRevGroupBox.Visible = true;

                c2 = new Container();
                tbs2 = new TextBox[3];
                Font tempfont = EditRevGroupBox.Font;

                var l1 = new Label();
                l1.Text = "Surname";
                l1.Font = tempfont;
                c2.Add(l1);

                var tb1 = new TextBox();
                tb1.Font = tempfont;
                tbs2[0] = tb1;
                c2.Add(tb1);

                var l2 = new Label();
                l2.Text = "Name";
                l2.Font = tempfont;
                c2.Add(l2);

                var tb2 = new TextBox();
                tb2.Font = tempfont;
                tbs2[1] = tb2;
                c2.Add(tb2);

                var l3 = new Label();
                l3.Text = "Patronymic";
                l3.Font = tempfont;
                c2.Add(l3);

                var tb3 = new TextBox();
                tb3.Font = tempfont;
                tbs2[2] = tb3;
                c2.Add(tb3);

                SetEditRevGroupBox(c2);
            }
            else MessageBox.Show("There is no something to edit it.");
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string q = "";
            MySqlCommand cmd;
            switch(EditRevGroupBox.Tag)
            {
                case "Edit":
                    if (tbs2 != null) if  (tbs2[0].Text != "" && tbs2[1].Text != "" && tbs2[2].Text != "")
                    {
                        q = $"UPDATE `coursework`.`reviewers` SET `surname` = '{tbs2[0].Text}', `name` = '{tbs2[1].Text}', `patronymic` = '{tbs2[2].Text}' " +
                            $"WHERE (`id` = '{RevGridView.CurrentRow.Cells[0].ToolTipText}')";
                        cmd = new MySqlCommand(q, conn);
                        cmd.ExecuteNonQuery();

                        InitializeReviewersGrid();
                        CancelButton_Click(sender, e);
                    }
                    else MessageBox.Show("You have to input all information.");
                    break;
                case "Add":
                    if (tbs2[0].Text != "" && tbs2[1].Text != "" && tbs2[2].Text != "")
                    {
                        q = $"INSERT INTO `coursework`.`reviewers` (`surname`, `name`, `patronymic`) " +
                            $"VALUES ('{tbs2[0].Text}', '{tbs2[1].Text}', '{tbs2[2].Text}')";
                        cmd = new MySqlCommand(q, conn);
                        cmd.ExecuteNonQuery();

                        InitializeReviewersGrid();
                        CancelButton_Click(sender, e);
                    }
                    break;
                case "Remove":
                    bool replace = false;
                    foreach (Control temp in EditRevGroupBox.Controls) if (temp is ComboBox) replace = true;
                    if (replace)
                    {
                        string replaced = RevGridView.CurrentRow.Cells[0].ToolTipText;
                        string replacing = "";
                        foreach (DataRow dr in tempTableTab3.Rows) if (dr.ItemArray[1].ToString() == cmb2.SelectedItem.ToString())
                                replacing = dr.ItemArray[0].ToString();
                        q = $"UPDATE `coursework`.`results` SET `idrev` = '{replacing}' WHERE (`idrev` = '{replaced}'); " +
                            $"UPDATE `coursework`.`groups` SET `idreviewer` = '{replacing}' WHERE (`id` = '{replaced}'); ";

                    }
                    q += $"DELETE FROM `coursework`.`reviewers` WHERE (`id` = '{RevGridView.CurrentRow.Cells[0].ToolTipText}');";

                    cmd = new MySqlCommand(q, conn);
                    cmd.ExecuteNonQuery();

                    InitializeReviewersGrid();
                    CancelButton_Click(sender, e);
                    break;
                default:
                    MessageBox.Show("Incorrect Setting.");
                    break;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            EditRevGroupBox.Visible = false;
            c2.Dispose();
            tbs2 = null;

            EditRevGroupBox.Tag = "None";
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (RevGridView.Rows.Count > 0)
            {
                EditRevGroupBox.Tag = "Remove";
                EditRevGroupBox.Visible = true;

                string q = $"Select Exists(Select * FROM `groups` where `idreviewer` = '{RevGridView.CurrentRow.Cells[0].ToolTipText}')";
                mDA.SelectCommand = new MySqlCommand(q, conn);
                var t = new DataTable();
                mDA.Fill(t);

                c2 = new Container();
                tbs2 = new TextBox[3];
                Font tempfont = EditRevGroupBox.Font;

                var l1 = new Label();
                l1.Font = tempfont;

                //string check = "";
                //foreach (DataRow dr in t.Rows) for (int i = 0; i < dr.ItemArray.Length; i++) check+=dr.ItemArray[i].ToString()+"\n";
                //MessageBox.Show(check);

                if (t.Rows[0].ItemArray[0].ToString() == "1")
                {
                    l1.Text = "There are groups reviewing this professor.";
                    c2.Add(l1);

                    var l2 = new Label();
                    l2.Text = "You should choose replace:";
                    l2.Font = tempfont;
                    c2.Add(l2);

                    cmb2 = new ComboBox();
                    cmb2.Width = EditRevGroupBox.Width - 30;
                    cmb2.Font = tempfont;

                    q = $"SELECT `id`, concat(`surname`,' ',left(`name`,1),'.',left(`patronymic`,1),'.') " +
                        $"From `reviewers` where `id` <> '{RevGridView.CurrentRow.Cells[0].ToolTipText}';";
                    mDA.SelectCommand = new MySqlCommand(q, conn);
                    tempTableTab3 = new DataTable();
                    mDA.Fill(tempTableTab3);

                    foreach (DataRow dr in tempTableTab3.Rows) cmb2.Items.Add(dr.ItemArray[1].ToString());
                    c2.Add(cmb2);
                }
                else
                {
                    l1.Text = "Confirm choice:";
                    c2.Add(l1);
                }

                SetEditRevGroupBox(c2);
            }
            else MessageBox.Show("There is no something to delete.");
        }

        private void RevGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (EditRevGroupBox.Visible && !(EditRevGroupBox.Tag is "Add")) CancelButton_Click(sender, e);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            EditRevGroupBox.Tag = "Add";
            EditRevGroupBox.Visible = true;

            c2 = new Container();
            tbs2 = new TextBox[3];
            Font tempfont = EditRevGroupBox.Font;

            var l1 = new Label();
            l1.Text = "Surname";
            l1.Font = tempfont;
            c2.Add(l1);

            var tb1 = new TextBox();
            tb1.Font = tempfont;
            tbs2[0] = tb1;
            c2.Add(tb1);

            var l2 = new Label();
            l2.Text = "Name";
            l2.Font = tempfont;
            c2.Add(l2);

            var tb2 = new TextBox();
            tb2.Font = tempfont;
            tbs2[1] = tb2;
            c2.Add(tb2);

            var l3 = new Label();
            l3.Text = "Patronymic";
            l3.Font = tempfont;
            c2.Add(l3);

            var tb3 = new TextBox();
            tb3.Font = tempfont;
            tbs2[2] = tb3;
            c2.Add(tb3);

            SetEditRevGroupBox(c2);
        }

        private void SearchRevTB_TextChanged(object sender, EventArgs e)
        {
            if (SearchRevTB.Text != "")
            {
                SearchRevB.Enabled = true;
                CancelSearchRevB.Enabled = true;
            }
            else
            {
                SearchRevB.Enabled = false;
                CancelSearchRevB.Enabled = false;
                InitializeReviewersGrid();
            }
        }

        private void SearchRevB_Click(object sender, EventArgs e)
        {
            InitializeReviewersGrid();
        }

        private void CancelSearchRevB_Click(object sender, EventArgs e)
        {
            SearchRevTB.Text = "";
        }

        /////////////////////////////tab 4///////////////////////////////
        ///

        private DataTable tempRev;
        private void InitializeGroupDataGrid()
        {
            string q = "SELECT `g`.`id`,`g`.`name` AS 'Group',`r`.`id`,concat(`r`.`surname`,' ',left(`r`.`name`,1),'.',left(`r`.`patronymic`,1),'.')" +
                " AS 'Professor' FROM `groups` `g` JOIN `reviewers` `r` ON (`g`.`idreviewer` = `r`.`id`) WHERE 1";
            if (SearchGroupTextBox.Text != "") q += $" AND `g`.`name` LIKE '%{SearchGroupTextBox.Text}%'";

            mDA.SelectCommand = new MySqlCommand(q, conn);
            DataTable groups = new DataTable();
            mDA.Fill(groups);

            GroupsDataGrid.DataSource = groups;
            GroupsDataGrid.Columns[0].Visible = false;
            GroupsDataGrid.Columns[2].Visible = false;
            GroupsDataGrid.Columns[3].Width = GroupsDataGrid.Width - GroupsDataGrid.RowHeadersWidth - GroupsDataGrid.Columns[1].Width - 2;
        }

        private void SetGroupPanel(string status)
        {
            StatusGroupLabel.Text = status;
            GroupNameTextBox.Text = "";
            GroupsComboBox.Items.Clear();

            if (!GroupNameTextBox.Enabled && !GroupsComboBox.Enabled)
            {
                GroupNameTextBox.Enabled = true;
                GroupsComboBox.Enabled = true;
            }

            string q = "SELECT `id`, concat(`surname`,' ',left(`name`,1),'.',left(`patronymic`,1),'.') FROM `reviewers`";
            tempRev = new DataTable();
            mDA.SelectCommand = new MySqlCommand(q, conn);
            mDA.Fill(tempRev);

            foreach (DataRow dr in tempRev.Rows) GroupsComboBox.Items.Add(dr.ItemArray[1].ToString());

            switch(status)
            {
                case "Addition":
                    break;
                case "Editing":
                    GroupNameTextBox.Text = GroupsDataGrid.CurrentRow.Cells[1].ToolTipText;
                    GroupsComboBox.SelectedItem = GroupsDataGrid.CurrentRow.Cells[3].ToolTipText;
                    break;
                case "Removing":
                    GroupNameTextBox.Text = GroupsDataGrid.CurrentRow.Cells[1].ToolTipText;
                    GroupsComboBox.SelectedItem = GroupsDataGrid.CurrentRow.Cells[3].ToolTipText;

                    GroupNameTextBox.Enabled = false;
                    GroupsComboBox.Enabled = false;
                    break;
            }
            GroupsPanel.Visible = true;
        }

        private void EditGroupButton_Click(object sender, EventArgs e)
        {
            SetGroupPanel("Editing");
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            SetGroupPanel("Addition");
        }

        private void RemoveGroupButton_Click(object sender, EventArgs e)
        {
            SetGroupPanel("Removing");
        }

        private void AcceptGroupsButton_Click(object sender, EventArgs e)
        {
            if (GroupsComboBox.SelectedItem != null && GroupNameTextBox.Text != "")
            {
                string q = "";
                string idnewrev = "";
                if (StatusGroupLabel.Text != "Removing")
                {
                    foreach (DataRow dr in tempRev.Rows) if (dr.ItemArray[1].ToString() == GroupsComboBox.SelectedItem.ToString()) 
                            idnewrev = dr.ItemArray[0].ToString();
                }

                switch (StatusGroupLabel.Text)
                {
                    case "Addition":
                        q = $"INSERT INTO `coursework`.`groups` (`name`, `idreviewer`) VALUES ('{GroupNameTextBox.Text}', '{idnewrev}')";
                        break;
                    case "Editing":
                        q = $"UPDATE `coursework`.`groups` SET `name` = '{GroupNameTextBox.Text}', `idreviewer` = '{idnewrev}' " +
                            $"WHERE (`id` = '{GroupsDataGrid.CurrentRow.Cells[0].ToolTipText}')";
                        break;
                    case "Removing":
                        q = $"DELETE FROM `coursework`.`groups` WHERE (`id` = '{GroupsDataGrid.CurrentRow.Cells[0].ToolTipText}');";
                        break;
                }

                MySqlCommand cmd = new MySqlCommand(q, conn);
                cmd.ExecuteNonQuery();

                InitializeGroupBox();
            }
            else MessageBox.Show("Incorrect input.");
        }

        private void CancelGroupsButton_Click(object sender, EventArgs e)
        {
            GroupsPanel.Visible = false;
        }

        private void SearchGroupTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchGroupTextBox.Text == "")
            {
                SearchGroupButton.Enabled = false;
                CancelSearchGroupButton.Enabled = false;
                InitializeGroupDataGrid();
            } else
            {
                SearchGroupButton.Enabled = true;
                CancelSearchGroupButton.Enabled = true;
            }
        }

        private void SearchGroupButton_Click(object sender, EventArgs e)
        {
            InitializeGroupDataGrid();
        }

        private void CancelSearchGroupButton_Click(object sender, EventArgs e)
        {
            SearchGroupTextBox.Text = "";
        }
        private void GroupsDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            CancelGroupsButton_Click(sender, e);
        }

        ///////////////////////// tab 5 ///////////////////////
        ///
        private void InitializeThemesGrid()
        {
            string q = "SELECT `id`,`theme`, if(`status` = 0, '✓','x') AS 'Status' FROM `workthemes` WHERE 1";
            if (SearchThemeTextBox.Text != "") q += $" AND `theme` LIKE '%{SearchThemeTextBox.Text}%'";
            if (FreeRadioButton.Checked) q += " AND `status` = '0'";
            if (BusyRadioButton.Checked) q += " AND `status` = '1'";

            mDA.SelectCommand = new MySqlCommand(q, conn);
            DataTable themes = new DataTable();
            mDA.Fill(themes);

            ThemesGrid.DataSource = themes;
            ThemesGrid.Columns[0].Visible = false;
            ThemesGrid.Columns[1].Width = ThemesGrid.Width - (ThemesGrid.RowHeadersWidth + ThemesGrid.Columns[2].Width + 10);
            ThemesGrid.Columns[2].Width = 50;

            if (ThemesGrid.Rows.Count == 0)
            {
                EditThemeButton.Enabled = false;
                RemoveThemeButton.Enabled = false;
            } else if(!EditThemeButton.Enabled && !RemoveThemeButton.Enabled)
            {
                EditThemeButton.Enabled = true;
                RemoveThemeButton.Enabled = true;
            }
        }

        private void SearchThemeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchThemeTextBox.Text == "")
            {
                SearchThemeButton.Enabled = false;
                CancelSearchThemeButton.Enabled = false;
                InitializeThemesGrid();
            }
            else
            {
                SearchThemeButton.Enabled = true;
                CancelSearchThemeButton.Enabled = true;
            }
        }

        private void SearchThemeButton_Click(object sender, EventArgs e)
        {
            InitializeThemesGrid();
        }

        private void CancelSearchThemeButton_Click(object sender, EventArgs e)
        {
            SearchThemeTextBox.Text = "";
        }

        private void EditThemeButton_Click(object sender, EventArgs e)
        {
            ThemeSetLabel.Text = "Editing";
            ThemeTextBox.Tag = "Edit";
            ThemeTextBox.Text = "";
            ThemesPanel.Visible = true;
        }

        private void AddThemeButton_Click(object sender, EventArgs e)
        {
            ThemeSetLabel.Text = "Addition";
            ThemeTextBox.Tag = "Add";
            ThemeTextBox.Text = "";
            ThemesPanel.Visible = true;
        }

        private void ThemeAcceptButton_Click(object sender, EventArgs e)
        {
            if (ThemeTextBox.Text != "")
            {
                string q = "";
                switch (ThemeTextBox.Tag)
                {
                    case "Add":
                        q = $"INSERT INTO `coursework`.`workthemes` (`theme`) VALUES ('{ThemeTextBox.Text}');";
                        break;
                    case "Edit":
                        q = $"UPDATE `coursework`.`workthemes` SET `theme` = '{ThemeTextBox.Text}' " +
                            $"WHERE (`id` = '{ThemesGrid.CurrentRow.Cells[0].ToolTipText}');";
                        break;
                }

                MySqlCommand cmd = new MySqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                InitializeThemesGrid();
            }
            else MessageBox.Show("Insert new Theme.");
        }

        private void ThemeCancelButton_Click(object sender, EventArgs e)
        {
            ThemesPanel.Visible = false;
        }

        private void RemoveThemeButton_Click(object sender, EventArgs e)
        {
            if (ThemesGrid.CurrentRow.Cells[2].ToolTipText == "✓")
            {
                string q = $"DELETE FROM `coursework`.`workthemes` WHERE (`id` = '{ThemesGrid.CurrentRow.Cells[0].ToolTipText}')";

                MySqlCommand cmd = new MySqlCommand(q, conn);
                cmd.ExecuteNonQuery();

                InitializeThemesGrid();
            }
            else MessageBox.Show("You can't delete busy theme.");
        }

        private void ThemesGrid_SelectionChanged(object sender, EventArgs e)
        {
            CancelGroupsButton_Click(sender, e);
        }

        private void AllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            InitializeThemesGrid();
        }

        private void FreeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            InitializeThemesGrid();
        }

        private void BusyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            InitializeThemesGrid();
        }
    }
}

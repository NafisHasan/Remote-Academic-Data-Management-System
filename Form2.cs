using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Record
{
    public partial class Form2 : Form
    {
        private DBConnect dbConnect;
        public Form2()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            //Properties.Settings.Default.test = "xyz";
            //Properties.Settings.Default.Save();
            //MessageBox.Show(Properties.Settings.Default.test);
        }
        public void Clear()
        {
            //comboBox5.ResetText();
            comboBox6.ResetText();
            comboBox1.ResetText();
            //comboBox2.ResetText();
            //comboBox3.ResetText();
            comboBox4.SelectedIndex = -1;
            if (radioButton1.Checked || radioButton2.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            dataGridView1.Rows.Clear();
        }


        private void Button1_Click(object sender, EventArgs e)
        {

            Clear();
        }


        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to delete this row(s)", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                        Int32 numRows = dataGridView1.Rows.Count;
                        if (dataGridView1.SelectedRows[0].Index == numRows - 1 && selectedRowCount < 2)
                        {
                            MessageBox.Show("Uncommitted new row cannot be deleted.", "Error");
                        }
                        if (selectedRowCount > 0)
                        {
                            for (int i = 0; i < selectedRowCount - 1; i++)
                            {
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            }
                        }

                    }

                    catch (InvalidOperationException x)
                    {
                        MessageBox.Show(x.Message);
                    }



                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                Clear();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //dbConnect = new DBConnect();
            //dbConnect.FillDataSet("select name from department", "department");
            try
            {
                comboBox2.DataSource = DBConnect.DS.Tables["department"].DefaultView;
                comboBox2.ValueMember = "name";
                //dbConnect.FillDataSet("select batchId from batch", "batch");
                comboBox5.DataSource = DBConnect.DS.Tables["batch"].DefaultView;
                comboBox5.ValueMember = "batchId";
                //dbConnect.FillDataSet("select name from program", "program");
                comboBox3.DataSource = DBConnect.DS.Tables["program"].DefaultView;
                comboBox3.ValueMember = "name";
            }
            finally
            {

            }
            /*if (DBConnect.IsInternetAvailable())
            {
                dbConnect = new DBConnect();
                List<string>[] list;
                list = dbConnect.Select("select batchId from batch", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox5.Items.Add(list[0][i]);
                }
                list = dbConnect.Select("select distinct name from program;", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox3.Items.Add(list[0][i]);
                }
                list = dbConnect.Select("select name from department;", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox2.Items.Add(list[0][i]);
                }
            }
            else
                MessageBox.Show("Connection Failed! Check Your Internet Connectivity.");*/
        }

        private void FillStudentIdNameDepartment()
        {
            string batch = this.comboBox5.GetItemText(this.comboBox5.SelectedItem);
            string program = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            string shift = null;
            if (radioButton1.Checked == true)
            {
                shift = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                shift = radioButton2.Text;
            }

            dbConnect = new DBConnect();
            List<string>[] list;
            if (batch != null && program != null && shift != null)
            {
                comboBox1.Items.Clear();
                comboBox6.Items.Clear();
                list = dbConnect.Select("select studentId from student where batchId=" + batch + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "');", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox1.Items.Add(list[0][i]);
                }

                list = dbConnect.Select("select name from department where departmentId=(select distinct departmentId from program where name='" + program + "')", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox2.SelectedIndex = comboBox2.FindStringExact(list[0][i]);
                }
                list = dbConnect.Select("select name from student where batchId=" + batch + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "');", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox6.Items.Add(list[0][i]);
                }
            }
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentIdNameDepartment();
        }

        private void filldatagrid()
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            string year = dateTimePicker1.Text;
            string id = comboBox1.Text;
            string semester = "XYZ";
            semester = comboBox4.Text;
            string batch = this.comboBox5.GetItemText(this.comboBox5.SelectedItem);
            string program = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            string shift = null;
            if (radioButton1.Checked == true)
            {
                shift = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                shift = radioButton2.Text;
            }
            if (year != null && semester != null && batch != null && program != null && shift != null)
            {
                list = dbConnect.Select("select courseCode, courseTitle, credit from course where courseCode in (select courseCode from registration where semesterId=(select semesterId from semester where name='" + semester + year + "') and studentId=" + id + ");", 3);
                dataGridView1.Rows.Clear();
                Int32 count = list[0].Count;
                for (int i = 0; i < count; i++)
                {

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = list[0][i];
                    dataGridView1.Rows[i].Cells[1].Value = list[1][i];
                    dataGridView1.Rows[i].Cells[9].Value = list[2][i];
                }
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            string id = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            list = dbConnect.Select("select name from student where studentId=" + id + ";", 1);
            for (int i = 0; i < list[0].Count; i++)
            {
                comboBox6.SelectedIndex = comboBox6.FindStringExact(list[0][i]);
            }

            if (comboBox4.SelectedIndex > -1)
            {
                filldatagrid();
            }
        }
        

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            filldatagrid();
        }
        public Boolean Check(int row)
        {
            Boolean value = false;
            Int32 numRows2 = dataGridView2.Rows.Count;

            for (int j = 0; j < numRows2 - 1; j++)
            {
                if (Convert.ToString(dataGridView2.Rows[j].Cells[2].Value) == Convert.ToString(dataGridView1.Rows[row].Cells[0].Value))
                    if (comboBox1.Text == Convert.ToString(dataGridView2.Rows[j].Cells[0].Value))
                        value = true;
            }

            return value;
        }

        public Boolean Check2(int row1)
        {
            Boolean value = false;
            //Int32 numRows1 = dataGridView1.Rows.Count;

            for (int j = 0; j < row1; j++)
            {
                if (Convert.ToString(dataGridView1.Rows[j].Cells[0].Value) == Convert.ToString(dataGridView1.Rows[row1].Cells[0].Value))
                    value = true;
            }

            return value;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Int32 numRows = dataGridView1.Rows.Count;

            for (int i = 0; i < numRows - 1; i++)
            {
                double total = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) + Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);

                if (dataGridView1.Rows[i].Cells[0].Value == null || Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) == string.Empty)
                    continue;

                if (total == 0)
                    continue;

                /*if (Check2(i) == true)
                {
                    //MessageBox.Show("Duplicate value in the column 'COURSE CODE'.", "Error");
                    //DataGridViewRow DelRow = dataGridView1.Rows[i];
                    //dataGridView1.Rows.Remove(DelRow);
                    dataGridView1.Rows[i+1].Cells[7].Value = null;
                }*/
                Int32 numRowsinLoop = dataGridView1.Rows.Count;
                if (numRowsinLoop > 2)
                    if (Check2(i) == true)
                        continue;


                dataGridView1.Rows[i].Cells[7].Value = total;

                if (total > 100)
                {
                    MessageBox.Show("Unexpected value in the column 'TOTAL'", "Error");
                    dataGridView1.Rows[i].Cells[7].Value = null;
                }
                else if (total >= 80.0)
                    dataGridView1.Rows[i].Cells[8].Value = 4.0;
                else if (total >= 75.0)
                    dataGridView1.Rows[i].Cells[8].Value = 3.75;
                else if (total >= 70.0)
                    dataGridView1.Rows[i].Cells[8].Value = 3.50;
                else if (total >= 65.0)
                    dataGridView1.Rows[i].Cells[8].Value = 3.25;
                else if (total >= 60.0)
                    dataGridView1.Rows[i].Cells[8].Value = 3.00;
                else if (total >= 55.0)
                    dataGridView1.Rows[i].Cells[8].Value = 2.75;
                else if (total >= 50.0)
                    dataGridView1.Rows[i].Cells[8].Value = 2.50;
                else if (total >= 45.0)
                    dataGridView1.Rows[i].Cells[8].Value = 2.25;
                else if (total >= 40.0)
                    dataGridView1.Rows[i].Cells[8].Value = 2.00;
                else if (total >= 40.0)
                    dataGridView1.Rows[i].Cells[8].Value = 2.00;
                else
                    dataGridView1.Rows[i].Cells[8].Value = 0.00;

            }

            for (int i = 0; i < numRows - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[7].Value == null || Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value) > 100.0 || Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == string.Empty)
                    continue;

                if (Check(i) == true)
                    continue;
                int number = dataGridView2.Rows.Add();
                dataGridView2.Rows[number].Cells[0].Value = comboBox1.Text;
                dataGridView2.Rows[number].Cells[1].Value = comboBox6.Text;
                dataGridView2.Rows[number].Cells[2].Value = dataGridView1.Rows[i].Cells[0].Value;
                dataGridView2.Rows[number].Cells[3].Value = dataGridView1.Rows[i].Cells[1].Value;
                dataGridView2.Rows[number].Cells[4].Value = dataGridView1.Rows[i].Cells[2].Value;
                dataGridView2.Rows[number].Cells[5].Value = dataGridView1.Rows[i].Cells[3].Value;
                dataGridView2.Rows[number].Cells[6].Value = dataGridView1.Rows[i].Cells[4].Value;
                dataGridView2.Rows[number].Cells[7].Value = dataGridView1.Rows[i].Cells[5].Value;
                dataGridView2.Rows[number].Cells[8].Value = dataGridView1.Rows[i].Cells[6].Value;
                dataGridView2.Rows[number].Cells[9].Value = dataGridView1.Rows[i].Cells[7].Value;
                dataGridView2.Rows[number].Cells[10].Value = dataGridView1.Rows[i].Cells[8].Value;
                dataGridView2.Rows[number].Cells[11].Value = dataGridView1.Rows[i].Cells[9].Value;
                //dataGridView2.Rows[number].Cells[12].Value = dataGridView1.Rows[i].Cells[10].Value;
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(DataGridView1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex != 0 && dataGridView1.CurrentCell.ColumnIndex != 1) //Desired Column
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(DataGridView1_KeyPress);
                }
            }
        }

        private void DataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
            && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            string name = this.comboBox6.GetItemText(this.comboBox6.SelectedItem);
            list = dbConnect.Select("select studentId from student where name='" + name + "';", 1);
            for (int i = 0; i < list[0].Count; i++)
            {
                comboBox1.SelectedIndex = comboBox1.FindStringExact(list[0][i]);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            int numRows1 = dataGridView2.Rows.Count;
            dbConnect = new DBConnect();
            if (numRows1 > 1)
            {
                for (int i = 0; i < numRows1 - 1; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value == null || Convert.ToString(dataGridView2.Rows[i].Cells[0].Value) == string.Empty)
                        continue;
                    if (dataGridView2.Rows[i].Cells[2].Value == null || Convert.ToString(dataGridView2.Rows[i].Cells[2].Value) == string.Empty)
                        continue;

                    string studentId = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                    string courseCode = Convert.ToString(dataGridView2.Rows[i].Cells[2].Value);

                    string midViva;
                    if (dataGridView2.Rows[i].Cells[4].Value == null || Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == string.Empty)
                        midViva = "NULL";
                    else
                        midViva = Convert.ToString(dataGridView2.Rows[i].Cells[4].Value);

                    string final;
                    if (dataGridView2.Rows[i].Cells[5].Value == null || Convert.ToString(dataGridView2.Rows[i].Cells[5].Value) == string.Empty)
                        final = "NULL";
                    else
                        final = Convert.ToString(dataGridView2.Rows[i].Cells[5].Value);

                    string classMark;
                    if (dataGridView2.Rows[i].Cells[6].Value == null || Convert.ToString(dataGridView2.Rows[i].Cells[6].Value) == string.Empty)
                        classMark = "NULL";
                    else
                        classMark = Convert.ToString(dataGridView2.Rows[i].Cells[6].Value);

                    string assignment;
                    if (dataGridView2.Rows[i].Cells[7].Value == null || Convert.ToString(dataGridView2.Rows[i].Cells[7].Value) == string.Empty)
                        assignment = "NULL";
                    else
                        assignment = Convert.ToString(dataGridView2.Rows[i].Cells[7].Value);

                    string attendance;
                    if (dataGridView2.Rows[i].Cells[8].Value == null || Convert.ToString(dataGridView2.Rows[i].Cells[8].Value) == string.Empty)
                        attendance = "NULL";
                    else
                        attendance = Convert.ToString(dataGridView2.Rows[i].Cells[8].Value);

                    dbConnect.Update("UPDATE registration SET attendance=" + attendance + ", assignment=" + assignment + ", classMark=" + classMark + ", midViva=" + midViva + " , final=" + final + " where studentId=" + studentId + " and courseCode='" + courseCode + "';");
                }
            }
            dataGridView2.Rows.Clear();
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentIdNameDepartment();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FillStudentIdNameDepartment();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FillStudentIdNameDepartment();
        }

        private void ComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            if (e.KeyCode == Keys.Enter && comboBox1.Text != null && comboBox1.Text != string.Empty)
            {
                string Id = comboBox1.Text;
                comboBox6.Items.Clear();
                list = dbConnect.Select("select name from student where studentId=" + Id + ";", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox6.Items.Add(list[0][i]);
                    comboBox6.SelectedIndex = 0;
                }

                list = dbConnect.Select("select batchId from student where studentId=" + Id + ";", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox5.SelectedIndex = comboBox5.FindStringExact(list[0][i]);
                }

                list = dbConnect.Select("select name from program where programId=(select programId from student where studentId=" + Id + ");", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox3.SelectedIndex = comboBox3.FindStringExact(list[0][i]);
                }

                list = dbConnect.Select("select name from department where departmentId=(select departmentId from program where programId=(select programId from student where studentId=" + Id + "));", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox2.SelectedIndex = comboBox2.FindStringExact(list[0][i]);
                }

                list = dbConnect.Select("select shift from program where programId=(select programId from student where studentId=" + Id + ");", 1);
                if (list[0][0] == "Regular")
                    radioButton1.Checked = true;
                else if (list[0][0] == "Evening")
                    radioButton2.Checked = true;


                e.Handled = true;
                e.SuppressKeyPress = true;

            }

        }

        private void DataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(DataGridView2_KeyPress);
            if (dataGridView2.CurrentCell.ColumnIndex != 0 && dataGridView2.CurrentCell.ColumnIndex != 1 && dataGridView2.CurrentCell.ColumnIndex != 2) //Desired Column
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(DataGridView2_KeyPress);
                }
            }

        }

        private void DataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
            && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void DataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to delete this row(s)", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Int32 selectedRowCount = dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);
                        Int32 numRows = dataGridView2.Rows.Count;
                        if (dataGridView2.SelectedRows[0].Index == numRows - 1 && selectedRowCount < 2)
                        {
                            MessageBox.Show("Uncommitted new row cannot be deleted.", "Error");
                        }
                        if (selectedRowCount > 0)
                        {
                            for (int i = 0; i < selectedRowCount - 1; i++)
                            {
                                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                            }
                        }

                    }

                    catch (InvalidOperationException x)
                    {
                        MessageBox.Show(x.Message);
                    }

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            // save the application  
            //workbook.SaveAs("G:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
    }
}

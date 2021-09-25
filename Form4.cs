using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Record
{
    public partial class Form4 : Form
    {
        private DBConnect dbConnect;
        public Form4()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy";
            dateTimePicker2.ShowUpDown = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int number = dataGridView1.Rows.Add();
            string[] subs = comboBox1.Text.Split('_');
            dataGridView1.Rows[number].Cells[0].Value = subs[0];
            dataGridView1.Rows[number].Cells[1].Value = subs[1];
            dataGridView1.Rows[number].Cells[2].Value = subs[2];

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.ColumnWidths.Add("dataGridViewTextBoxColumn1", 100);

            printer.Title = "Global University Bangladesh";

            String subtitle = "";
            subtitle = "Department: " + comboBox14.Text + ",  Program: " + comboBox11.Text + "\n Student ID:" + comboBox9.Text + " " + comboBox10.Text + "-" + dateTimePicker2.Text;
            printer.SubTitle = subtitle;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = false;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.FooterAlignment = StringAlignment.Near;
            printer.Footer = "                                                                                                                                        _______________________\n                                                                                                                                                       Register";

            printer.FooterSpacing = 20;
            printer.printDocument.DefaultPageSettings.Landscape = true;



            printer.PrintDataGridView(dataGridView2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox14.DataSource = DBConnect.DS.Tables["department"].Copy();
            comboBox14.ValueMember = "name";
            comboBox2.DataSource = DBConnect.DS.Tables["department"].Copy();
            comboBox2.ValueMember = "name";

            comboBox5.DataSource = DBConnect.DS.Tables["batch"].Copy();
            comboBox5.ValueMember = "batchId";
            comboBox12.DataSource = DBConnect.DS.Tables["batch"].Copy();
            comboBox12.ValueMember = "batchId";

            comboBox3.DataSource = DBConnect.DS.Tables["program"].Copy();
            comboBox3.ValueMember = "name";
            comboBox11.DataSource = DBConnect.DS.Tables["program"].Copy();
            comboBox11.ValueMember = "name";

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentIdNameDepartment();
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
                comboBox7.Items.Clear();
                comboBox6.Items.Clear();
                list = dbConnect.Select("select studentId,name from student where batchId=" + batch + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "');", 2);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox7.Items.Add(list[0][i]);
                    comboBox6.Items.Add(list[1][i]);
                }

                /*list = dbConnect.Select("select name from department where departmentId=(select distinct departmentId from program where name='" + program + "')", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox2.SelectedIndex = comboBox2.FindStringExact(list[0][i]);
                }
                list = dbConnect.Select("select name from student where batchId=" + batch + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "');", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox6.Items.Add(list[0][i]);
                }*/
                String year = dateTimePicker1.Text;
                String semester = this.comboBox4.GetItemText(this.comboBox4.SelectedItem);
                if (semester == "Spring")
                    semester = "1";
                else if (semester == "Summer")
                    semester = "2";
                else
                    semester = "3";

                semester = year + semester;
                comboBox1.Items.Clear();
                list = dbConnect.Select("select courseCode,courseTitle,credit from course where courseCode in (select courseCode from offeredcourse where batchId=" + batch + " and semesterId=" + semester + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "'))", 3);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox1.Items.Add(list[0][i] + "_" + list[1][i] + "_" + list[2][i]);
                }
                String Department = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                comboBox13.Items.Clear();
                list = dbConnect.Select("select courseCode,courseTitle,credit from course where courseCode in (select courseCode from offeredcourse where semesterId=" + semester + " and programId in(select programId from department where name='" + Department + "'))", 3);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox13.Items.Add(list[0][i] + "_" + list[1][i] + "_" + list[2][i]);
                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            string id = this.comboBox7.GetItemText(this.comboBox7.SelectedItem);
            list = dbConnect.Select("select name from student where studentId=" + id + ";", 1);
            for (int i = 0; i < list[0].Count; i++)
            {
                comboBox6.SelectedIndex = comboBox6.FindStringExact(list[0][i]);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            string name = this.comboBox6.GetItemText(this.comboBox6.SelectedItem);
            list = dbConnect.Select("select studentId from student where name='" + name + "';", 1);
            for (int i = 0; i < list[0].Count; i++)
            {
                comboBox7.SelectedIndex = comboBox7.FindStringExact(list[0][i]);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int number = dataGridView1.Rows.Add();
            string[] subs = comboBox13.Text.Split('_');
            dataGridView1.Rows[number].Cells[0].Value = subs[0];
            dataGridView1.Rows[number].Cells[1].Value = subs[1];
            dataGridView1.Rows[number].Cells[2].Value = subs[2];

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String ID = comboBox7.Text;
            string shift = null;
            if (radioButton1.Checked == true)
            {
                shift = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                shift = radioButton2.Text;
            }
            String program = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            String Batch = this.comboBox5.GetItemText(this.comboBox5.SelectedItem);
            String year = dateTimePicker1.Text;
            String semester = comboBox4.Text;

            if (semester == "Spring")
                semester = "1";
            else if (semester == "Summer")
                semester = "2";
            else
                semester = "3";

            semester = year + semester;

            int numRows1 = dataGridView1.Rows.Count;
            dbConnect = new DBConnect();
            if (numRows1 > 1)
            {
                for (int i = 0; i < numRows1 - 1; i++)
                {
                    String regRemarks = "NULL";
                    if (dataGridView1.Rows[i].Cells[3].Value != null)
                        regRemarks = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    dbConnect.Insert("insert into registration (registrationId,studentId,courseCode,semesterId,regDate,reamrkRegister) values (" + semester + ID + "," + ID + ",'" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'," + semester + ",'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + regRemarks + "')");

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string shift = null;
            if (radioButton4.Checked == true)
            {
                shift = radioButton4.Text;
            }
            else if (radioButton3.Checked == true)
            {
                shift = radioButton3.Text;
            }
            //string batch = comboBox10.Text;
            //string program = comboBox8.Text;
            string semester = comboBox10.Text;
            String year = dateTimePicker2.Text;
            if (semester == "Spring")
                semester = "1";
            else if (semester == "Summer")
                semester = "2";
            else
                semester = "3";

            semester = year + semester;
            dbConnect = new DBConnect();
            List<string>[] list;
            list = dbConnect.Select("select registration.courseCode, course.courseTitle, course.credit, registration.reamrkRegister from registration inner join course on registration.courseCode=course.courseCode where studentId=" + comboBox9.Text + " and semesterId=" + semester, 4);

            Int32 count = list[0].Count;
            dataGridView2.Rows.Clear();
            for (int i = 0; i < count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = list[0][i];
                dataGridView2.Rows[i].Cells[1].Value = list[1][i];
                dataGridView2.Rows[i].Cells[2].Value = list[2][i];
                dataGridView2.Rows[i].Cells[3].Value = list[3][i];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.ColumnWidths.Add("Column1", 100);

            printer.Title = "Global University Bangladesh";

            String subtitle = "";
            subtitle = "Department: " + comboBox2.Text + ",  Program: " + comboBox3.Text + "\n Student ID:" + comboBox7.Text + " " + comboBox4.Text + "-" + dateTimePicker1.Text;
            printer.SubTitle = subtitle;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = false;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.FooterAlignment = StringAlignment.Near;
            printer.Footer = "                                                                                                                                        _______________________\n                                                                                                                                                       Register";

            printer.FooterSpacing = 20;
            printer.printDocument.DefaultPageSettings.Landscape = true;



            printer.PrintDataGridView(dataGridView1);
        }

        private void fillidnameview()
        {
            string batch = this.comboBox12.GetItemText(this.comboBox12.SelectedItem);
            string program = this.comboBox11.GetItemText(this.comboBox11.SelectedItem);
            string shift = null;
            if (radioButton4.Checked == true)
            {
                shift = radioButton4.Text;
            }
            else if (radioButton3.Checked == true)
            {
                shift = radioButton3.Text;
            }

            dbConnect = new DBConnect();
            List<string>[] list;
            if (batch != null && program != null && shift != null)
            {
                comboBox9.Items.Clear();
                comboBox8.Items.Clear();
                list = dbConnect.Select("select studentId,name from student where batchId=" + batch + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "');", 2);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox9.Items.Add(list[0][i]);
                    comboBox8.Items.Add(list[1][i]);
                }
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillidnameview();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            string id = this.comboBox9.GetItemText(this.comboBox9.SelectedItem);
            list = dbConnect.Select("select name from student where studentId=" + id + ";", 1);
            for (int i = 0; i < list[0].Count; i++)
            {
                comboBox8.SelectedIndex = comboBox8.FindStringExact(list[0][i]);
            }
        }
    }
}

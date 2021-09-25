using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DGVPrinterHelper;

namespace Student_Record
{
    public partial class Form3 : Form
    {
        private DBConnect dbConnect;
        public Form3()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy";
            dateTimePicker2.ShowUpDown = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            dbConnect = new DBConnect();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete course:"+ dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[1].Value.ToString() + " from Database?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dbConnect.Delete("delete from CourseProgram where courseCode='" + dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
                dbConnect.Delete("delete from course where courseCode='"+ dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentCell.RowIndex);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = DBConnect.DS.Tables["department"].Copy();
            comboBox1.ValueMember = "name";
            comboBox6.DataSource = DBConnect.DS.Tables["department"].Copy();
            comboBox6.ValueMember = "name";
            comboBox9.DataSource = DBConnect.DS.Tables["department"].Copy();
            comboBox9.ValueMember = "name";
            comboBox5.DataSource = DBConnect.DS.Tables["batch"].Copy();
            comboBox5.ValueMember = "batchId";
            comboBox10.DataSource = DBConnect.DS.Tables["batch"].Copy();
            comboBox10.ValueMember = "batchId";
            comboBox3.DataSource = DBConnect.DS.Tables["program"].Copy();
            comboBox3.ValueMember = "name";
            comboBox7.DataSource = DBConnect.DS.Tables["program"].Copy();
            comboBox7.ValueMember = "name";
            comboBox8.DataSource = DBConnect.DS.Tables["program"].Copy();
            comboBox8.ValueMember = "name";
            comboBox2.DataSource = DBConnect.DS.Tables["program"].Copy();
            comboBox2.ValueMember = "name";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            list = dbConnect.Select("SELECT EXISTS(select courseCode from course where courseCode='" + textBox2.Text + "')", 1);
            if(list[0][0]=="0")
                dbConnect.Insert("insert into course (courseCode,courseTitle,credit,type,shortDesc) values ('" + textBox2.Text + "','" + textBox1.Text + "'," + textBox3.Text + ",'" + this.comboBox14.GetItemText(this.comboBox14.SelectedItem) + "','" + richTextBox1.Text + "')");

            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                dbConnect.Insert("insert into CourseProgram (programId,courseCode) values ((select programId from program where name='" + this.comboBox2.GetItemText(this.comboBox2.SelectedItem) + "' and shift='" + checkBox1.Text + "'),'" + textBox2.Text + "'),((select programId from program where name='" + this.comboBox2.GetItemText(this.comboBox2.SelectedItem) + "' and shift='" + checkBox2.Text + "'),'" + textBox2.Text + "')");
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                dbConnect.Insert("insert into CourseProgram (programId,courseCode) values ((select programId from program where name='" + this.comboBox2.GetItemText(this.comboBox2.SelectedItem) + "' and shift='" + checkBox1.Text + "'),'" + textBox2.Text + "')");
            }
            else
            {
                dbConnect.Insert("insert into CourseProgram (programId,courseCode) values ((select programId from program where name='" + this.comboBox2.GetItemText(this.comboBox2.SelectedItem) + "' and shift='" + checkBox2.Text + "'),'" + textBox2.Text + "')");
            }

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            String program = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            
            List<string>[] list;
            comboBox4.Items.Clear();
            list = dbConnect.Select("select courseCode,courseTitle,credit from course where courseCode in (select courseCode from CourseProgram where programId=(select programId from program where name='"+program+"' and shift='"+shift+"'))", 3);
            Int32 count = list[0].Count;
            for (int i = 0; i < count; i++)
            {
                comboBox4.Items.Add(list[0][i]+"_"+list[1][i]+"_"+list[2][i]);
            }
            comboBox13.Items.Clear();
            comboBox13.Items.Add("TBD");
            list = dbConnect.Select("select facultyMemberId,name,departmentId from facultymember", 3);
            count = list[0].Count;
            for (int i = 0; i < count; i++)
            {
                comboBox13.Items.Add(list[0][i] + "-" + list[1][i] + "-" + list[2][i]);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int number = dataGridView1.Rows.Add();
            string[] subs = comboBox4.Text.Split('_');
            dataGridView1.Rows[number].Cells[0].Value = subs[0];
            dataGridView1.Rows[number].Cells[1].Value = subs[1];
            dataGridView1.Rows[number].Cells[2].Value = subs[2];
            dataGridView1.Rows[number].Cells[3].Value = comboBox13.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
            String semester = this.comboBox11.GetItemText(this.comboBox11.SelectedItem);
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
                    
                     string[] subs = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value).Split('-');
                    
                     if(subs[0]=="TBD" || subs[0]=="")
                        dbConnect.Insert("insert into offeredcourse(courseCode, batchId, semesterId, programId) values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'," + Batch + "," + semester + ",(select programId from program where name='" + program + "' and shift='" + shift + "'))");
                     else
                        dbConnect.Insert("insert into offeredcourse(courseCode, batchId, semesterId, programId, facultyMemberId) values('"+dataGridView1.Rows[i].Cells[0].Value.ToString()+"',"+Batch+","+semester+ ",(select programId from program where name='" + program + "' and shift='" + shift + "'),"+subs[0]+")");
                    //Console.WriteLine("insert into offeredcourse(courseCode, batchId, semesterId, programId, facultyMemberId) values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'," + Batch + "," + semester + ",(select programId from program where name='" + program + "' and shift='" + shift + "')," + subs[0] + ")");
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            list = dbConnect.Select(" select courseCode,courseTitle,credit,shortDesc from course where courseCode in (select courseCode from CourseProgram where programId in(select programId from program where name='"+ comboBox7.Text + "'))", 4);
            
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

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String cc= dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString();
            String ct = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[1].Value.ToString();
            String cr = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[2].Value.ToString();
            String cd = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[3].Value.ToString();
            dbConnect = new DBConnect();
            dbConnect.Update("update course set courseTitle='"+ct+"',credit="+cr+",shortDesc='"+cd+"' where courseCode='"+cc+"'");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int numRows1 = dataGridView2.Rows.Count;
            String q = "";
            if (numRows1 > 1)
            {
                for (int i = 0; i < numRows1 - 1; i++)
                {

                    q+= "update course set courseTitle = '"+ dataGridView2.Rows[i].Cells[1].Value.ToString() + "', credit = "+ dataGridView2.Rows[i].Cells[2].Value.ToString() + ", shortDesc = '"+ dataGridView2.Rows[i].Cells[3].Value.ToString() + "' where courseCode = '"+ dataGridView2.Rows[i].Cells[0].Value.ToString() + "';";


                }
            }
            dbConnect = new DBConnect();
            dbConnect.Update(q);
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
            string batch = comboBox10.Text;
            string program = comboBox8.Text;
            string semester = comboBox12.Text;
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
            list = dbConnect.Select("select offeredcourse.courseCode, course.courseTitle, course.credit, facultymember.name from offeredcourse inner join course on offeredcourse.courseCode=course.courseCode left join facultymember on offeredcourse.facultyMemberId=facultymember.facultyMemberId where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and  batchId="+batch+" and semesterId="+semester, 4);
            //Console.WriteLine("select offeredcourse.courseCode, course.courseTitle, course.credit, facultymember.name from offeredcourse inner join course on offeredcourse.courseCode=course.courseCode left join facultymember on offeredcourse.facultyMemberId=facultymember.facultyMemberId where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and  batchId=" + batch + " and semesterId=" + semester);
            Int32 count = list[0].Count;
            dataGridView3.Rows.Clear();
            for (int i = 0; i < count; i++)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells[0].Value = list[0][i];
                dataGridView3.Rows[i].Cells[1].Value = list[1][i];
                dataGridView3.Rows[i].Cells[2].Value = list[2][i];
                dataGridView3.Rows[i].Cells[3].Value = list[3][i];
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.ColumnWidths.Add("dataGridViewTextBoxColumn5", 100);

            printer.Title = "Global University Bangladesh";

            String subtitle = "";
            subtitle = "Department: " + comboBox9.Text + ",  Program: " + comboBox8.Text + "\n Batch:"+comboBox10.Text+" " + comboBox12.Text + "-" + dateTimePicker2.Text;
            printer.SubTitle = subtitle;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = false;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.FooterAlignment = StringAlignment.Near;
            printer.Footer = "                                                                                                                                        _______________________\n                                                                                                                                                Head of Department";

            printer.FooterSpacing = 20;
            printer.printDocument.DefaultPageSettings.Landscape = true;



            printer.PrintDataGridView(dataGridView3);
        }

        private void button15_Click(object sender, EventArgs e)
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
            string batch = comboBox10.Text;
            string program = comboBox8.Text;
            string semester = comboBox12.Text;
            String year = dateTimePicker2.Text;
            if (semester == "Spring")
                semester = "1";
            else if (semester == "Summer")
                semester = "2";
            else
                semester = "3";

            semester = year + semester;
            String cc = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString();
            String ct = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[3].Value.ToString();
            
            dbConnect = new DBConnect();
            dbConnect.Update("update offeredcourse set facultyMemberId=(select distinct facultyMemberId from facultymember where name='"+ct+"')  where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and  batchId=" + batch + " and semesterId=" + semester+ " and courseCode='"+cc+"'");
        }
    }
    
}

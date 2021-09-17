using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Student_Record
{
    public partial class Form7 : Form
    {
        private DBConnect dbConnect;
        public Form7()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = DBConnect.DS.Tables["department"].Copy();
            comboBox2.ValueMember = "name";
            comboBox14.DataSource = DBConnect.DS.Tables["department"].Copy();
            comboBox14.ValueMember = "name";
            comboBox5.DataSource = DBConnect.DS.Tables["batch"].Copy();
            comboBox5.ValueMember = "batchId";
            comboBox1.DataSource = DBConnect.DS.Tables["batch"].Copy();
            comboBox1.ValueMember = "batchId";
            comboBox12.DataSource = DBConnect.DS.Tables["batch"].Copy();
            comboBox12.ValueMember = "batchId";
            comboBox11.DataSource = DBConnect.DS.Tables["program"].Copy();
            comboBox11.ValueMember = "name";
            comboBox3.DataSource = DBConnect.DS.Tables["program"].Copy();
            comboBox3.ValueMember = "name";
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.ColumnWidths.Add("Column1", 70);

            printer.Title = "Global University Bangladesh";

            String subtitle = "";
            subtitle = "Department: "+comboBox2.Text +",  Program: " + comboBox3.Text+ "\n" +comboBox4.Text+"-"+dateTimePicker1.Text;
            printer.SubTitle = subtitle;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = false;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.FooterAlignment = StringAlignment.Near;
            printer.Footer = "_____________                                           ___________________________                                           __________________________\n    Prepared by                                                                  Compared by                                                                Prof. A.K.M. Mazibur Rahman\n                                                                           Asst. Controller of Examinations                                                   Controller of Examinations";

            printer.FooterSpacing = 20;
            printer.printDocument.DefaultPageSettings.Landscape = true;



            printer.PrintDataGridView(dataGridView1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Add(this.comboBox1.GetItemText(this.comboBox1.SelectedItem));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox7.Items.Add(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 cb6count = comboBox6.Items.Count;
            Int32 cb7count = comboBox7.Items.Count;
            String cb6items = "";
            String cb7items = "";
            for (int i = 0; i < cb6count; i++)
                cb6items = cb6items +","+comboBox6.Items[i].ToString();
            
            for (int i = 0; i < cb6count; i++)
                if(i==0)
                    cb7items = comboBox6.Items[i].ToString();
                else
                    cb7items = cb7items + "," + comboBox6.Items[i].ToString();
            //MessageBox.Show(cb6items);
            String program = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            String semester = this.comboBox4.GetItemText(this.comboBox4.SelectedItem);
            String year = dateTimePicker1.Text;
            semester = year + ConvSem(semester);
            String batch = this.comboBox5.GetItemText(this.comboBox5.SelectedItem);
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
            list = null;
            if(cb6count<1 && cb7count<1)
                list = dbConnect.Select("select distinct courseCode from registration where studentId in(select studentId from student where programId=(select programId from program where name='"+program+"' and shift='"+shift+"') and batchId="+batch+") and semesterId="+semester, 1);
            else if(cb6count > 0 && cb7count < 1)
                list = dbConnect.Select("select distinct courseCode from registration where studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId in (" + batch + cb6items+")) and semesterId=" + semester, 1);
            else if (cb6count <1 && cb7count > 0)
                list = dbConnect.Select("select distinct courseCode from registration where (studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId=" + batch + ")or  studentId in(" + cb7items + ")) and semesterId=" + semester, 1);
            else
                list = dbConnect.Select("select distinct courseCode from registration where (studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId in (" + batch + cb6items + ")) or studentId in("+cb7items+")) and semesterId=" + semester, 1);

            //Console.WriteLine("select distinct courseCode from registration where (studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId in (" + batch + cb6items + ")) or studentId in(" + cb7items + ")) and semesterId=" + semester);


            //Console.WriteLine("select courseCode from registration where studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId=" + batch + ") and semesterId=" + semester);

            Int32 count = list[0].Count;
            dataGridView1.Rows.Clear();
            Int32 dcc = dataGridView1.ColumnCount;
            for (int i = 3; i <= dcc; i++)
                dataGridView1.Columns.Remove("Column"+ Convert.ToString(i));
            
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Columns.Add("Column"+Convert.ToString(i+3), list[0][i]); 
            }
            if (cb6count < 1 && cb7count < 1)
                list = dbConnect.Select("select studentId,name from student where studentId in(select distinct studentId from registration where studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId=" + batch + ") and semesterId=" + semester+")", 2);
            else if (cb6count > 0 && cb7count < 1)
                list = dbConnect.Select("select studentId,name from student where studentId in(select distinct studentId from registration where studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId in (" + batch + cb6items + ")) and semesterId=" + semester + ")", 2);
            else if (cb6count < 1 && cb7count > 0)
                list = dbConnect.Select("select studentId,name from student where studentId in(select distinct studentId from registration where (studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId=" + batch + ")or  studentId in(" + cb7items + ")) and semesterId=" + semester + ")", 2);
            else
                list = dbConnect.Select("seelct studentId,name from student where where studentId in(select distinct studentId from registration where (studentId in(select studentId from student where programId=(select programId from program where name='" + program + "' and shift='" + shift + "') and batchId in (" + batch + cb6items + ")) or studentId in(" + cb7items + ")) and semesterId=" + semester + ")", 2);
            count = list[0].Count;
            //dataGridView1.Rows.Clear();
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = list[0][i];
                dataGridView1.Rows[i].Cells[1].Value = list[1][i];
            }
            Int32 drc = dataGridView1.RowCount;
            Int32 dcc2 = dataGridView1.ColumnCount;
            Double earnedgp=0.0;
            Double totalcredit = 0.0;
            dcc = dataGridView1.ColumnCount;
            dataGridView1.Columns.Add("Column" + Convert.ToString(dcc + 1),"Total Credit");
            dataGridView1.Columns.Add("Column" + Convert.ToString(dcc + 2), "GPE");
            dataGridView1.Columns.Add("Column" + Convert.ToString(dcc + 3), "GPA");
            for (int i = 0; i < drc-1; i++)
            {
                for (int j = 2; j < dcc2; j++)
                {
                    String courseCode = dataGridView1.Columns[j].HeaderText;
                    list = dbConnect.Select("select (ifnull(attendance,0)+ifnull(assignment,0)+ifnull(classMark,0)+ifnull(midViva,0)+ifnull(final,0))as total from registration where studentId=" + dataGridView1.Rows[i].Cells[0].Value.ToString() + " and courseCode='"+courseCode+"' and semesterId="+semester, 1);
                    
                        Double total = Math.Ceiling(Convert.ToDouble(list[0][0]));
                        Double gp = GP(total);
                        dataGridView1.Rows[i].Cells[j].Value = gp.ToString("0.00");
                    list = dbConnect.Select("select credit from course where courseCode='" + courseCode + "'", 1);
                    earnedgp = earnedgp + (gp * Convert.ToDouble(list[0][0]));
                    totalcredit = totalcredit + Convert.ToDouble(list[0][0]);
                }
                dataGridView1.Rows[i].Cells[dcc].Value = totalcredit.ToString("0.00");
                dataGridView1.Rows[i].Cells[dcc+1].Value = earnedgp.ToString("0.00");
                dataGridView1.Rows[i].Cells[dcc + 2].Value = (earnedgp/totalcredit).ToString("0.00");
                earnedgp = 0.0;
                totalcredit = 0.0;
            }
        }

        private Double GP(Double total)
        {
            Double gp = 0.00;
            if (total >= 80.0)
                gp = 4.0;
            else if (total >= 75.0)
                gp = 3.75;
            else if (total >= 70.0)
                gp = 3.50;
            else if (total >= 65.0)
                gp = 3.25;
            else if (total >= 60.0)
                gp = 3.00;
            else if (total >= 55.0)
                gp = 2.75;
            else if (total >= 50.0)
                gp = 2.50;
            else if (total >= 45.0)
                gp = 2.25;
            else if (total >= 40.0)
                gp = 2.00;
            else if (total >= 40.0)
                gp = 2.00;
            else
                gp = 0.00;
            
            return gp;
        }
        private Int16 ConvSem(String s)
        {
            if (s == "Spring")
                return 1;
            else if (s == "Summer")
                return 2;
            else
                return 3;
        }
        private void FillStudentIdNameDepartment()
        {
            string batch = this.comboBox12.GetItemText(this.comboBox12.SelectedItem);
            string program = this.comboBox11.GetItemText(this.comboBox11.SelectedItem);
            string shift = null;
            if (radioButton3.Checked == true)
            {
                shift = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                shift = radioButton4.Text;
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

                /*list = dbConnect.Select("select name from department where departmentId=(select distinct departmentId from program where name='" + program + "')", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox2.SelectedIndex = comboBox2.FindStringExact(list[0][i]);
                }*/
                /*list = dbConnect.Select("select name from student where batchId=" + batch + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "');", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox8.Items.Add(list[0][i]);
                }*/
                
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentIdNameDepartment();
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

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            string name = this.comboBox9.GetItemText(this.comboBox9.SelectedItem);
            list = dbConnect.Select("select studentId from student where name='" + name + "';", 1);
            for (int i = 0; i < list[0].Count; i++)
            {
                comboBox8.SelectedIndex = comboBox8.FindStringExact(list[0][i]);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string batch = this.comboBox12.GetItemText(this.comboBox12.SelectedItem);
            Int32 sem1= Convert.ToInt32(this.comboBox10.GetItemText(this.comboBox10.SelectedItem));
            Int32 sem2 = Convert.ToInt32(this.comboBox13.GetItemText(this.comboBox13.SelectedItem));
            Int32 semrange = 0;
            if (sem2>=sem1)
                semrange = sem2 -sem1+1;
            else
                semrange = sem1 - sem2 + 1;
            Int32 semyear = Convert.ToInt32("20" + batch[0]+batch[1]);
            Int32 semsem = Convert.ToInt32( batch[2].ToString());
            Int32 count = 0;
            String[] sems = new String[12];
            
            for(int j=0; j<12;j++)
            {
                sems[count] = semyear.ToString()+semsem.ToString();
                if (semsem == 3)
                {
                    semyear += 1;
                    semsem = 1;
                }
                else
                    semsem += 1;
                    
                    count++;
            }
            count = 0;

        }
    }
    
}

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
            string shift = null;
            if (radioButton5.Checked == true)
            {
                shift = radioButton5.Text;
            }
            else if (radioButton6.Checked == true)
            {
                shift = radioButton6.Text;
            }
            dbConnect = new DBConnect();
            
            dbConnect.Insert("insert into course (courseCode,courseTitle,credit,type,shortDesc) values ('"+textBox2.Text+ "','"+textBox1.Text+ "',"+ textBox3.Text+ ",'"+ this.comboBox14.GetItemText(this.comboBox14.SelectedItem)+ "','"+ richTextBox1.Text+"')");
            dbConnect.Insert("insert into CourseProgram (programId,courseCode) values ((select programId from program where name='"+ this.comboBox2.GetItemText(this.comboBox2.SelectedItem) + "' and shift='"+shift+"'),'"+ textBox2.Text + "')");

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
            list = dbConnect.Select("select courseCode,courseTitle,credit from course where courseCode in (select courseCode from CourseProgram where programId=(select programId from program where name='"+program+"' and shift='"+shift+"'))", 3);
            Int32 count = list[0].Count;
            for (int i = 0; i < count; i++)
            {
                comboBox4.Items.Add(list[0][i]+"_"+list[1][i]+"_"+list[1][i]);
            }
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

                    dbConnect.Insert("insert into offeredcourse(courseCode, batchId, semesterId, programId, facultyMemberId) values('"+dataGridView1.Rows[i].Cells[0].Value.ToString()+"',"+Batch+","+semester+ ",(select programId from program where name='" + program + "' and shift='" + shift + "'),"+subs[0]+")");
                    
                }
            }
        }
    }
    
}

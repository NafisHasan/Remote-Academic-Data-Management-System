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
    }
    
}

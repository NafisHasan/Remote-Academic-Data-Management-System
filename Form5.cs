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
    public partial class Form5 : Form
    {
        private DBConnect dbConnect;
        public Form5()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.CustomFormat = "yyy-MM-dd";

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = DBConnect.DS.Tables["department"].DefaultView;
            comboBox2.ValueMember = "name";
            comboBox11.DataSource = DBConnect.DS.Tables["department"].DefaultView;
            comboBox11.ValueMember = "name";
            comboBox5.DataSource = DBConnect.DS.Tables["batch"].DefaultView;
            comboBox5.ValueMember = "batchId";
            comboBox10.DataSource = DBConnect.DS.Tables["batch"].DefaultView;
            comboBox10.ValueMember = "batchId";
            comboBox3.DataSource = DBConnect.DS.Tables["program"].DefaultView;
            comboBox3.ValueMember = "name";
            comboBox8.DataSource = DBConnect.DS.Tables["program"].DefaultView;
            comboBox8.ValueMember = "name";
            Int32 semester = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (semester < 5)
                semester = 1;
            else if (semester < 9)
                semester = 2;
            else
                semester = 3;
            String batch = DateTime.Now.ToString("yyyy");
            batch = batch[2].ToString()+batch[3].ToString() + semester.ToString();
            
            try
            {
                comboBox5.SelectedIndex = comboBox5.FindStringExact(batch);
            }
            finally
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
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
            list = dbConnect.Select("select MAX(studentId) from student where batchId=" + batch + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "');", 1);
            
            if(list[0][0] != "")
            textBox6.Text =Convert.ToString(Convert.ToInt32(list[0][0])+1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox2.Text;
            String dob = dateTimePicker2.Text;
            String bg = this.comboBox7.GetItemText(this.comboBox7.SelectedItem);
            String religion = textBox10.Text;
            String email = textBox12.Text;
            String contactN = textBox1.Text;
            String gender = this.comboBox6.GetItemText(this.comboBox6.SelectedItem);
            String nationality = textBox8.Text;
            String nid = textBox11.Text;
            String brg = textBox9.Text;
            String parmanentA = richTextBox2.Text;
            String presentA = richTextBox1.Text;
            String fname = textBox3.Text;
            String fcontact = textBox5.Text;
            String mname = textBox13.Text;
            String mcontact = textBox14.Text;
            String ID = textBox6.Text;
            String batch = this.comboBox5.GetItemText(this.comboBox5.SelectedItem);
            String program = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            String remarks = textBox4.Text;
            String shift = null;
            if (radioButton1.Checked == true)
            {
                shift = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                shift = radioButton2.Text;
            }
            String gname = textBox17.Text;
            String gcontact = textBox19.Text;
            String gaddress = richTextBox3.Text;
            String relationwithS = textBox15.Text;
            dbConnect = new DBConnect();
            dbConnect.Insert("insert into student(studentId,batchId,programId,name,contact,father,fatherContact,mother,motherContact,mailingAddress,permanentAddress,email,gender,reilgion,bloodGroup,NID,birthReg,nationality,dob,remark) values("+ID+","+batch+ ",(select programId from program where name='" + program + "' and shift='" + shift + "'),'"+name+"','"+contactN+"','"+fname+"','"+fcontact+"','"+mname+"','"+mcontact+"','"+presentA+"','"+parmanentA+"','"+email+"','"+email+"','"+religion+"','"+bg+"','"+nid+"','"+brg+"','"+nationality+"','"+dob+"','"+remarks+"')");
            dbConnect.Insert("insert into guardian(studentId,name,contact,mailingAddress,relationWithStudent) values("+ID+",'"+gname+"','"+gcontact+"','"+gaddress+"','"+relationwithS+"')");
            int numRows1 = dataGridView1.Rows.Count;
            dbConnect = new DBConnect();
            if (numRows1 > 1)
            {
                for (int i = 0; i < numRows1 - 1; i++)
                {

                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "CLASS")
                        dbConnect.Insert("insert into education(educationId, exam, year,rollID, department, baord, resultType, resultClass, outOf) values(" + ID+", '"+ dataGridView1.Rows[i].Cells[0].Value.ToString() + "',"+ dataGridView1.Rows[i].Cells[1].Value.ToString() + ",'"+ dataGridView1.Rows[i].Cells[4].Value.ToString() + "','"+ dataGridView1.Rows[i].Cells[2].Value.ToString() + "','"+ dataGridView1.Rows[i].Cells[3].Value.ToString() + "','"+ dataGridView1.Rows[i].Cells[5].Value.ToString() + "',"+ dataGridView1.Rows[i].Cells[6].Value.ToString() + ","+ dataGridView1.Rows[i].Cells[7].Value.ToString() + ")");
                    else if(dataGridView1.Rows[i].Cells[5].Value.ToString() == "GPA")
                        dbConnect.Insert("insert into education(educationId, exam, year,rollID, department, baord, resultType, resultGPA, outOf) values(" + ID + ", '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'," + dataGridView1.Rows[i].Cells[1].Value.ToString() + ",'"+ dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "'," + dataGridView1.Rows[i].Cells[6].Value.ToString() + "," + dataGridView1.Rows[i].Cells[7].Value.ToString() + ")");
                    

                }
            }

        }
    }
}

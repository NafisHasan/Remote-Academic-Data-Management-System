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
            comboBox8.DataSource = DBConnect.DS.Tables["batch"].DefaultView;
            comboBox8.ValueMember = "batchId";
            comboBox3.DataSource = DBConnect.DS.Tables["program"].DefaultView;
            comboBox3.ValueMember = "name";
            comboBox10.DataSource = DBConnect.DS.Tables["program"].DefaultView;
            comboBox10.ValueMember = "name";
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
            dbConnect = new DBConnect();
            dbConnect.Update("update student set name='"+ dataGridView2.Rows[0].Cells[1].Value.ToString() + "',contact='"+ dataGridView2.Rows[1].Cells[1].Value.ToString() + "',father='"+ dataGridView2.Rows[2].Cells[1].Value.ToString() + "',fatherContact='"+ dataGridView2.Rows[3].Cells[1].Value.ToString() + "',mother='"+ dataGridView2.Rows[4].Cells[1].Value.ToString() + "',motherContact='"+ dataGridView2.Rows[5].Cells[1].Value.ToString() + "',mailingAddress='"+ dataGridView2.Rows[6].Cells[1].Value.ToString() + "',permanentAddress='"+ dataGridView2.Rows[7].Cells[1].Value.ToString() + "',email='"+ dataGridView2.Rows[8].Cells[1].Value.ToString() + "',gender='"+ dataGridView2.Rows[9].Cells[1].Value.ToString() + "',reilgion='"+ dataGridView2.Rows[10].Cells[1].Value.ToString() + "',bloodGroup='"+ dataGridView2.Rows[11].Cells[1].Value.ToString() + "',NID='"+ dataGridView2.Rows[12].Cells[1].Value.ToString() + "',birthReg='"+ dataGridView2.Rows[13].Cells[1].Value.ToString() + "',nationality='"+ dataGridView2.Rows[14].Cells[1].Value.ToString() + "',dob='"+ dataGridView2.Rows[15].Cells[1].Value.ToString() + "',remark='"+ dataGridView2.Rows[16].Cells[1].Value.ToString() + "' where studentId=" + comboBox12.Text);
            dbConnect.Update("update guardian set name='"+ dataGridView4.Rows[0].Cells[1].Value.ToString() + "',relationWithStudent='"+ dataGridView4.Rows[1].Cells[1].Value.ToString() + "',contact='"+ dataGridView4.Rows[2].Cells[1].Value.ToString() + "',mailingAddress='"+ dataGridView4.Rows[0].Cells[1].Value.ToString() + "' where studentId=" + comboBox12.Text);
            int numRows1 = dataGridView3.Rows.Count;
            if (numRows1 > 1)
            {
                for (int i = 0; i < numRows1 - 1; i++)
                {

                    if (dataGridView3.Rows[i].Cells[5].Value.ToString() == "CLASS")
                        dbConnect.Insert("update education set exam='"+ dataGridView3.Rows[i].Cells[0].Value.ToString() + "', year="+ dataGridView3.Rows[i].Cells[1].Value.ToString() + ",rollID='"+ dataGridView3.Rows[i].Cells[2].Value.ToString() + "', department='"+ dataGridView3.Rows[i].Cells[3].Value.ToString() + "', baord='"+ dataGridView3.Rows[i].Cells[4].Value.ToString() + "', resultType='"+ dataGridView3.Rows[i].Cells[5].Value.ToString() + "', resultClass="+ dataGridView3.Rows[i].Cells[6].Value.ToString() + ", outOf="+ dataGridView3.Rows[i].Cells[7].Value.ToString() + " where educationId=" + comboBox12.Text);
                    else if (dataGridView3.Rows[i].Cells[5].Value.ToString() == "GPA")
                        dbConnect.Insert("update education set exam='" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "', year=" + dataGridView3.Rows[i].Cells[1].Value.ToString() + ",rollID='" + dataGridView3.Rows[i].Cells[2].Value.ToString() + "', department='" + dataGridView3.Rows[i].Cells[3].Value.ToString() + "', baord='" + dataGridView3.Rows[i].Cells[4].Value.ToString() + "', resultType='" + dataGridView3.Rows[i].Cells[5].Value.ToString() + "', resultGPA=" + dataGridView3.Rows[i].Cells[6].Value.ToString() + ", outOf=" + dataGridView3.Rows[i].Cells[7].Value.ToString() + " where educationId=" + comboBox12.Text);


                }
            }
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

            Int32 check = 0;
            String warning = "";
            if (name == "")
            {
                warning += "Name,";
                check = 1;
            }
            if (dob == "")
            {
                warning += " Birth Date,";
                check = 1;
            }
            if (bg == "")
            {
                warning += " Blood Group,";
                check = 1;
            }
            if (religion == "")
            {
                warning += " Religion,";
                check = 1;
            }
            if (email == "")
            {
                warning += " Email,";
                check = 1;
            }
            if (contactN == "")
            {
                warning += " Contact Number,";
                check = 1;
            }
            if (gender == "")
            {
                warning += " Gender,";
                check = 1;
            }
            if (nationality == "")
            {
                warning += " Nationality,";
                check = 1;
            }
            if (nid == "" && brg == "")
            {
                warning += " NID or Birth Reg,";
                check = 1;
            }
            if (parmanentA == "")
            {
                warning += " Parmanent Address,";
                check = 1;
            }
            if (presentA == "")
            {
                warning += " Present Address,";
                check = 1;
            }
            if (fname == "")
            {
                warning += " Father's Name,";
                check = 1;
            }
            if (fcontact == "")
            {
                warning += " Father's Contact,";
                check += 1;
            }
            if (mname == "")
            {
                warning += " Mother's Name,";
                check = 1;
            }
            if (mcontact == "")
            {
                warning += " Mother's Contact,";
                check = 1;
            }
            if (mcontact == "")
            {
                warning += " Mother's Contact,";
                check = 1;
            }
            if (ID == "")
            {
                warning += " ID,";
                check = 1;
            }
            if (batch == "")
            {
                warning += " Batch,";
                check = 1;
            }
            if (program == "")
            {
                warning += " Program,";
                check = 1;
            }
            if (shift == "")
            {
                warning += " Shift,";
                check = 1;
            }
            if (gname == "")
            {
                warning += " Guardian Section Name,";
                check = 1;
            }
            if (gcontact == "")
            {
                warning += " Guardian Section Contact,";
                check = 1;
            }
            if (gaddress == "")
            {
                warning += " Guardian Section Address,";
                check = 1;
            }
            if (relationwithS == "")
            {
                warning += " Guardian Section Relation,";
                check = 1;
            }

            Int32 ped = dataGridView1.RowCount;
            if (ped < 2)
            {
                warning += " Previous Educational Qualification,";
                check = 1;
            }

            if (check > 0)
                MessageBox.Show(warning+" FIELDS CAN NOT BE EMPTY");
            else
            {
                dbConnect = new DBConnect();
                dbConnect.Insert("insert into student(studentId,batchId,programId,name,contact,father,fatherContact,mother,motherContact,mailingAddress,permanentAddress,email,gender,reilgion,bloodGroup,NID,birthReg,nationality,dob,remark) values(" + ID + "," + batch + ",(select programId from program where name='" + program + "' and shift='" + shift + "'),'" + name + "','" + contactN + "','" + fname + "','" + fcontact + "','" + mname + "','" + mcontact + "','" + presentA + "','" + parmanentA + "','" + email + "','" + gender + "','" + religion + "','" + bg + "','" + nid + "','" + brg + "','" + nationality + "','" + dob + "','" + remarks + "')");
                dbConnect.Insert("insert into guardian(studentId,name,contact,mailingAddress,relationWithStudent) values(" + ID + ",'" + gname + "','" + gcontact + "','" + gaddress + "','" + relationwithS + "')");
                int numRows1 = dataGridView1.Rows.Count;
                //dbConnect = new DBConnect();
                if (numRows1 > 1)
                {
                    for (int i = 0; i < numRows1 - 1; i++)
                    {

                        if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "CLASS")
                            dbConnect.Insert("insert into education(educationId, exam, year,rollID, department, baord, resultType, resultClass, outOf) values(" + ID + ", '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'," + dataGridView1.Rows[i].Cells[1].Value.ToString() + ",'" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "'," + dataGridView1.Rows[i].Cells[6].Value.ToString() + "," + dataGridView1.Rows[i].Cells[7].Value.ToString() + ")");
                        else if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "GPA")
                            dbConnect.Insert("insert into education(educationId, exam, year,rollID, department, baord, resultType, resultGPA, outOf) values(" + ID + ", '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'," + dataGridView1.Rows[i].Cells[1].Value.ToString() + ",'" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "'," + dataGridView1.Rows[i].Cells[6].Value.ToString() + "," + dataGridView1.Rows[i].Cells[7].Value.ToString() + ")");


                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            String[] s1 = new String[17] { "Full Name", "Contact Number", "Father's Name", "Father's Contact", "Mother's Name", "Mother's Contact", "Present Address", "Parmanent Address", "Email", "Gender", "Religion", "Blood Group", "NID", "Birth Reg. Number", "Nationality", "Date of Birth", "Reamarks" };
            dbConnect = new DBConnect();
            List<string>[] list;
            list = dbConnect.Select("select name,contact,father,fatherContact,mother,motherContact,mailingAddress,permanentAddress,email,gender,reilgion,bloodGroup,NID,birthReg,nationality,dob,remark from student where studentId="+comboBox12.Text, 17);
            
            for (int i= 0;i< 17; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = s1[i];
                dataGridView2.Rows[i].Cells[1].Value = list[i][0];
                //if (i == 15)
               // {
                   // Console.WriteLine(list[i][0]);
                    //DateTime asDate = DateTime.ParseExact(list[i][0], "dd/MM/yyyy hh:mm:ss ", System.Globalization.CultureInfo.InvariantCulture);
                    
                    //dataGridView2.Rows[i].Cells[1].Value = asDate.ToString("yyyy-MM-dd");
                //}
            }
            String[] s2 = new String[4] { "Name", "Relation With Student", "Contact Number", "Present Address" };
            list = dbConnect.Select("select name,relationWithStudent,contact,mailingAddress from guardian where studentId=" + comboBox12.Text, 4);

            for (int i = 0; i < 4; i++)
            {
                dataGridView4.Rows.Add();
                dataGridView4.Rows[i].Cells[0].Value = s2[i];
                dataGridView4.Rows[i].Cells[1].Value = list[i][0];
            }
            list = dbConnect.Select("select exam,year,department,baord,rollID,resultType,ifnull(resultGPA,resultClass)as result,outOf from education  where educationId=" + comboBox12.Text, 8);
            Int32 count = list[0].Count;
            for (int i = 0; i < count; i++)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells[0].Value = list[0][i];
                dataGridView3.Rows[i].Cells[1].Value = list[1][i];
                dataGridView3.Rows[i].Cells[2].Value = list[2][i];
                dataGridView3.Rows[i].Cells[3].Value = list[3][i];
                dataGridView3.Rows[i].Cells[4].Value = list[4][i];
                dataGridView3.Rows[i].Cells[5].Value = list[5][i];
                if (list[5][i] == "CLASS")
                {
                    dataGridView3.Rows[i].Cells[6].Value = (int)Convert.ToDouble(list[6][i]);
                    dataGridView3.Rows[i].Cells[7].Value = (int)Convert.ToDouble(list[6][i]);
                }
                else
                {
                    dataGridView3.Rows[i].Cells[6].Value = list[6][i];
                    dataGridView3.Rows[i].Cells[7].Value = list[7][i];
                }
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentIdNameDepartment();
        }
        private void FillStudentIdNameDepartment()
        {
            string batch = this.comboBox8.GetItemText(this.comboBox8.SelectedItem);
            string program = this.comboBox10.GetItemText(this.comboBox10.SelectedItem);
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
                comboBox12.Items.Clear();
                list = dbConnect.Select("select studentId from student where batchId=" + batch + " and programId=(select programId from program where name='" + program + "' and shift='" + shift + "');", 1);
                for (int i = 0; i < list[0].Count; i++)
                {
                    comboBox12.Items.Add(list[0][i]);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Are you sure, you want to DELETE all data relate to STUDENT ID: "+ comboBox12.Text + " from DATABASE", "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (comboBox12.Text != "")
                {
                    dbConnect = new DBConnect();
                    dbConnect.Delete("delete from student where studentId=" + comboBox12.Text);
                    dbConnect.Delete("delete from guardian where studentId=" + comboBox12.Text);
                    dbConnect.Delete("delete from education where educationId=" + comboBox12.Text);
                }
            }
            
        }
    }
}

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
            printer.ColumnWidths.Add("Column1", 200);

            printer.Title = "DataGridView Report";

            printer.SubTitle = "An Easy to Use DataGridView Printing Object \n testetstets";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "Your Company Name Here";

            printer.FooterSpacing = 15;
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
            list = dbConnect.Select("select courseCode from registration where studentId in(select studentId from student where programId=(select programId from program where name='"+program+"' and shift='"+shift+"') and batchId="+batch+") and semesterId="+semester, 1);
            Int32 count = list[0].Count;
            for (int i = 0; i < count; i++)
            {
                //Console.WriteLine(list[0]);
                dataGridView1.Columns.Add("Column"+(i+3), list[i].ToString());
            }
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
    }
    
}

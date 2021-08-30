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
        public Form5()
        {
            InitializeComponent();
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
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

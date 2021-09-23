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
    public partial class Form6 : Form
    {
        private DBConnect dbConnect;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*dbConnect = new DBConnect();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath + ".sql";
                dbConnect.backup(folderBrowserDialog1.SelectedPath+".sql");
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            String name = dateTime.ToString("dd-MM-yyyy");
            saveFileDialog1.Filter = "sql files (*.sql)| *.sql | All files(*.*) | *.* ";
            saveFileDialog1.FileName = "RADMSdbBackup"+name;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".sql";
            saveFileDialog1.CheckPathExists = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbConnect = new DBConnect();
                dbConnect.backup(saveFileDialog1.FileName);
            }
        }
    }
}

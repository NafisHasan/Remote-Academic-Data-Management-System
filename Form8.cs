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
    public partial class Form8 : Form
    {
        private DBConnect dbConnect;
        public Form8()
        {
            InitializeComponent();
        }
        //Form8 fm8 = null;
        Form7 fm7 = null;
        Form6 fm6 = null;
        Form5 fm5 = null;
        Form4 fm4 = null;
        Form3 fm3 = null;
        Form2 fm2 = null;
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (fm2 == null || fm2.Text == "")
            {
                fm2 = new Form2
                {
                    MdiParent = Form1.ActiveForm,
                    Dock = DockStyle.Fill
                };
                fm2.Show();
            }
            else if (CheckOpened(fm2.Text))
            {
                fm2.WindowState = FormWindowState.Normal;
                fm2.Dock = DockStyle.Fill;
                fm2.Show();
                fm2.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fm7 == null || fm7.Text == "")
            {
                fm7 = new Form7
                {
                    MdiParent = this.MdiParent,
                    Dock = DockStyle.Fill
                };
                fm7.Show();
            }
            else if (CheckOpened(fm7.Text))
            {
                
                fm7.WindowState = FormWindowState.Normal;
                fm7.Dock = DockStyle.Fill;
                //fm7.Activate();
                fm7.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (fm3 == null || fm3.Text == "")
            {
                fm3 = new Form3
                {
                    MdiParent = Form1.ActiveForm,
                    Dock = DockStyle.Fill
                };
                fm3.Show();
            }
            else if (CheckOpened(fm3.Text))
            {
                fm3.WindowState = FormWindowState.Normal;
                fm3.Dock = DockStyle.Fill;
                //fm3.Show();
                fm3.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fm4 == null || fm4.Text == "")
            {
                fm4 = new Form4
                {
                    MdiParent = Form1.ActiveForm,
                    Dock = DockStyle.Fill
                };
                fm4.Show();
            }
            else if (CheckOpened(fm4.Text))
            {
                fm4.WindowState = FormWindowState.Normal;
                fm4.Dock = DockStyle.Fill;
                //fm4.Show();
                fm4.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fm5 == null || fm5.Text == "")
            {
                fm5 = new Form5
                {
                    MdiParent = Form1.ActiveForm,
                    Dock = DockStyle.Fill
                };
                fm5.Show();
            }
            else if (CheckOpened(fm5.Text))
            {
                fm5.WindowState = FormWindowState.Normal;
                fm5.Dock = DockStyle.Fill;
                //fm5.Show();
                fm5.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fm6 == null || fm6.Text == "")
            {
                fm6 = new Form6
                {
                    MdiParent = Form1.ActiveForm,
                    Dock = DockStyle.Fill
                };
                fm6.Show();
            }
            else if (CheckOpened(fm6.Text))
            {
                fm6.WindowState = FormWindowState.Normal;
                fm6.Dock = DockStyle.Fill;
                //fm6.Show();
                fm6.Focus();
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            String dmy = dateTime.ToString("ddMMyyyy");
            String conString = "SERVER=" + textBox1.Text + ";" + "UID=" + textBox2.Text + ";" + "PASSWORD=" + textBox3.Text + ";SslMode=none;convert zero datetime=True";
            dbConnect = new DBConnect();
            dbConnect.createdb("create database RADMS"+dmy, conString);
            String con = "SERVER=" + textBox1.Text + "; DATABASE =RADMS"+dmy+" ;" + "UID=" + textBox2.Text + ";" + "PASSWORD=" + textBox3.Text + ";SslMode=none;convert zero datetime=True"; //"DATABASE="
            dbConnect.Initablecreate(Application.StartupPath + "\\RADMS.sql", con);
            Properties.Settings.Default.serverIP = EncDec.EncryptString(EncDec.ToSecureString(textBox1.Text));
            Properties.Settings.Default.databaseName = "RADMS"+dmy;
            Properties.Settings.Default.serverUID = EncDec.EncryptString(EncDec.ToSecureString(textBox2.Text));
            Properties.Settings.Default.ServerPSW = EncDec.EncryptString(EncDec.ToSecureString(textBox3.Text));
            Properties.Settings.Default.Save();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "sql files (*.sql)| *.sql | All files(*.*) | *.* ";
            saveFileDialog1.FileName = "RADMS";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".sql";
            saveFileDialog1.CheckPathExists = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(Application.StartupPath+"\\RADMS.sql", saveFileDialog1.FileName, true);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.serverIP = EncDec.EncryptString(EncDec.ToSecureString(textBox11.Text));
            Properties.Settings.Default.databaseName = textBox8.Text;
            Properties.Settings.Default.serverUID = EncDec.EncryptString(EncDec.ToSecureString(textBox10.Text));
            Properties.Settings.Default.ServerPSW = EncDec.EncryptString(EncDec.ToSecureString(textBox9.Text));
            Properties.Settings.Default.Save();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = " SQL File(.sql) | *.sql ";
            openFileDialog1.DefaultExt = ".sql";
            openFileDialog1.AddExtension = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbConnect = new DBConnect();
                dbConnect.restore(openFileDialog1.FileName);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            String name = dateTime.ToString("dd-MM-yyyy");
            saveFileDialog1.Filter = "sql files (*.sql)| *.sql | All files(*.*) | *.* ";
            saveFileDialog1.FileName = "RADMSdbBackup" + name;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".sql";
            saveFileDialog1.CheckPathExists = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbConnect = new DBConnect();
                dbConnect.backup(saveFileDialog1.FileName);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            List<string>[] list;
            list =dbConnect.Select("select password from alluser where userId='"+textBox12.Text+"';", 1);
            if (list[0][0] == EncDec.CreateMD5Hash(textBox13.Text))
            {
                
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                this.MdiParent.MainMenuStrip.Enabled = true;
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.userauthpass = EncDec.CreateMD5Hash(textBox13.Text);
                    Properties.Settings.Default.userid = textBox12.Text;
                    Properties.Settings.Default.userauth = "1";
                    Properties.Settings.Default.Save();
                }
            }
            else
                MessageBox.Show("WRONG USER ID OR PASSWORD");
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            this.MdiParent.MainMenuStrip.Enabled = false;
            if (Properties.Settings.Default.userauth=="1")
            {
                dbConnect = new DBConnect();
                List<string>[] list;
                list = dbConnect.Select("select password from alluser where userId='" + Properties.Settings.Default.userid + "';", 1);
                if (list[0][0] == Properties.Settings.Default.userauthpass)
                {

                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    this.MdiParent.MainMenuStrip.Enabled = true;
                    
                }
                else
                    MessageBox.Show("WRONG USER ID OR PASSWORD");
            }

            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userauthpass = "";
            Properties.Settings.Default.userid = "";
            Properties.Settings.Default.userauth = "0";
            Properties.Settings.Default.Save();
        }
    }
}

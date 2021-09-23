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
    }
}

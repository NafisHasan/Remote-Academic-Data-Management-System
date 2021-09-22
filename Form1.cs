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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form8 fm8 = null;
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
        private void EXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit", "Warning! Save changes before exit.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                }
            }
            else if(dialogResult == DialogResult.No)
            {
                
            }
        }


        private void DATABASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm5 == null || fm5.Text == "")
            {
                fm5 = new Form5
                {
                    MdiParent = this,
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

       
        private void COURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm3 == null || fm3.Text == "")
            {
                fm3 = new Form3
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                fm3.Show();
            }
            else if (CheckOpened(fm3.Text))
            {
                fm3.WindowState = FormWindowState.Normal;
                fm3.Dock = DockStyle.Fill;
                fm3.Show();
                fm3.Focus();
            }
        }

        private void FEESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm4 == null || fm4.Text == "")
            {
                fm4 = new Form4
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                fm4.Show();
            }
            else if (CheckOpened(fm4.Text))
            {
                fm4.WindowState = FormWindowState.Normal;
                fm4.Dock = DockStyle.Fill;
                fm4.Show();
                fm4.Focus();
            }
        }

        private void USERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm6 == null || fm6.Text == "")
            {
                fm6 = new Form6
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                fm6.Show();
            }
            else if (CheckOpened(fm6.Text))
            {
                fm6.WindowState = FormWindowState.Normal;
                fm6.Dock = DockStyle.Fill;
                fm6.Show();
                fm6.Focus();
            }
        }

        private void RESULTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (fm2 == null || fm2.Text == "")
            {
                fm2 = new Form2
                {
                    MdiParent = this,
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
            }*/
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBConnect dbConnect = new DBConnect();
            dbConnect.FillDataSet("select name from department", "department");
            dbConnect.FillDataSet("select batchId from batch", "batch");
            dbConnect.FillDataSet("select name from program", "program");
            
            if (fm2 == null || fm2.Text == "")
            {
                fm2 = new Form2
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                fm2.Show();
            }
            else if (CheckOpened(fm2.Text))
            {
                fm2.WindowState = FormWindowState.Normal;
                fm2.Dock = DockStyle.Fill;
                fm2.Focus();
            }

        }

        private void MenuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
          /* if (e.Item.Text == "")

            {
                e.Item.Visible = false;
            }*/
        }

        private void vIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm7 == null || fm7.Text == "")
            {
                fm7 = new Form7
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                fm7.Show();
            }
            else if (CheckOpened(fm7.Text))
            {
                fm7.WindowState = FormWindowState.Normal;
                fm7.Dock = DockStyle.Fill;
                //fm7.Show();
                fm7.Focus();
            }
        }

        private void iNPUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm2 == null || fm2.Text == "")
            {
                fm2 = new Form2
                {
                    MdiParent = this,
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

        private void cONFIGURATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm8 == null || fm8.Text == "")
            {
                fm8 = new Form8
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                fm8.Show();
            }
            else if (CheckOpened(fm8.Text))
            {
                fm8.WindowState = FormWindowState.Normal;
                fm8.Dock = DockStyle.Fill;
                //fm8.Show();
                fm8.Focus();
            }
        }

        /*protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }*/
    }
}

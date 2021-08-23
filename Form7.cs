using DGVPrinterHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Student_Record
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            /*dataGridView1.ClearSelection();
            dataGridView1.Rows[0].Selected = false;
            dataGridView1.CurrentCell = null;*/
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
    }
}

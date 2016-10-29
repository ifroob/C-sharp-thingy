using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        int count = 1;

        public int Euclid(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else return Euclid(b, a % b);

        }

        public int LCM(int a, int b)
        {
            return (a * b) / Euclid(a, b);
        }

        /// <summary>
        /// GUI stuff below here
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listView1.Scrollable = true;
            listView1.View = View.Details;
            listView1.HeaderStyle = ColumnHeaderStyle.None;

            ColumnHeader header = new ColumnHeader();
            header.Text = "Click the buttons on the right to calculate.";
            header.Name = "MyColumn1";
            header.Width = listView1.Width;
            listView1.Columns.Add(header);
        }

        private void label1_Click(object sender, EventArgs e)
        { }


        private void button1_Click(object sender, EventArgs e) // Euclid
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    string noInputWarning = "No input found!";
                    MessageBox.Show(noInputWarning, "Error");
                }
                else
                {
                    int text1 = Convert.ToInt32(textBox1.Text);
                    int text2 = Convert.ToInt32(textBox2.Text);
                    ListViewItem i1 = new ListViewItem(count.ToString() + ")\t GCD(" + text1.ToString() + ", " + text2.ToString() + ") = " + Euclid(text1, text2).ToString(), 0);
                    listView1.Items.Add(i1);
                    ++count;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("There was some invalid input.  Try again.", "Exception Caught");
            }
        }

        private void button2_Click(object sender, EventArgs e) // GCD
        {

            try
            {

                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    string noInputWarning = "No input found!";
                    MessageBox.Show(noInputWarning, "Error");
                }
                else
                {
                    //throw new NotImplementedException();
                    int text1 = Convert.ToInt32(textBox1.Text);
                    int text2 = Convert.ToInt32(textBox2.Text);
                    ListViewItem i1 = new ListViewItem(count.ToString()+ ")\t LCM(" + text1.ToString() + ", " + text2.ToString() + ") = " + LCM(text1, text2).ToString(), 1);
                    listView1.Items.Add(i1);
                    ++count;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("There was some invalid input.  Try again.", "Exception Caught");
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}

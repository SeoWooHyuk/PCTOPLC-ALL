using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCTOPLC_ALL
{
    public partial class Form1 : Form
    {
        ucPannel.UserControl1 ucPannel1 = new ucPannel.UserControl1();
        ucPannel.UserControl2 ucPannel2 = new ucPannel.UserControl2();
        ucPannel.UserControl3 ucPannel3 = new ucPannel.UserControl3();
        ucPannel.UserControl4 ucPannel4 = new ucPannel.UserControl4();
        ucPannel.UserControl5 ucPannel5 = new ucPannel.UserControl5();


        public Form1()
        {
            InitializeComponent();
            panel1.Controls.Add(ucPannel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(ucPannel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(ucPannel2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(ucPannel3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(ucPannel4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(ucPannel5);
        }
    }
}

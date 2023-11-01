using PCTOPLC_ALL.ucPannel.uc1class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PCTOPLC_ALL.ucPannel
{
    public partial class UserControl1 : UserControl
    {

        Thread _thread = null;

        public UserControl1()
        {
            InitializeComponent();
        }

   
        private void button2_Click(object sender, EventArgs e) //문자열 변환  //알파벳은 문자하나당 1BYTE 8bit씩소모
        {
            string _str = textBox2.Text.ToString();

            BytebtASC bytebtASC = new BytebtASC();
            List<BytebtASCVO> list = bytebtASC.asccheck(_str);
            listBox1.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i].Decimal_number);
                listBox1.Items.Add(list[i].Binary_number);
                listBox1.Items.Add(list[i].Octal_number);
                listBox1.Items.Add(list[i].Hex_number);
                listBox1.Items.Add("--");
            }
        }

      
    }
}

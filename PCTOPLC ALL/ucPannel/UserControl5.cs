using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using PCTOPLC_ALL.ucPannel.uc1class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PCTOPLC_ALL.ucPannel
{
    public partial class UserControl5 : UserControl
    {

        SerialPort port = new SerialPort();
        public UserControl5()
        {
            InitializeComponent();
            textBox1.Enabled = port.IsOpen;
            button2.Enabled = port.IsOpen;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var item in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e) //시리얼 통신 연결작업
        {
            if (comboBox1.Text == "") return;

            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                }
                else
                {

                   
                    port.PortName = comboBox1.SelectedItem.ToString();
                    port.BaudRate = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                    port.DataBits = Convert.ToInt32(comboBox3.SelectedItem.ToString()); ;

                    string parity = comboBox4.SelectedItem.ToString();

                    if (parity.Equals("없음"))
                    {
                        port.Parity = Parity.None;
                    }
                    else if (parity.Equals("홀수"))
                    {
                        port.Parity = Parity.Odd;
                    }
                    else if (parity.Equals("짝수")) {
                        port.Parity = Parity.Even;
                    }

                    if (comboBox5.SelectedItem.ToString().Equals("1"))
                    {
                        port.StopBits = StopBits.One;
                        
                    }
                    else
                    {
                        port.StopBits = StopBits.Two;
                    }

                
                  

                    port.Open();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("연결에러" + ex);
            }

            button1.Text = port.IsOpen ? "연결해제" : "연결하기";
            comboBox1.Enabled = !port.IsOpen;
            textBox1.Enabled = port.IsOpen;
            button2.Enabled = port.IsOpen;
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {


            string _str = textBox1.Text.ToString();


            if (port.IsOpen)
            {
                port.Write(_str);
            }


            BytebtASC bytebtASC = new BytebtASC();
            List<BytebtASCVO> list = bytebtASC.asccheck(_str);
            listBox1.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add("D" + i);
                listBox1.Items.Add(list[i].Original_str);
                listBox1.Items.Add(list[i].Decimal_number);
                listBox1.Items.Add(list[i].Binary_number);
                listBox1.Items.Add(list[i].Octal_number);
                listBox1.Items.Add(list[i].Hex_number);
                listBox1.Items.Add("--");
            }






        }
    }
}

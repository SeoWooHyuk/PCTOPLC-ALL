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
using System.Collections;
using System.Threading;

namespace PCTOPLC_ALL.ucPannel
{
    public partial class UserControl5 : UserControl
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        SerialPort port = new SerialPort();
        Thread _thread = null;
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
                    timer.Stop();
                    port.Close();
                }
                else
                {
                    timerstart();


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

                    port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived); //이것이 꼭 필요하다


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
       
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;



        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)  //수신 이벤트가 발생하면 이 부분이 실행된다.
        {
            this.Invoke(new EventHandler(MySerialReceived));  //메인 쓰레드와 수신 쓰레드의 충돌 방지를 위해 Invoke 사용. MySerialReceived로 이동하여 추가 작업 실행.
        }


        private void MySerialReceived(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
        {
            int ReceiveData = port.ReadByte();  //시리얼 버터에 수신된 데이타를 ReceiveData 읽어오기
            listBox2.Items.Add(string.Format("{0:X2}", ReceiveData));  //int 형식을 string형식으로 변환하여 출력

        }


        private void button2_Click(object sender, EventArgs e) //통신연결 포트에 쓰기
        {


            string _str = textBox1.Text.ToString();


            if (port.IsOpen)
            {
                port.Write(_str); //현재포트에 쓴다
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

        private void button3_Click(object sender, EventArgs e) //아스키 변환테스트
        {

            string _str = textBox1.Text.ToString();
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


        //타이머

        public void timerstart()
        {
           
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        
        
        }

      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCTOPLC_ALL.ucPannel.uc1class
{

    public class BytebtASC
    {

        short[] sInt = new short[100]; //10진수
        string[] str_temp;
        byte[] bytes;
        string binaryString;
        string binaryString2;
        string binaryString3;
        int asciiValue;

        List<BytebtASCVO> list = new List<BytebtASCVO>();
       
        public List<BytebtASCVO> asccheck(string _str) {

            string str = _str;
       

            if (_str == "")
            {
                sInt = new short[10];
                Array.Clear(sInt, 0, sInt.Length);
            }


            if (str.Length % 2 == 0) //문자길이가 짝수라면
            {
                str_temp = new string[str.Length / 2];
                sInt = new short[str_temp.Length];



                for (int i = 0; i < str.Length / 2; i++)
                {
                    str_temp[i] = str.Substring(i * 2, 2); //문자하나당 4bit 소모 2개씩 8bit묶어서표현


                }


                for (int i = 0; i < str_temp.Length; i++)
                {


               
                    bytes = Encoding.ASCII.GetBytes(str_temp[i]);
                    short sh = BitConverter.ToInt16(bytes, 0);
                    sInt[i] = sh;
                   
                    int asciiValue = (int)sInt[i]; //아스키 변환
                    string binaryString = Convert.ToString(asciiValue, 2);
                    string binaryString2 = Convert.ToString(asciiValue, 8);
                    string binaryString3 = Convert.ToString(asciiValue, 16);
                    StringBuilder output = new StringBuilder();
                    for (int j = 0; j < binaryString.Length; j++)
                    {
                        output.Append(binaryString[j]);
                        if ((j + 1) % 8 == 0) // 8글자마다
                        {
                            output.Append(" "); // 뛰어쓰기 추가
                        }
                    }

                    BytebtASCVO bt = new BytebtASCVO(); //값을 담는역활
                    bt.Decimal_number = "2byte 10진수변환 " + asciiValue;
                    bt.Binary_number = "2byte 2진수변환 " + output.ToString() + "길이 " + binaryString.Length;
                    bt.Octal_number = "2byte 8진수변환 " + binaryString2;
                    bt.Hex_number = "2byte 16진수변환 " + binaryString3;

                    list.Add(bt);

                }
            }
            else  //문자열 길이가 홀수라면
            {
                str_temp = new string[(str.Length / 2) + 1];
                sInt = new short[str_temp.Length];

           

                for (int i = 0; i < str.Length / 2 + 1; i++)
                {
                    if (i < (str.Length - 1) / 2)
                    {
                        str_temp[i] = str.Substring(i * 2, 2);

                    }
                    else
                    {
                        str_temp[i] = str.Substring(i * 2, 1);

                    }

                }


                for (int i = 0; i < str_temp.Length; i++)
                {

                    BytebtASCVO bt = new BytebtASCVO(); //값을 담는역활


                    if (i < str_temp.Length - 1)
                    {

                        bytes = Encoding.ASCII.GetBytes(str_temp[i]);

                        short sh = BitConverter.ToInt16(bytes, 0);
                        sInt[i] = sh;

                        asciiValue = (int)sInt[i]; //아스키 변환 10진수
                        binaryString = Convert.ToString(asciiValue, 2);
                        binaryString2 = Convert.ToString(asciiValue, 8);
                        binaryString3 = Convert.ToString(asciiValue, 16);
                        StringBuilder output = new StringBuilder();
                        for (int j = 0; j < binaryString.Length; j++)
                        {
                            output.Append(binaryString[j]);
                            if ((j + 1) % 8 == 0) // 8글자마다
                            {
                                output.Append(" "); // 뛰어쓰기 추가
                            }
                        }

                        bt.Decimal_number = "2byte 10진수변환 " + asciiValue;
                        bt.Binary_number = "2byte 2진수변환 " + output.ToString() + "길이 " + binaryString.Length;
                        bt.Octal_number = "2byte 8진수변환 " + binaryString2;
                        bt.Hex_number = "2byte 16진수변환 " + binaryString3;

                        list.Add(bt);
                    }
                    else //문자열이 단 하나일때
                    {

                        StringBuilder output = new StringBuilder();
                     

                        bytes = Encoding.UTF8.GetBytes(str_temp[i]);
                        int[] utfcheck = new int[bytes.Length];
                      

                        for (int j = 0; j < bytes.Length; j++)
                        {
                            char asciiChar = (char)bytes[j]; // 바이트를 ASCII 문자로 변환
                            asciiValue = (int)asciiChar; //아스키 변환

                            if (bytes.Length == 1)
                            {
                               
                                binaryString = Convert.ToString(asciiValue, 2);
                                binaryString2 = Convert.ToString(asciiValue, 8);
                                binaryString3 = Convert.ToString(asciiValue, 16);
                                bt.Decimal_number = "2byte 10진수변환 " + asciiValue;
                                bt.Binary_number = "2byte 2진수변환 " + binaryString + "길이 " + binaryString.Length;
                                bt.Octal_number = "2byte 8진수변환 " + binaryString2;
                                bt.Hex_number = "2byte 16진수변환 " + binaryString3;

                            }
                            else {


                                utfcheck[j] = asciiValue; //utf각 비트를 1비트씩 분리하여 저장

                            }


                        }


                        if (bytes.Length >= 3)
                        {
                            foreach (int item in utfcheck)
                            {
                                asciiValue += (int)item;
                                binaryString +=  Convert.ToString(item, 2);
                                binaryString2 += Convert.ToString(item, 8);
                                binaryString3 += Convert.ToString(item, 16);
                     

                            }

                            for (int j = 0; j < binaryString.Length; j++)
                            {
                                output.Append(binaryString[j]);
                                if ((j + 1) % 8 == 0) // 8글자마다
                                {
                                    output.Append(" "); // 뛰어쓰기 추가
                                }
                            }
                            bt.Decimal_number = "2byte 10진수변환 " + Convert.ToInt32(binaryString,2);
                            bt.Binary_number = "2byte 2진수변환 " + output + "길이 " + binaryString.Length;
                            bt.Octal_number = "2byte 8진수변환 " + binaryString2;
                            bt.Hex_number = "2byte 16진수변환 " + binaryString3;


                        }
                 





                   




                        list.Add(bt);

                    }

                    
                }
            }



            return list; 
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTOPLC_ALL.ucPannel.uc1class
{
    public class BytebtASCVO
    {
        private string original_str;
        private string binary_number;
        private string octal_number;
        private string decimal_number;
        private string hex_number;

        public string Original_str { get => original_str; set => original_str = value; }
        public string Binary_number { get => binary_number; set => binary_number = value; }
        public string Octal_number { get => octal_number; set => octal_number = value; }
        public string Decimal_number { get => decimal_number; set => decimal_number = value; }
        public string Hex_number { get => hex_number; set => hex_number = value; }
    }
}

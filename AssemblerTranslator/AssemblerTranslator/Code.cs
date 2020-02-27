using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;


namespace AssemblerTranslator
{
    class Code
    {
        Dictionary<string, string> dest = new Dictionary<string, string>();
        Dictionary<string, string> comp = new Dictionary<string, string>();
        Dictionary<string, string> jump = new Dictionary<string, string>();

        public Code()
        {

            dest.Add("NULL", "000");
            dest.Add("M", "001");
            dest.Add("D", "010");
            dest.Add("MD", "011");
            dest.Add("A", "100");
            dest.Add("AM", "101");
            dest.Add("AD", "110");
            dest.Add("AMD", "111");

            comp.Add("0", "0101010");
            comp.Add("1", "0111111");
            comp.Add("-1", "0111010");
            comp.Add("D", "0001100");
            comp.Add("A", "0110000");
            comp.Add("M", "1110000");
            comp.Add("!D", "0001101");
            comp.Add("!A", "0110001");
            comp.Add("!M", "1110001");
            comp.Add("-D", "0001111");
            comp.Add("-A", "0110011");
            comp.Add("-M", "1110011");
            comp.Add("D+1", "0011111");
            comp.Add("A+1", "0110111");
            comp.Add("M+1", "1110111");
            comp.Add("D-1", "0001110");
            comp.Add("A-1", "0110010");
            comp.Add("M-1", "1110010");
            comp.Add("D+A", "0000010");
            comp.Add("D+M", "1000010");
            comp.Add("D-A", "0010011");
            comp.Add("D-M", "1010011");
            comp.Add("A-D", "0000111");
            comp.Add("M-D", "1000111");
            comp.Add("D&A", "0000000");
            comp.Add("D&M", "1000000");
            comp.Add("D|A", "0010101");
            comp.Add("D|M", "1010101");

            jump.Add("NULL", "000");
            jump.Add("JGT", "001");
            jump.Add("JEQ", "010");
            jump.Add("JGE", "011");
            jump.Add("JLT", "100");
            jump.Add("JNE", "101");
            jump.Add("JLE", "110");
            jump.Add("JMP", "111");
        }

        public string Comp(string mnemonic)
        {
            if (string.IsNullOrEmpty(mnemonic) || mnemonic == null)
                mnemonic = "NULL";
            return comp[mnemonic];
        }

        public string Dest(string mnemonic)
        {
            if (string.IsNullOrEmpty(mnemonic) || mnemonic == null)
                mnemonic = "NULL";
            return dest[mnemonic];
        }

        public string Jump(string mnemonic)
        {
            if (string.IsNullOrEmpty(mnemonic) || mnemonic == null)
                mnemonic = "NULL";
            return jump[mnemonic];
        }

        public string StringToBinary(string data)
        {
            int bin = int.Parse(data);
            data = Convert.ToString(bin, 2);
            return data.PadLeft(15, '0');
        }


    }
}

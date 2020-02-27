using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace AssemblerTranslator
{
    class SymbolTable
    {
        Hashtable hashtable = new Hashtable();
        int dataAddress;
        int commandAddress;
        public int DataAddress { get { return dataAddress; } set { dataAddress++; } }
        public int CommandAddress { get { return commandAddress; } set { commandAddress++; } }

        public SymbolTable()
        {
            hashtable.Add("SP", 0);
            hashtable.Add("LCL", 1);
            hashtable.Add("ARG", 2);
            hashtable.Add("THIS", 3);
            hashtable.Add("THAT", 4);
            hashtable.Add("R0", 0);
            hashtable.Add("R1", 1);
            hashtable.Add("R2", 2);
            hashtable.Add("R3", 3);
            hashtable.Add("R4", 4);
            hashtable.Add("R5", 5);
            hashtable.Add("R6", 6);
            hashtable.Add("R7", 7);
            hashtable.Add("R8", 8);
            hashtable.Add("R9", 9);
            hashtable.Add("R10", 10);
            hashtable.Add("R11", 11);
            hashtable.Add("R12", 12);
            hashtable.Add("R13", 13);
            hashtable.Add("R14", 14);
            hashtable.Add("R15", 15);
            hashtable.Add("SCREEN", 16384);
            hashtable.Add("KBD", 24576);

            dataAddress = 16;
            commandAddress = 0;
        }



        public int GetDataAddress()
        {
            return dataAddress;
        }

        public void PlusCommandAddress()
        {
            commandAddress++;
        }
        public void PlusDataAddress()
        {
            dataAddress++;
        }
        public void AddEntry(string symbol, int adress)
        {
            hashtable.Add(symbol, adress);
        }

        public bool Contains(string symbol)
        {
            if (hashtable.Contains(symbol)) return true;
            else return false;
        }

        string f = null;
        public int GetAddress(string symbol)
        {
            f = symbol;
            return (int)hashtable[symbol];
        }
    }
}

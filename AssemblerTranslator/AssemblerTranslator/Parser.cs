using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AssemblerTranslator
{
    class Parser
    {
        StreamReader streamReader;
        string line;
        string nextLine;
        void StreamReader(string path)
        {
            streamReader = new StreamReader(path);
        }

        public Parser(string path)
        {
            StreamReader(path);
            nextLine = NextLine();
        }
        private string NextLine()
        {
            do
            {
                nextLine = streamReader.ReadLine();
                if (nextLine == null) return null;
            } while (string.IsNullOrEmpty(nextLine) || nextLine.Trim().StartsWith("//"));

            if (nextLine.Contains("//"))
                nextLine = nextLine.Substring(0, nextLine.IndexOf("//") - 1);


            return nextLine;
        }

        public bool hasMoreCommands()
        {
            return (nextLine != null);
        }

        public string CommandType()
        {
            line = line.Trim();
            if (line.StartsWith("(") && line.EndsWith(")"))
                return "L_COMMAND";
            else if (line.StartsWith("@"))
                return "A_COMMAND";
            else
                return "C_COMMAND";
        }

        public void Advance()
        {
            line = nextLine;
            nextLine = NextLine();
        }

        public string Symbol()
        {
            if (CommandType() == "A_COMMAND") return line.Substring(1);
            else if (CommandType() == "L_COMMAND") return line.Substring(1, line.Length - 2);
            else return null;
        }

        public string Comp()
        {
            string str = line;
            if (line.IndexOf("=") != -1) str = line.Substring(line.IndexOf("=") + 1);
            if (str.IndexOf(";") != -1) return str.Substring(0, str.IndexOf(";"));
            else return str;
        }

        public string Jump()
        {
            if (line.IndexOf(";") > 0) return line.Substring(line.IndexOf(";") + 1);
            else return null;
        }

        public string Dest()
        {
            if (line.IndexOf("=") != -1) return line.Substring(0, line.IndexOf("="));
            else return null;
        }

        public void CLoseFile()
        {
            streamReader.Dispose();
        }

    }
}

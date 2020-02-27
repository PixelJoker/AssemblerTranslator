using System;
using System.IO;
using System.Text;
using System.Collections;


namespace AssemblerTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            bool check = true;

            while (check)
            {
                Console.Clear();
                // All variant files
                Console.WriteLine("Please, choose file");
                Console.WriteLine("1 - Add.asm");
                Console.WriteLine("2 - Max.asm");
                Console.WriteLine("3 - MaxL.asm");
                Console.WriteLine("4 - Pong.asm");
                Console.WriteLine("5 - PongL.asm");
                Console.WriteLine("6 - Rect.asm");
                Console.WriteLine("7 - RectL.asm\n");
                //Choose which file translate
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                //paths to .asm file and new .hack file
                string path = null;
                string pathWrite = null;

                switch (choice)
                {
                    case 1:
                        {
                            path =  @".\add\Add.asm";
                            pathWrite = @".\add\Add.hack";
                            break;
                        }
                    case 2:
                        {
                            path =  @".\max\\Max.asm";
                            pathWrite = @".\max\Max.hack";
                            break;
                        }
                    case 3:
                        {
                            path = @".\max\MaxL.asm";
                            pathWrite = @".\max\MaxL.hack";
                            break;
                        }
                    case 4:
                        {
                            path = @".\pong\Pong.asm";
                            pathWrite = @".\pong\Pong.hack";
                            break;
                        }
                    case 5:
                        {
                            path = @".\pong\PongL.asm";
                            pathWrite = @".\pong\PongL.hack";
                            break;
                        }
                    case 6:
                        {
                            path = @".\rect\Rect.asm";
                            pathWrite = @".\rect\Rect.hack";
                            break;
                        }
                    case 7:
                        {
                            path = @".\rect\RectL.asm";
                            pathWrite = @".\rect\RectL.hack";
                            break;
                        }
                }

                Code code = new Code();
                Parser parser = new Parser(path);
                SymbolTable symbolTable = new SymbolTable();
                StreamWriter streamWriter = new StreamWriter(pathWrite);

                //Record to HASH
                while (parser.hasMoreCommands())
                {
                    parser.Advance();
                    if (parser.CommandType() == "L_COMMAND")
                        symbolTable.AddEntry(parser.Symbol(), symbolTable.CommandAddress);
                    else symbolTable.CommandAddress++;
                }

                //Parse
                Parser parserSecontStep = new Parser(path);
                while (parserSecontStep.hasMoreCommands())
                {
                    parserSecontStep.Advance();

                    string line = null;
                    //parse A command
                    if (parserSecontStep.CommandType() == "A_COMMAND")
                    {
                        string address = null;

                        if (!char.IsDigit(parserSecontStep.Symbol()[0]))
                        {
                            if (!symbolTable.Contains(parserSecontStep.Symbol()))
                            {
                                symbolTable.AddEntry(parserSecontStep.Symbol(), symbolTable.DataAddress);
                                symbolTable.DataAddress++;
                            }

                            address = (symbolTable.GetAddress(parserSecontStep.Symbol())).ToString();
                        }
                        else address = parserSecontStep.Symbol();

                        //write to line A command
                        line = "0" + code.StringToBinary(address);
                    }
                    else if (parserSecontStep.CommandType() == "C_COMMAND")
                    {
                        //write to line C command 
                        line = "111" + code.Comp(parserSecontStep.Comp()) + code.Dest(parserSecontStep.Dest()) + code.Jump(parserSecontStep.Jump());
                    }

                    if (parserSecontStep.CommandType() != "L_COMMAND")
                    {
                        //Write to file command
                        streamWriter.WriteLine(line);
                        Console.WriteLine(line);
                    }

                }
                //Close file stream
                parser.CLoseFile();
                parserSecontStep.CLoseFile();
                streamWriter.Close();

                Console.WriteLine("\nПродолжить перевод файлов ?\n y - да| n - нет");
                char contin = (char)Console.Read(); Console.ReadLine();
                if (contin == 'y' || contin == 'Y')
                    check = true;
                else check = false;
            }
        }
    }
}

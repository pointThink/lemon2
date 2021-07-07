using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Lemon2.Command;
using Lemon2.Command.Commands;

namespace Lemon2 {

    class Program {

        static string Version = "0.3.0";
        static string Authors = "pointThink";

        public static List<CommandBase> Cmds = new List<CommandBase>();

        static void Main() {

            Console.Clear();
            Console.Title = "Lemon2";

            // Adding commands
            Cmds.Add(new PWD());
            Cmds.Add(new Set());
            Cmds.Add(new Exit());
            Cmds.Add(new CD());
            Cmds.Add(new LS());
            Cmds.Add(new Delete());
            Cmds.Add(new Mk());
            Cmds.Add(new Move());
            Cmds.Add(new Task());
            Cmds.Add(new Clear());
            Cmds.Add(new Info());
            Cmds.Add(new Beep());
            Cmds.Add(new Drives());
            Cmds.Add(new Download());
            Cmds.Add(new Mail());
            Cmds.Add(new LZip());

            Console.WriteLine("Lemon2 v" + Version);
            Console.WriteLine("By " + Authors);
            Console.WriteLine();

            while (true) {

                string inp = InputPrompt();
                inp = Variables.Variables.Replace(inp);
                
                Console.WriteLine();

                try {

                    Execute(inp);
                    Console.WriteLine();

                } catch(IndexOutOfRangeException) {

                    // If the IndexOutOfRangeException occurs we know the ammout of arguments is invalid
                    Utils.showError("Invalid parameter length");

                }  catch(Exception e) {

                    // Shows error when exception occurs
                    Utils.showError("Problem in program\n" + e);
                    Console.WriteLine();
                }

            }
            
        }

        static string InputPrompt() {

            Console.Write("[");

            // Name segment
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Lemon ");

            // Path Segment
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Directory.GetCurrentDirectory());

            Console.ResetColor();
            Console.Write("]");

            // Input char
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n$ ");

            Console.ResetColor();

            // Input
            return Console.ReadLine();

        }     

        public static void Execute(string cmd) {

            string[] args = Utils.ParseArguments(cmd);
            
            CommandBase c = Utils.getCommandByName(args[0]);

            /* If command returned by Utils.getCommandName() is null
            the program will attempt to run an executable file */
            if (c != null) {
                c.onCommand(args);

            } else {

                try {

                    Process p = new Process();

                    p.StartInfo.FileName = args[0];
                    p.StartInfo.Arguments = cmd.Substring(args[0].Length);
                    
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;

                    p.Start();

                    // On the fly output writing
                    while (!p.StandardOutput.EndOfStream) {
                        Console.WriteLine(p.StandardOutput.ReadLine());
                    }

                } catch(Win32Exception) {

                    /* If the FileNotFound exception occurs the program knows the file does not exits
                    and was probably an invalid command */
                    Utils.showError("Command or executable file not found");

                }
                
            }

        } 

    }
}


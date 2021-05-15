using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

using Lemon2.Command;
using Lemon2.Command.Commands;

namespace Lemon2 {

    class Program {

        public static string Version = "0.1.0";
        public static string Authors = "pointThink";

        public static List<CommandBase> cmds = new List<CommandBase>();

        static void Main(string[] args) {

            Console.Title = "Lemon2";

            // Adding commands
            cmds.Add(new Exit());
            cmds.Add(new CD());
            cmds.Add(new LS());
            cmds.Add(new Delete());
            cmds.Add(new Mk());
            cmds.Add(new Move());
            cmds.Add(new Task());
            cmds.Add(new Clear());
            cmds.Add(new Info());
            cmds.Add(new Beep());

            Console.WriteLine("Setup complete");
            Console.Beep();
            Console.WriteLine();

            Console.WriteLine("Lemon2 v" + Version);
            Console.WriteLine("By " + Authors);
            Console.WriteLine();

            while (true) {

                string inp = InputPrompt();
                Console.WriteLine();

                try {

                    Execute(inp);
                    Console.WriteLine();

                } catch(IndexOutOfRangeException) {

                    // If the IndexOutOfRangeException occurs we know the ammout of arguments is invalid
                    Utils.showError("Invalid parameter length");

                }  catch(Exception e) {

                    // Shows error when exception occurs
                    Utils.showError("Problem in program\n" + e.ToString());
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
            Console.Write("] ");

            // Input char
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$ ");

            Console.ResetColor();

            // Input
            return Console.ReadLine();

        }     

        static void Execute(string cmd) {

            string[] args = Utils.ParseArguments(cmd);
            
            CommandBase c = Utils.getCommandByName(args[0]);

            // If command returned by Utils.getCommandName() is null
            // the program will attempt to run an executable file
            if (c != null) {
                c.onCommand(args);

            } else if (c == null) {

                try {

                    Process p = new Process();

                    p.StartInfo.FileName = args[0];
                    p.StartInfo.Arguments = cmd.Substring(args[0].Length);
                    
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;

                    p.Start();

                    while (!p.StandardOutput.EndOfStream) {
                        Console.WriteLine(p.StandardOutput.ReadLine());
                    }

                } catch(FileNotFoundException) {

                    // If the FileNotFound exception occurs the program knows the file does not exits
                    // and was probably an invalid command
                    Utils.showError("Command or executable file not found");

                }
            }

        } 

    }
}

using System;
using System.IO;
using System.Globalization;

namespace Lemon2.Command.Commands {

    public class Info : CommandBase {

        public Info() : base("info", "show information about item", "info <type>") {}

        public override void onCommand(string[] args) {

            if (args[1] == "file") {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Creation time: ");
                Console.ResetColor();
                Console.WriteLine(File.GetCreationTime(args[2]));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Last write: ");
                Console.ResetColor();
                Console.WriteLine(File.GetLastWriteTime(args[2]));

            } else if (args[1] == "time") {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Current Date and Time is : ");  
                Console.ResetColor();
                DateTime now = DateTime.Now;  
                Console.WriteLine(now);

            } else if (args[1] == "cmd") {

                foreach (CommandBase c in Lemon2.Program.cmds) {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(c.name + ": ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(c.desc + " | " + c.syntax);

                    Console.ResetColor();

                }

            }
            
        }
    }
}
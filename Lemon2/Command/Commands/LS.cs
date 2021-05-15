using System;
using System.IO;

using Lemon2.Command;

namespace Lemon2.Command.Commands {

    public class LS : CommandBase {

        public LS() : base("ls", "Lists directory contents", "ls <dir>") {}

        public override void onCommand(string[] args) {

            Console.WriteLine("Directory listing of " + args[1]);
            Console.WriteLine();

            string[] dirs = Directory.GetDirectories(args[1]);
            string[] files = Directory.GetFiles(args[1]);
            
            foreach (string fName in dirs) {

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(Utils.getFileNameFromPath(fName));
                Console.ResetColor();
                Console.WriteLine("\\");

            }

            foreach (string fName in files) {

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Utils.getFileNameFromPath(fName));

            }

            Console.ResetColor();

        }
        
    }
}
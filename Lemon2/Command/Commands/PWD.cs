using System;
using System.IO;

namespace Lemon2.Command.Commands {
    
    public class PWD : CommandBase {

        public PWD() : base("pwd", "prints working directory", "pwd") {}

        public override void onCommand(string[] args) {
            
            Console.WriteLine(Directory.GetCurrentDirectory());
            
        }
    }
}
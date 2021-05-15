using System;
using System.IO;

using Lemon2.Command;

namespace Lemon2.Command.Commands {

    public class Clear : CommandBase {

        public Clear() : base("clear", "Clears the screen", "clear") {}

        public override void onCommand(string[] args) {

            Console.Clear();

        }
        
    }
}
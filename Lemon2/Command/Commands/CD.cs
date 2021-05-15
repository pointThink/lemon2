using System;
using System.IO;

using Lemon2.Command;

namespace Lemon2.Command.Commands {

    public class CD : CommandBase {

        public CD() : base("cd", "Changes current workin directory", "cd <dir>") {}

        public override void onCommand(string[] args) {

            Directory.SetCurrentDirectory(args[1]);
            
        }
        
    }
}
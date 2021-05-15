using System;
using Lemon2.Command;

namespace Lemon2.Command.Commands {

    public class Exit : CommandBase {

        public Exit() : base("exit", "Exits lemon", "exit") {}

        public override void onCommand(string[] args) {
            Environment.Exit(0);
        }
        
    }
}
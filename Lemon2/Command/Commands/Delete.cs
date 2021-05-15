using System;
using System.IO;

using Lemon2.Command;

namespace Lemon2.Command.Commands {

    public class Delete : CommandBase {

        public Delete() : base("del", "Deletes file / dir", "del <path>") {}

        public override void onCommand(string[] args) {

            Utils.Delete(args[1]);
            
        }
        
    }
}
using System;
using System.IO;

using Lemon2.Command;

namespace Lemon2.Command.Commands {

    public class Mk : CommandBase {

        public Mk() : base("mk", "makes file / dir", "make <file/dir> <path>") {}

        public override void onCommand(string[] args) {

            if (args[1] == "file") {

                File.Create(args[2]);

            } else if (args[1] == "dir") {

                Directory.CreateDirectory(args[2]);

            } else {

                Utils.showError("Unknown argument: " + args[1]);

            }
            
        }
        
    }
}
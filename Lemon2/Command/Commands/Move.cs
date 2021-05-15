using System;
using System.IO;

using Lemon2.Command;

namespace Lemon2.Command.Commands {

    public class Move : CommandBase {

        public Move() : base("move", "Moves file / dir", "move <path> <new path>") {}

        public override void onCommand(string[] args) {

            if (Utils.isFile(args[1])) {

                File.Move(args[1], args[2]);

            } else {

                Directory.Move(args[1], args[2]);

            }

        }
        
    }
}
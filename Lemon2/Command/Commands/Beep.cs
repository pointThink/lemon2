using System;

namespace Lemon2.Command.Commands {

    public class Beep : CommandBase {

        public Beep() : base("beep", "beep boop", "beep") {}

        public override void onCommand(string[] args)
        {
            Console.Beep();
        }

    }

}
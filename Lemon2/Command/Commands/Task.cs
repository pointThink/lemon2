using System;
using System.IO;
using System.Diagnostics;

using Lemon2.Command;

namespace Lemon2.Command.Commands {

    public class Task : CommandBase {

        public Task() : base("task", "Performs operation on task", "task <list/kill>") {}

        public override void onCommand(string[] args) {

            if (args[1] == "list") {

                foreach (Process p in Process.GetProcesses()) {

                    Console.WriteLine(p.ProcessName + "|" + p.Id);

                }

            } else if (args[1] == "kill") {

                Process.GetProcessesByName(args[2])[0].Kill();

            }

        }
        
    }
}
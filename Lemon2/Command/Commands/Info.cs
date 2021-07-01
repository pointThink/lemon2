using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Lemon2.Command.Commands {

    public class Info : CommandBase {

        public Info() : base("info", "show information about item", "info <type>") {}

        public override void onCommand(string[] args) {

            if (args[1] == "file") {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Creation time: ");
                Console.ResetColor();
                Console.WriteLine(File.GetCreationTime(args[2]));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Last write: ");
                Console.ResetColor();
                Console.WriteLine(File.GetLastWriteTime(args[2]));

            } else if (args[1] == "time") {

                DateTime now = DateTime.Now; 
                showInfo("The current time is", now.ToString());

            } else if (args[1] == "cmd") {

                foreach (CommandBase c in Lemon2.Program.Cmds) {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(c.name + ": ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(c.desc + " | " + c.syntax);

                    Console.ResetColor();

                }

            } else if (args[1] == "net") {

                showInfo("Host name", Environment.GetEnvironmentVariable("COMPUTERNAME"));
                showInfo("IP Address", getIp());

            }
            
        }

        private void showInfo(string i, string i2) {

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(i + ":");
            Console.ResetColor();
            Console.WriteLine(" " + i2);

        }

        private string getIp() {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "reeeeeee";

        }

    }
}
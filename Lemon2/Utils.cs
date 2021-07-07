using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Lemon2.Command;

namespace Lemon2 {

    public class Utils {

        public static string ReadFile(string path) {

            StreamReader f = new StreamReader(path);
            string s = f.ReadToEnd();
            f.Close();

            return s;

        }
        
        public static CommandBase getCommandByName(string name) {

            CommandBase retCmd = null;

            foreach (CommandBase c in Program.Cmds) {

                if (c.name.ToLower() == name.ToLower())
                    retCmd = c;

            }

            return retCmd;

        }

        public static string[] ParseArguments(string commandLine) {

            char[] parmChars = commandLine.ToCharArray();
            bool inQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"')
                    inQuote = !inQuote;
                if (!inQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }

            string str = new String(parmChars);
            return str.Replace("\"", "").Split('\n');

        }

        public static void showError(string e) {

            // beep boop
            Console.Beep();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Lemon: " + e);
            Console.ResetColor();

        } 

        public static string getFileNameFromPath(string path) {

            string[] split = path.Split('\\');
            return split[split.Length - 1];

        }

        public static void Delete(string path) {

            FileAttributes fAttribs = File.GetAttributes(path);

            // Checks if path is for dir or file
            if (fAttribs.HasFlag(FileAttributes.Directory)) {

                Directory.Delete(path);

            } else if (!fAttribs.HasFlag(FileAttributes.Directory)) {

                File.Delete(path);

            }
            
        }

        public static bool isFile(string path) {

            FileAttributes fAttrib = File.GetAttributes(path);
            bool rBool = true;

            if (fAttrib.HasFlag(FileAttributes.Directory)) {
                rBool = false;
            }

            return rBool;

        }

        public static void ValueWrite(ConsoleColor c1, string s1, string s2) {

            Console.ForegroundColor = c1;
            Console.Write(s1);

            Console.ResetColor();
            Console.WriteLine(s2);

        }

        public static string MultiLineInput() {

            Console.WriteLine("To end input write :done:");
            Console.WriteLine();
            
            bool done = false;
            List<String> ret = new List<string>();
            
            while (!done) {

                string input = Console.ReadLine();

                if (input == ":done:") {
                    done = true;
                    break;

                } else {
                    ret.Add(input);

                }

            }

            return String.Join("\n", ret.ToArray());

        }

    }
}
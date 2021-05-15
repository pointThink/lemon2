using System;
using System.IO;

using Lemon2.Command;

namespace Lemon2 {

    public class Utils {
        
        public static CommandBase getCommandByName(string name) {

            CommandBase retCmd = null;

            foreach (CommandBase c in Program.cmds) {

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
            return (new string(parmChars)).Replace("\"", "").Split('\n');

        }

        public static void showError(string e) {

            // beep boop
            Console.Beep();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e);
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

    }
}
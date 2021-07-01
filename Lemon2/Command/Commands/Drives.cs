using System;
using System.IO;

namespace Lemon2.Command.Commands {
    
    public class Drives : CommandBase {
        
        public Drives() : base("drive", "Prints available drives", "drives") {}

        public override void onCommand(string[] args) {

            DriveInfo[] drv = DriveInfo.GetDrives();

            foreach (var driveInfo in drv) {
                
                WriteDriveBlock(driveInfo);
                Console.WriteLine();
                
            }

        }

        private void WriteDriveBlock(DriveInfo d) {

            if (d.IsReady)
            {
                // Name block
                Utils.ValueWrite(ConsoleColor.Cyan, "Drive: ", d.Name + " " + d.VolumeLabel);
                Console.WriteLine();

                // General info block
                Utils.ValueWrite(ConsoleColor.Green, "Type: ", d.DriveType.ToString());
                Utils.ValueWrite(ConsoleColor.Green, "File system: ", d.DriveFormat);
                
                Console.WriteLine();

                // Space block
                Utils.ValueWrite(ConsoleColor.Yellow, "Size: ", (d.TotalSize / 1000000).ToString());
                Utils.ValueWrite(ConsoleColor.Yellow, "Free Space: ", (d.TotalFreeSpace / 1000000).ToString());

                Console.WriteLine();

            } else {
                Utils.showError(d.Name + " not ready");
                
            }
            
            

        }
        
    }
}
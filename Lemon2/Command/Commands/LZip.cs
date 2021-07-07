using System.IO.Compression;

namespace Lemon2.Command.Commands {
    
    public class LZip : CommandBase {

        public LZip() : base("lzip", "Zip Archive manager", "lzip <pack/unpack> <target> <extract/pack path>") {}


        public override void onCommand(string[] args) {

            if (args[1] == "pack") {
                ZipFile.CreateFromDirectory(args[2], args[3]);

            } else if (args[1] == "unpack") {
                ZipFile.ExtractToDirectory(args[2], args[3]);
                
            } else {
                Utils.showError("Command not recognized");
            }
            
        }
        
    }
}
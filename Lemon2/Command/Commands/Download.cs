using System.Net;

namespace Lemon2.Command.Commands {

    public class Download : CommandBase {
        
        public Download() : base("download", "Downloads a file from the Internet", "download <url> <path>") {}

        public override void onCommand(string[] args) {

            WebClient web = new WebClient();
            web.DownloadFile(args[1], args[2]);

        }
    }
    
}
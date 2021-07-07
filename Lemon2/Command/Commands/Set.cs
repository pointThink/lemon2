namespace Lemon2.Command.Commands {
    
    public class Set : CommandBase {

        public Set() : base("set", "set variable value", "set <name> <value>") {}

        public override void onCommand(string[] args) {
            
            Variables.Variables.Set(args[1], args[2]);
            
        }
    }
}
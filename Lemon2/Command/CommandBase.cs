using System;

namespace Lemon2.Command {

    public class CommandBase {

        public string name;
        public string desc;
        public string syntax;

        public CommandBase(string name, string desc, string syntax) {

            this.name = name;
            this.desc = desc;
            this.syntax = syntax;

        }

        public virtual void onCommand(string[] args) {}

    }

}
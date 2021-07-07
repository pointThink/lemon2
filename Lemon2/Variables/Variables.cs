using System;
using System.Collections.Generic;

namespace Lemon2.Variables {
    
    public class Variables {

        static Dictionary<String, String> Vars = new Dictionary<string, string>();

        public static string Replace(string text) {

            string ret = text;
            
            foreach (KeyValuePair<String, String> kp in Vars)
            {

                ret = ret.Replace("$[" + kp.Key + "]", kp.Value);

            }

            return ret;

        }

        // Set variable value
        public static void Set(string name, string value) {
            
            Vars.Add(name, value);
            
        }

    }
}
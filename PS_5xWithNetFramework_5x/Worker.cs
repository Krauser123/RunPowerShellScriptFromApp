using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PS_5x_WithNET_Framework
{
    internal class Worker
    {
        public bool KeepGoing { get; set; }
        
        private string ScriptContent = null;
        private readonly string ScriptLocation;

        public Worker(string scriptLocation)
        {
            ScriptLocation = scriptLocation;
            KeepGoing = true;
        }

        public void DoWork()
        {
            if (this.ScriptContent == null)
            {
                this.ScriptContent = GetScriptContent();
            }

            while (KeepGoing)
            {                
                Console.WriteLine(DateTime.Now + " - Running script...");

                //Launch process
                PShellLauncher psLauncher = new PShellLauncher();
                psLauncher.RunScript(this.ScriptContent, new Dictionary<string, object>());

                Console.WriteLine(DateTime.Now + " - End script...");
                Console.WriteLine("-------------------------------------------");

                //Sleep during one minute
                Thread.Sleep(60000);
            }
        }

        private string GetScriptContent()
        {
            string scriptContent = null;

            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(ScriptLocation))
                {
                    // Read the stream as a string
                    scriptContent = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Script file could not be read:");
                Console.WriteLine(e.Message);
            }

            return scriptContent;
        }
    }
}

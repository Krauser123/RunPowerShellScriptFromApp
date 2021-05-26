using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace PS_5x_WithNET_Framework
{
    internal class PShellLauncher
    {
        /// <summary>
        /// Runs a PowerShell script with parameters and prints the resulting pipeline objects to the console output. 
        /// </summary>
        /// <param name="scriptContents">The script file contents.</param>
        /// <param name="scriptParameters">A dictionary of parameter names and parameter values.</param>
        public bool RunScript(string scriptContents, Dictionary<string, object> scriptParameters)
        {
            // Create a new hosted PowerShell instance using the default runspace.            
            using (PowerShell ps = PowerShell.Create())
            {
                // Specify the script code to run.
                ps.AddScript(scriptContents);

                // Specify the parameters to pass into the script.
                ps.AddParameters(scriptParameters);

                // Execute the script and await the result.
                var pipelineObjects = ps.Invoke();

                // Print the resulting pipeline objects to the console.
                foreach (var item in pipelineObjects)
                {
                    Console.WriteLine(item.BaseObject.ToString());
                }
            }

            return true;
        }
    }
}

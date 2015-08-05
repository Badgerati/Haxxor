using Haxxor.Framework;
using Haxxor.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MConsole = System.Console;

namespace Haxxor.Console
{
    public static class ConsoleHelper
    {

        /// <summary>
        /// Writes the help text to the console.
        /// </summary>
        public static void WriteHelp()
        {
            MConsole.WriteLine(@"
Haxxor :: Help Manual
            

encrypt <module> <text>
    - Encrypts the passed text using the specified module
            
decrypt <module> <hash>
    - Decrypts the passed hash using the specified module

cycle <hash>
    - Cycles the hash through all possible decryptable modules
            
validate <module> <text> <hash>
    - Validates that the passed text matches the hash
            
list
    - Returns a list of all possible encryption modules
            
version
    - Returns the current version of Haxxor
            
help
    - Returns this help text
            
            
In all cases, the hash can optionally include the module tag.
                ");
        }

        /// <summary>
        /// Writes the module list to the console.
        /// </summary>
        public static void WriteModuleList()
        {
            var modules = Enum.GetNames(typeof(EncryptionType));

            MConsole.WriteLine("\nModules List\n");

            foreach(var module in modules)
            {
                MConsole.WriteLine("   " + module);
            }

            MConsole.WriteLine();
        }

        /// <summary>
        /// Writes the version to the console.
        /// </summary>
        public static void WriteVersion()
        {
            MConsole.WriteLine("Haxxor, " + HaxxorFactory.Version);
        }

        /// <summary>
        /// Checks the arguments length.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="length">The length.</param>
        /// <returns>
        /// Returns whether the arguments match the required length.
        /// </returns>
        public static bool CheckArgs(string[] args, int length)
        {
            if (args.Length != length)
            {
                WriteError("Incorrect number of arguments supplied. Use \"help\".");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Writes an error to the console.
        /// </summary>
        /// <param name="error">The error.</param>
        public static void WriteError(string error)
        {
            MConsole.WriteLine("\nError: " + error + "\n");
        }

        /// <summary>
        /// Writes the message to the console.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void WriteMessage(string message)
        {
            MConsole.WriteLine(message);
        }

        /// <summary>
        /// Gets the encryption module specified by the supplied argument.
        /// </summary>
        /// <param name="type">The module type.</param>
        /// <returns>
        /// Returns the encryption module interface.
        /// </returns>
        public static IEncryptionModule GetModule(string type)
        {
            var module = HaxxorFactory.GetByType(type);

            if (module == default(IEncryptionModule))
            {
                WriteError("Invalid module type supplied.");
            }

            return module;
        }

    }
}

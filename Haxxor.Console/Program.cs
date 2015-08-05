using Haxxor.Framework;
using Haxxor.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haxxor.Console
{
    class Program
    {

        /// <summary>
        /// The main method for the console application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            try
            {
                if (args == default(string[]) || args.Length < 1 || args.Length > 4)
                {
                    ConsoleHelper.WriteHelp();
                    return;
                }

                var method = args[0].ToLowerInvariant();

                switch (method)
                {
                    case "encrypt":
                        Encrypt(CheckAndGetModule(args, 3), args[2]);
                        break;

                    case "decrypt":
                        Decrypt(CheckAndGetModule(args, 3), args[2]);
                        break;

                    case "cycle":
                        Cycle(args);
                        break;

                    case "validate":
                        Validate(CheckAndGetModule(args, 4), args[2], args[3]);
                        break;

                    case "list":
                        ConsoleHelper.WriteModuleList();
                        break;

                    case "help":
                        ConsoleHelper.WriteHelp();
                        break;

                    case "version":
                        ConsoleHelper.WriteVersion();
                        break;

                    default:
                        ConsoleHelper.WriteError("Invalid argument supplied: " + method);
                        break;
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Encrypts the specified arguments.
        /// </summary>
        /// <param name="module">The module.</param>
        private static void Encrypt(IEncryptionModule module, string text)
        {
            if (module == default(IEncryptionModule))
            {
                return;
            }

            var hash = module.Encrypt(text);
            ConsoleHelper.WriteMessage(hash);
        }

        /// <summary>
        /// Decrypts the specified arguments.
        /// </summary>
        /// <param name="module">The module.</param>
        private static void Decrypt(IEncryptionModule module, string hash)
        {
            if (module == default(IEncryptionModule))
            {
                return;
            }

            if (module.IsDecryptable)
            {
                var text = module.Decrypt(hash);
                ConsoleHelper.WriteMessage(text);
            }
            else
            {
                ConsoleHelper.WriteMessage("Module does not support decrypting.");
            }
        }

        /// <summary>
        /// Cycles the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Cycle(string[] args)
        {
            if (!ConsoleHelper.CheckArgs(args, 2))
            {
                return;
            }

            var attempts = HaxxorFactory.Cycle(args[1]);

            if (attempts == default(IDictionary<EncryptionType, string>))
            {
                ConsoleHelper.WriteMessage("No decryptable modules found.");
                return;
            }

            ConsoleHelper.WriteMessage(string.Empty);

            foreach (var attempt in attempts)
            {
                ConsoleHelper.WriteMessage(attempt.Key + ":\t" + attempt.Value);
            }

            ConsoleHelper.WriteMessage(string.Empty);
        }

        /// <summary>
        /// Validates the specified arguments.
        /// </summary>
        /// <param name="module">The module.</param>
        private static void Validate(IEncryptionModule module, string text, string hash)
        {
            if (module == default(IEncryptionModule))
            {
                return;
            }

            var result = module.Validate(text, hash);
            ConsoleHelper.WriteMessage(result.ToString());
        }

        /// <summary>
        /// Checks the arguments and gets a module.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="length">The length.</param>
        /// <returns>Returns an encryption module.</returns>
        private static IEncryptionModule CheckAndGetModule(string[] args, int length)
        {
            if (!ConsoleHelper.CheckArgs(args, length))
            {
                return default(IEncryptionModule);
            }

            return ConsoleHelper.GetModule(args[1]);
        }

    }
}

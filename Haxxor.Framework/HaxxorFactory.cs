using Haxxor.Framework.Core;
using Haxxor.Framework.Core.Exceptions;
using Haxxor.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haxxor.Framework
{
    public static class HaxxorFactory
    {

        /// <summary>
        /// Gets the version of Haxxor.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public static string Version
        {
            get { return "v0.9.0"; }
        }


        #region Modules

        /// <summary>
        /// List of all possible encryption modules.
        /// </summary>
        private static IDictionary<EncryptionType, IEncryptionModule> Modules = new Dictionary<EncryptionType, IEncryptionModule>()
        {
            { EncryptionType.NotSet, new EncryptionModule() },
            { EncryptionType.SHA1, new SHA1EncryptionModule() },
            { EncryptionType.SHA256, new SHA256EncryptionModule() },
            { EncryptionType.SHA384, new SHA384EncryptionModule() },
            { EncryptionType.SHA512, new SHA512EncryptionModule() },
            { EncryptionType.AES128, new AES128EncryptionModule() },
            { EncryptionType.AES256, new AES256EncryptionModule() },
        };

        #endregion


        /// <summary>
        /// Returns an encryption module, specified by the type passed.
        /// </summary>
        /// <param name="type">The encryption type.</param>
        /// <returns>
        /// Returns an encryption module
        /// </returns>
        public static IEncryptionModule GetByType(EncryptionType type)
        {
            return Modules.ContainsKey(type)
                ? Modules[type]
                : default(IEncryptionModule);
        }

        /// <summary>
        /// Returns an encryption module, specified by the type passed.
        /// </summary>
        /// <param name="type">The encryption type.</param>
        /// <returns>
        /// Returns an encryption module
        /// </returns>
        /// <exception cref="Haxxor.Framework.Core.Exceptions.HaxxorException">No encryption type passed, cannot be null or empty.</exception>
        public static IEncryptionModule GetByType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new HaxxorException("No encryption type passed, cannot be null or empty.");
            }

            var _type = default(EncryptionType);

            if (!Enum.TryParse<EncryptionType>(type, true, out _type))
            {
                return default(IEncryptionModule);
            }

            return GetByType(_type);
        }

        /// <summary>
        /// Returns an encryption module, specified by the hash passed.
        /// This module is determined by the "TAG;" before the hash.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns an encryption module
        /// </returns>
        /// <exception cref="Haxxor.Framework.Core.Exceptions.HaxxorException">
        /// No hash passed, cannot be null or empty.
        /// or
        /// Hash does not contain a module tag.
        /// </exception>
        public static IEncryptionModule GetByHash(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                throw new HaxxorException("No hash passed, cannot be null or empty.");
            }

            if (!hash.Contains(';'))
            {
                throw new HaxxorException("Hash does not contain a module tag.");
            }

            foreach (var module in Modules)
            {
                if (module.Value.CheckTag(hash))
                {
                    return module.Value;
                }
            }

            return Modules[EncryptionType.NotSet];
        }

        /// <summary>
        /// Cycles the specified hash, attempting to decrypt it using all decryptable modules.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns a list of decrypted values. If the value for the module is blank, it failed decrpytion.
        /// </returns>
        /// <exception cref="Haxxor.Framework.Core.Exceptions.HaxxorException">No hash passed, cannot be null or empty.</exception>
        public static IDictionary<EncryptionType, string> Cycle(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                throw new HaxxorException("No hash passed, cannot be null or empty.");
            }

            var attempts = new Dictionary<EncryptionType, string>();

            foreach (var module in Modules)
            {
                if (module.Value.IsDecryptable)
                {
                    var text = string.Empty;

                    try
                    {
                        text = module.Value.Decrypt(hash);
                    }
                    catch { }

                    attempts.Add(module.Key, text);
                }
            }

            return attempts;
        }


    }
}

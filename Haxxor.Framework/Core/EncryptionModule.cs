using Haxxor.Framework.Core.Exceptions;
using Haxxor.Framework.Core.Helpers;
using Haxxor.Framework.Core.Interfaces;
using System;
using System.Linq;

namespace Haxxor.Framework.Core
{
    public class EncryptionModule : IEncryptionModule
    {

        /// <summary>
        /// Gets the tag for the encryption module.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag
        {
            get { return EncryptionType.ToString(); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is decryptable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is decryptable; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsDecryptable
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the type of the encryption.
        /// </summary>
        /// <value>
        /// The type of the encryption.
        /// </value>
        public virtual EncryptionType EncryptionType
        {
            get { return EncryptionType.NotSet; }
        }


        /// <summary>
        /// Encrypts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="includeTag">if set to <c>true</c> include the module Tag.</param>
        /// <returns>
        /// The encrypted hash.
        /// </returns>
        /// <exception cref="Haxxor.Framework.Core.Exceptions.HaxxorException">Value cannot be null when encrypting.</exception>
        public virtual string Encrypt(string value, bool includeTag = true)
        {
            if (value == null)
            {
                throw new HaxxorException("Value cannot be null when encrypting.");
            }

            return string.Empty;
        }

        /// <summary>
        /// Decrypts the specified hash.
        /// </summary>
        /// <param name="hash">The hash value with an optional module tag.</param>
        /// <returns>
        /// The decrypted value.
        /// </returns>
        /// <exception cref="Haxxor.Framework.Core.Exceptions.HaxxorException">Hash cannot be null when decrypting.</exception>
        public virtual string Decrypt(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                throw new HaxxorException("Hash cannot be null or empty when decrypting.");
            }

            return string.Empty;
        }

        /// <summary>
        /// Checks to see if the value passed matches the formatted hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="hash">The hash value with an optional module tag.</param>
        /// <returns>
        /// Whether the value equals the passed hash.
        /// </returns>
        /// <exception cref="Haxxor.Framework.Core.Exceptions.HaxxorException">
        /// Value cannot be null when validating.
        /// or
        /// Hash cannot be null when validating.
        /// </exception>
        public virtual bool Validate(string value, string hash)
        {
            if (value == null)
            {
                throw new HaxxorException("Value cannot be null when validating.");
            }

            if (hash == null)
            {
                throw new HaxxorException("Hash cannot be null when validating.");
            }

            return false;
        }

        /// <summary>
        /// Checks the tag, to see if the formatted hash passed was encrypted by the module.
        /// </summary>
        /// <param name="hash">The hash value with a mandatory module tag.</param>
        /// <returns>
        /// Whether the hash was created via this module.
        /// </returns>
        /// <exception cref="Haxxor.Framework.Core.Exceptions.HaxxorException">
        /// No hash passed, cannot be null or empty.
        /// or
        /// Hash does not contain a module tag.
        /// </exception>
        public virtual bool CheckTag(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                throw new HaxxorException("No hash passed, cannot be null or empty.");
            }

            if (!hash.Contains(';'))
            {
                throw new HaxxorException("Hash does not contain a module tag.");
            }

            var _tag = CryptoHelper.GetTag(hash);
            return _tag.Equals(Tag, StringComparison.InvariantCultureIgnoreCase);
        }

    }
}

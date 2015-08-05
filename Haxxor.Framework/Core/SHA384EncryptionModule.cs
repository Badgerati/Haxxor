using Haxxor.Framework.Core.Exceptions;
using Haxxor.Framework.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Haxxor.Framework.Core
{
    public class SHA384EncryptionModule : EncryptionModule
    {

        /// <summary>
        /// Gets the type of the encryption.
        /// </summary>
        /// <value>
        /// The type of the encryption.
        /// </value>
        public override EncryptionType EncryptionType
        {
            get
            {
                return EncryptionType.SHA384;
            }
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
        public override string Encrypt(string value, bool includeTag = true)
        {
            if (value == null)
            {
                throw new HaxxorException("Value cannot be null when encrypting.");
            }

            var bytes = CryptoHelper.GetBytes(value);

            using (var sha = new SHA384Managed())
            {
                var hash = sha.ComputeHash(bytes);
                var hash64 = Convert.ToBase64String(hash);

                return includeTag
                    ? CryptoHelper.FormatTagHash(Tag, hash64)
                    : hash64;
            }
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
        public override bool Validate(string value, string hash)
        {
            if (value == null)
            {
                throw new HaxxorException("Value cannot be null when validating.");
            }

            if (hash == null)
            {
                throw new HaxxorException("Hash cannot be null when validating.");
            }

            var newHash = Encrypt(value, false);
            var taglessHash = CryptoHelper.GetFullHash(hash);
            return newHash.CompareTo(taglessHash) == 0;
        }

    }
}

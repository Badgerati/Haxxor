using Haxxor.Framework.Core.Exceptions;
using Haxxor.Framework.Core.Helpers;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Haxxor.Framework.Core
{
    public class AES128EncryptionModule : EncryptionModule
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
                return EncryptionType.AES128;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is decryptable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is decryptable; otherwise, <c>false</c>.
        /// </value>
        public override bool IsDecryptable
        {
            get
            {
                return true;
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

            var bytes = default(byte[]);

            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.GenerateKey();
                aes.GenerateIV();

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var stream = new MemoryStream())
                {
                    using (var crypto = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(crypto))
                        {
                            writer.Write(value);
                        }

                        bytes = stream.ToArray();
                    }
                }

                var hash64 = Convert.ToBase64String(bytes);
                var key64 = Convert.ToBase64String(aes.Key);
                var iv64 = Convert.ToBase64String(aes.IV);

                var hash = CryptoHelper.FormatKeyHash(key64, iv64, hash64);

                return includeTag
                    ? CryptoHelper.FormatTagHash(Tag, hash)
                    : hash;
            }
        }

        /// <summary>
        /// Decrypts the specified hash.
        /// </summary>
        /// <param name="hash">The hash value with an optional module tag.</param>
        /// <returns>
        /// The decrypted value.
        /// </returns>
        /// <exception cref="Haxxor.Framework.Core.Exceptions.HaxxorException">Hash cannot be null when decrypting.</exception>
        public override string Decrypt(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                throw new HaxxorException("Hash cannot be null or empty when decrypting.");
            }

            var tagless = CryptoHelper.GetFullHash(hash);
            var text = string.Empty;

            var bytes = CryptoHelper.GetHash(tagless);
            var key = CryptoHelper.GetKey(tagless);
            var iv = CryptoHelper.GetIV(tagless);

            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Key = key;
                aes.IV = iv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var stream = new MemoryStream(bytes))
                {
                    using (var crypto = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(crypto))
                        {
                            text = reader.ReadToEnd();
                        }
                    }
                }
            }

            return text;
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

            var decrypted = Decrypt(hash);
            return value.CompareTo(decrypted) == 0;
        }

    }
}

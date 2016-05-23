using System;
using System.Text;

namespace Haxxor.Framework.Core.Helpers
{
    public static class CryptoHelper
    {

        public const char TAG_SEPARATOR = '|';
        public const char SEPARATOR = ';';


        /// <summary>
        /// Formats the hash so that we have "TAG|HASH".
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns a formatted hash.
        /// </returns>
        public static string FormatTagHash(string tag, string hash)
        {
            return string.Format("{0}{1}{2}", tag, TAG_SEPARATOR, hash);
        }

        /// <summary>
        /// Formats the hash, so that we have "KEY;IV;HASH".
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="iv">The iv.</param>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns a formatted hash.
        /// </returns>
        public static string FormatKeyHash(string key, string iv, string hash)
        {
            return string.Format("{0}{3}{1}{3}{2}", key, iv, hash, SEPARATOR);
        }

        /// <summary>
        /// Gets the tag from the full formatted hash.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns the module tag part of the hash.
        /// </returns>
        public static string GetTag(string hash)
        {
            var index = hash.IndexOf(TAG_SEPARATOR);

            return index == -1
                ? string.Empty
                : hash.Substring(0, index);
        }

        /// <summary>
        /// Gets the hash from the full formatted hash.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns the full hash, without the module tag.
        /// </returns>
        public static string GetFullHash(string hash)
        {
            var index = hash.IndexOf(TAG_SEPARATOR);

            return index == -1
                ? hash
                : hash.Substring(index + 1);
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns the key fromt the hash.
        /// </returns>
        public static byte[] GetKey(string hash)
        {
            var blocks = hash.Split(SEPARATOR);

            return blocks.Length < 3
                ? default(byte[])
                : Convert.FromBase64String(blocks[blocks.Length - 3]);
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns the main hash from the hash.
        /// </returns>
        public static byte[] GetHash(string hash)
        {
            var blocks = hash.Split(SEPARATOR);

            return blocks.Length < 1
                ? default(byte[])
                : Convert.FromBase64String(blocks[blocks.Length - 1]);
        }

        /// <summary>
        /// Gets the iv.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns>
        /// Returns the IV value from the hash.
        /// </returns>
        public static byte[] GetIV(string hash)
        {
            var blocks = hash.Split(SEPARATOR);

            return blocks.Length < 2
                ? default(byte[])
                : Convert.FromBase64String(blocks[blocks.Length - 2]);
        }

        /// <summary>
        /// Returns the bytes using UTF8 encoding.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Returns the UTF8 byte encoding of the passed value.
        /// </returns>
        public static byte[] GetBytes(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

    }
}

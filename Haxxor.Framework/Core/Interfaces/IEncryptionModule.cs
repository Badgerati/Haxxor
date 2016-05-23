
namespace Haxxor.Framework.Core.Interfaces
{
    public interface IEncryptionModule
    {

        /// <summary>
        /// Gets the tag for the encryption module.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        string Tag { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is decryptable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is decryptable; otherwise, <c>false</c>.
        /// </value>
        bool IsDecryptable { get; }

        /// <summary>
        /// Gets the type of the encryption.
        /// </summary>
        /// <value>
        /// The type of the encryption.
        /// </value>
        EncryptionType EncryptionType { get; }


        /// <summary>
        /// Encrypts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="includeTag">if set to <c>true</c> include the module Tag.</param>
        /// <returns>
        /// The encrypted hash.
        /// </returns>
        string Encrypt(string value, bool includeTag = true);

        /// <summary>
        /// Decrypts the specified hash.
        /// </summary>
        /// <param name="hash">The hash value with an optional module tag.</param>
        /// <returns>
        /// The decrypted value.
        /// </returns>
        string Decrypt(string hash);

        /// <summary>
        /// Checks to see if the value passed matches the formatted hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="hash">The hash value with an optional module tag.</param>
        /// <returns>
        /// Whether the value equals the passed hash.
        /// </returns>
        bool Validate(string value, string hash);

        /// <summary>
        /// Checks the tag, to see if the formatted hash passed was encrypted by the module.
        /// </summary>
        /// <param name="hash">The hash value with a mandatory module tag.</param>
        /// <returns>
        /// Whether the hash was created via this module.
        /// </returns>
        bool CheckTag(string hash);

    }
}

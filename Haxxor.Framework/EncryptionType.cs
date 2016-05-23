
namespace Haxxor.Framework
{

    /// <summary>
    /// List of all possible Encryption Modules which Haxxor can use.
    /// </summary>
    public enum EncryptionType : int
    {
        NotSet = 0,
        SHA1 = 1,
        SHA256 = 2,
        SHA384 = 3,
        SHA512 = 4,
        AES128 = 5,
        AES256 = 6,
        MD5 = 7,
        RIPEMD160 = 8
    }

}

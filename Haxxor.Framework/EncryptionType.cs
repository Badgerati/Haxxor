using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        AES256 = 6
    }

}

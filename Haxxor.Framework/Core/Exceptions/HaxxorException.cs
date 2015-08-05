using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haxxor.Framework.Core.Exceptions
{
    public class HaxxorException : Exception
    {

        /// <summary>
        /// Gets the type of the encryption.
        /// </summary>
        /// <value>
        /// The type of the encryption.
        /// </value>
        public EncryptionType? EncryptionType
        {
            get;
            private set;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="HaxxorException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public HaxxorException(string message, EncryptionType? type = null)
            : base(message)
        {
            EncryptionType = type;
        }

    }
}

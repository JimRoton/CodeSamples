using Struct.Core.Extensions;

using System;
using System.Text;

namespace Encryption_Sample
{
    public static class Extensions
    {
        /// <summary>
        /// This extension is used to insure that
        /// the key being used is at least one
        /// character and converts it by duplicating
        /// the characters until it's the required
        /// length. This allows the developer to provide
        /// a string of any length and still use it for
        /// encrypting/decrypting.
        /// </summary>
        /// <param name="Value">The Key Value</param>
        /// <param name="KeyLength">The Length Needed</param>
        /// <returns>Converted Key of Required Length</returns>
        public static byte[] ConvertToCryptoKey(this string Target, int KeyLength)
        {
            if (Target.IsNullEmptyOrWhiteSpace())
                throw new ArgumentNullException("Target");
            else if (KeyLength < 1)
                throw new Exception("KeyLength parameter must be greater than zero.");

            // just duplicate the Value until
            // we get to the required length
            while (Target.Length < KeyLength)
                Target += Target;

            // return the required characters
            return Encoding.UTF8.GetBytes(Target.Substring(0, KeyLength));
        }
    }
}

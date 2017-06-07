using System;
using System.Security.Cryptography;
using System.Text;

namespace VivialConnect.Crypto
{
    /// <summary>
    /// Methods used to encode and hash text.
    /// </summary>
    internal class Hash
    {
        /// <summary>
        /// The SHA hash.
        /// </summary>
        /// <param name="text">Text to hash.</param>
        /// <returns></returns>
        internal static string GetHashShaHex(string text)
        {
            byte[] encodedText = StringEncode(text);

            using (var sha256 = new SHA256Managed())
            {
                byte[] hash = sha256.ComputeHash(encodedText);
                return HashEncode(hash);
            }                
        }

        /// <summary>
        /// The HMAC hash.
        /// </summary>
        /// <param name="key">Key used for hash.</param>
        /// <param name="text">Text to hash.</param>
        /// <returns></returns>
        internal static string GetHashHmacHex(string key, string text)
        {
            byte[] encodedKey = StringEncode(key);
            byte[] encodedText = StringEncode(text);

            using (var hmacSHA = new HMACSHA256(encodedKey))
            {
                byte[] hash = hmacSHA.ComputeHash(encodedText);
                return HashEncode(hash);
            }
        }

        /// <summary>
        /// Encodes string to UTF-8 byte array.
        /// </summary>
        /// <param name="text">Text to encode.</param>
        /// <returns></returns>
        internal static byte[] StringEncode(string text)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(text);
        }

        /// <summary>
        /// Encodes byte array to UTF-8 string.
        /// </summary>
        /// <param name="encodedText">Byte array to encode.</param>
        /// <returns></returns>
        internal static string EncodeToString(byte[] encodedText)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(encodedText);
        }

        /// <summary>
        /// Encodes string to UTF-8 string.
        /// </summary>
        /// <param name="text">Text to encode.</param>
        /// <returns></returns>
        internal static string EncodeString(string text)
        {
            return EncodeToString(StringEncode(text));
        }

        /// <summary>
        /// Encodes a hashed byte array.
        /// </summary>
        /// <param name="hash">Hashed byte array to encode.</param>
        /// <returns></returns>
        internal static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}

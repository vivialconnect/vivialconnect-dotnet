using System;

namespace VivialConnect.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Retrieves the JSON attribute, if any.
        /// </summary>
        /// <param name="value">Enumeration.</param>
        /// <returns></returns>
        public static string JsonAttribute(this Enum value )
        {
            return Utils.GetEnumAttributeValue(value);
        }
    }
}

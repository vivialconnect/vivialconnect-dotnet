using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace VivialConnect
{
    /// <summary>
    /// Utilities class.
    /// </summary>
    internal class Utils
    {
        public const string Iso8601DateFormat = "yyyyMMddTHHmmssZ";

        /// <summary>
        /// Parses the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">String name value.</param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
        }

        /// <summary>
        /// The client library version.
        /// </summary>
        /// <returns></returns>
        internal static string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            return versionInfo.FileVersion;
        }        

        /// <summary>
        /// Formats the log timestamp.
        /// </summary>
        /// <param name="timestamp">Timestamp.</param>
        /// <returns></returns>
        internal static string FormatLogTimestamp(DateTime timestamp)
        {
            if(timestamp == null)
            {
                return null;
            }

            return timestamp.ToUniversalTime().ToString(Iso8601DateFormat);
        }

        /// <summary>
        /// The PropertyInfo attribute name if provided otherwise 
        /// defaults to the name.
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo.</param>
        /// <returns></returns>
        internal static string GetPropertyName(PropertyInfo propertyInfo)
        {
            string attributeValue = GetPropertyAttributeValue(propertyInfo);

            return attributeValue != null ? attributeValue : propertyInfo.Name;
        }

        /// <summary>
        /// The PropertyInfo attribute value if provided 
        /// otherwise defaults to the value.
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo.</param>
        /// <returns></returns>
        internal static string GetPropertyAttributeValue(PropertyInfo propertyInfo)
        {
            JsonPropertyAttribute jsonAttribute = propertyInfo.GetCustomAttributes(typeof(JsonPropertyAttribute), true).FirstOrDefault() as JsonPropertyAttribute;

            if (jsonAttribute == null)
            {
                return null;
            }

            return jsonAttribute.PropertyName;
        }

        /// <summary>
        /// The Value from the PropertyInfo. If it's an enum it attempts 
        /// to use the attribute value if provided.
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo.</param>
        /// <returns></returns>
        internal static string GetPropertyValue(PropertyInfo propertyInfo, Object target)
        {
            object propValue = propertyInfo.GetValue(target);
            if (propValue == null)
            {
                return null;
            }

            if (!propertyInfo.PropertyType.IsEnum)
            {
                return propValue.ToString();
            }

            Enum enumEntity = (Enum)Enum.ToObject(propertyInfo.PropertyType, propValue);

            return GetEnumAttributeValue(enumEntity);
        }

        /// <summary>
        /// The enum attribute value.
        /// </summary>
        /// <param name="enumEntity">Enum entity.</param>
        /// <returns></returns>
        internal static string GetEnumAttributeValue(Enum enumEntity)
        {
            FieldInfo fieldInfo = enumEntity.GetType().GetField(enumEntity.ToString());
            EnumMemberAttribute attribute = fieldInfo.GetCustomAttributes(typeof(EnumMemberAttribute), true).FirstOrDefault() as EnumMemberAttribute;

            return attribute != null ? attribute.Value : enumEntity.ToString();
        }
    }
}

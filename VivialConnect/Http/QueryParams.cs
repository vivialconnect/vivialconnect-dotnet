using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace VivialConnect.Http
{
    /// <summary>
    /// Base class used to represent the Query Parameters submitted to the API.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.IQueryParams" />
    public abstract class QueryParams : IQueryParams
    {
        /// <summary>
        /// The class properties as a list of key/value pairs.
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> GetAsList()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            PropertyInfo[] props = this.GetType().GetProperties();

            foreach(PropertyInfo prop in props)
            {
                string propValue = Utils.GetPropertyValue(prop, this);
                if(propValue == null)
                {
                    continue;
                }

                list.Add(new KeyValuePair<string, string>(Utils.GetPropertyName(prop), propValue));
            }

            return list;
        }
    }
}

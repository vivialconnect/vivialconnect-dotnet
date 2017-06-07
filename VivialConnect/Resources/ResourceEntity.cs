using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivialConnect.Resources
{
    public class ResourceEntity : Resource, IResourceEntity
    {
        /// <summary>
        /// Indicates if the entity is new.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsNew
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

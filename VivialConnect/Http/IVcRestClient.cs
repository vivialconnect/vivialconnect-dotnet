using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivialConnect.Http
{
    public interface IVcRestClient
    {
        /// <summary>
        /// Process request.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns></returns>
        Response Request(Request request);       
    }
}

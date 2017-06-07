using Newtonsoft.Json;
using VivialConnect.Http;

namespace VivialConnect.Resources.User
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting update password requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Http.Body" />
    public class UpdatePassword : Body
    {
        /// <summary>
        /// The old password.
        /// </summary>
        /// <value>
        /// Old password.
        /// </value>
        [JsonProperty("_password")]
        public string OldPassword { get; set; }

        /// <summary>
        /// The new password.
        /// </summary>
        /// <value>
        /// New password.
        /// </value>
        [JsonProperty("password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// The name to be used as the root node when serializing to JSON.
        /// </summary>
        /// <value>
        /// Root name.
        /// </value>
        public override string RootName
        {            
            get
            {
                return "user";
            }
        }
    }
}

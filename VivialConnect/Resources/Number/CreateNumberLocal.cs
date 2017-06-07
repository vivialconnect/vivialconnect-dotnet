using Newtonsoft.Json;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Class used to hold properties that will be sent as the body
    /// when submitting create local phone number requests.
    /// </summary>
    /// <seealso cref="VivialConnect.Resources.Number.CreateNumber" />
    public class CreateNumberLocal : CreateNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNumberLocal"/> class.
        /// </summary>
        /// <param name="phoneNumber">Phone number.</param>
        public CreateNumberLocal(string phoneNumber) : base(phoneNumber, PhoneNumberTypeEnum.Local) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNumberLocal"/> class.
        /// </summary>
        /// <param name="areaCode">Area code.</param>
        public CreateNumberLocal(int areaCode) : base(areaCode, PhoneNumberTypeEnum.Local) { }

        /// <summary>
        /// The type of phone number.
        /// </summary>
        /// <value>
        /// Type of phone number.
        /// </value>
        [JsonIgnore]
        public override PhoneNumberTypeEnum PhoneNumberType
        {
            get { return base.PhoneNumberType; }
            set { return; }
        }
    }
}

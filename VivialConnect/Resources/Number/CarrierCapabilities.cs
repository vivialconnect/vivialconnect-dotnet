using Newtonsoft.Json;

namespace VivialConnect.Resources.Number
{
    /// <summary>
    /// Class used to store carrier capabilities flags.
    /// </summary>
    public class CarrierCapabilities
    {
        [JsonProperty("deactivation_files")]
        public bool DeactivationFiles { get; private set; }

        [JsonProperty("device_lookup_api")]
        public bool DeviceLookupApi { get; private set; }

        [JsonProperty("location_data")]
        public bool LocationData { get; private set; }

        [JsonProperty("mms_connection_status")]
        public bool MmsConnectionStatus { get; private set; }

        [JsonProperty("mms_dr")]
        public bool MmsDr { get; private set; }

        [JsonProperty("sms_connection_status")]
        public bool SmsConnectionStatus { get; private set; }

        [JsonProperty("sms_fteu")]
        public bool SmsFteu { get; private set; }

        [JsonProperty("sms_handset_dr")]
        public bool SmsHandsetDr { get; private set; }

        [JsonProperty("uaprof_in_mms_dr")]
        public bool UaprofInMmsDr { get; private set; }
    }
}

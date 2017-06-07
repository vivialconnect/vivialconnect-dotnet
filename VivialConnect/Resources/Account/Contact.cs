using System;

using Newtonsoft.Json;

namespace VivialConnect.Resources.Account
{
    /// <summary>
    /// Account contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// The contact ID.
        /// </summary>
        /// <value>
        /// Contact ID.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// The account ID.
        /// </summary>
        /// <value>
        /// Account ID.
        /// </value>
        [JsonProperty("account_id")]
        public int AccountId { get; private set; }

        /// <summary>
        /// Value indicating whether this <see cref="Contact"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("active")]
        public bool Active { get; private set; }

        /// <summary>
        /// Address1.
        /// </summary>
        /// <value>
        /// Address1.
        /// </value>
        [JsonProperty("address1")]
        public string Address1 { get; private set; }

        /// <summary>
        /// Address2.
        /// </summary>
        /// <value>
        /// Address2.
        /// </value>
        [JsonProperty("address2")]
        public string Address2 { get; private set; }

        /// <summary>
        /// Address3.
        /// </summary>
        /// <value>
        /// Address3.
        /// </value>
        [JsonProperty("address3")]
        public string Address3 { get; private set; }

        /// <summary>
        /// The city.
        /// </summary>
        /// <value>
        /// City.
        /// </value>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>
        /// The name of the company.
        /// </summary>
        /// <value>
        /// Name of the company.
        /// </value>
        [JsonProperty("company_name")]
        public string CompanyName { get; private set; }

        /// <summary>
        /// The type of contact.
        /// </summary>
        /// <value>
        /// Type of contact.
        /// </value>
        [JsonProperty("contact_type")]
        public string ContactType { get; private set; }

        /// <summary>
        /// The country.
        /// </summary>
        /// <value>
        /// Country.
        /// </value>
        [JsonProperty("country")]
        public string Country { get; private set; }

        /// <summary>
        /// The date created.
        /// </summary>
        /// <value>
        /// Date created.
        /// </value>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// The date modified.
        /// </summary>
        /// <value>
        /// Date modified.
        /// </value>
        [JsonProperty("date_modified")]
        public DateTime DateModified { get; private set; }

        /// <summary>
        /// The email.
        /// </summary>
        /// <value>
        /// Email.
        /// </value>
        [JsonProperty("email")]
        public string Email { get; private set; }

        /// <summary>
        /// The fax.
        /// </summary>
        /// <value>
        /// Fax.
        /// </value>
        [JsonProperty("fax")]
        public string Fax { get; private set; }

        /// <summary>
        /// The first name.
        /// </summary>
        /// <value>
        /// First name.
        /// </value>
        [JsonProperty("first_name")]
        public string FirstName { get; private set; }

        /// <summary>
        /// The last name.
        /// </summary>
        /// <value>
        /// Last name.
        /// </value>
        [JsonProperty("last_name")]
        public string LastName { get; private set; }

        /// <summary>
        /// The mobile phone.
        /// </summary>
        /// <value>
        /// Mobile phone.
        /// </value>
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; private set; }

        /// <summary>
        /// The postal code.
        /// </summary>
        /// <value>
        /// Postal code.
        /// </value>
        [JsonProperty("postal_code")]
        public string PostalCode { get; private set; }

        /// <summary>
        /// The state.
        /// </summary>
        /// <value>
        /// State.
        /// </value>
        [JsonProperty("state")]
        public string State { get; private set; }

        /// <summary>
        /// The title.
        /// </summary>
        /// <value>
        /// Title.
        /// </value>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// The work phone.
        /// </summary>
        /// <value>
        /// Work phone.
        /// </value>
        [JsonProperty("work_phone")]
        public string WorkPhone { get; private set; }
    }
}

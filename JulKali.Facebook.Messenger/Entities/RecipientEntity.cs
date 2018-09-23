using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class RecipientEntity
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Psid { get; set; }

        [JsonProperty("user_ref", NullValueHandling = NullValueHandling.Ignore)]
        public string UserReference { get; set; }

        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public RecipientNameEntity Name { get; set; }
    }

    internal class RecipientNameEntity
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}
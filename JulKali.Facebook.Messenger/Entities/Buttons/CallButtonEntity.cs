namespace JulKali.Facebook.Entities
{
    public class CallButtonEntity
    {
        public string Type { get; } = "phone_number";

        public string Title { get; set; }

        public string PhoneNumber { get; set; }
    }
}
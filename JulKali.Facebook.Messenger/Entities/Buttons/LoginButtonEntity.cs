namespace JulKali.Facebook.Entities
{
    internal class LoginButtonEntity : IButtonEntity
    {
        public string Type { get; } = "account_link";

        public string CallbackUrl { get; set; }
    }
}
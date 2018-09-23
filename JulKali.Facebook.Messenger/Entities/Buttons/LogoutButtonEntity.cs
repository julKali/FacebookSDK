namespace JulKali.Facebook.Entities
{
    internal class LogoutButtonEntity : IButtonEntity
    {
        public string Type { get; } = "account_unlink";
    }
}
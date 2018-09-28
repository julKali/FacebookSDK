using JulKali.Facebook.Entities;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a Logout button that can be used inside a message template.
    /// </summary>
    public class LogoutButton : Button
    {
        /// <summary>
        /// Initializes a new <see cref="LogoutButton"/> object.
        /// </summary>
        public LogoutButton()
        {
        }

        /// <inheritdoc />
        internal override IButtonEntity ToEntity()
        {
            return new LogoutButtonEntity();
        }
    }
}
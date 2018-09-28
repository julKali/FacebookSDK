using JulKali.Facebook.Entities;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a button that can be used inside a message template.
    /// </summary>
    public abstract class Button
    {
        /// <summary>
        /// Returns the button as an <see cref="IButtonEntity"/> object.
        /// </summary>
        /// <returns></returns>
        internal abstract IButtonEntity ToEntity();
    }
}
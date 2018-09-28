using JulKali.Facebook.Entities;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents an identifier for media contained inside a media template.
    /// </summary>
    public abstract class MediaIdentifier
    {
        /// <summary>
        /// Adds any identfier related values to the payload.
        /// </summary>
        /// <param name="payload"></param>
        internal abstract void AddValuesToPayloadEntity(MediaPayloadEntity payload);
    }
}
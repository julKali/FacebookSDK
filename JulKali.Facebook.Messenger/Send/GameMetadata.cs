using JulKali.Facebook.Entities;

namespace JulKali.Facebook.Messenger.Send
{
    public abstract class GameMetadata
    {
        /// <summary>
        /// Returns the metadata as an <see cref="IGameMetadataEntity"/> object.
        /// </summary>
        /// <returns></returns>
        internal abstract IGameMetadataEntity ToEntity();
    }
}
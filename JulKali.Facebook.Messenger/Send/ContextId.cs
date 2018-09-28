using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents the context ID of the Instant Game THREAD.
    /// </summary>
    public class ContextId : GameMetadata
    {
        private readonly string _contextId;

        /// <summary>
        /// Initializes a new <see cref="ContextId"/> object.
        /// </summary>
        /// <param name="id">The context ID.</param>
        public ContextId(string id)
        {
            _contextId = id ?? throw new ValueException("Context id must be set.");
        }

        /// <inheritdoc />
        internal override IGameMetadataEntity ToEntity()
        {
            return new GameMetadataContextIdEntity
            {
                ContextId = _contextId
            };
        }
    }
}
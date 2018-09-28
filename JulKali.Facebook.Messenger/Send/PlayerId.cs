using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents the player ID of the user to play the Instant Game against.
    /// </summary>
    public class PlayerId : GameMetadata
    {
        private readonly string _playerId;

        /// <summary>
        /// Initializes a new <see cref="PlayerId"/> object.
        /// </summary>
        /// <param name="id">The palyer ID of the other user.</param>
        public PlayerId(string id)
        {
            _playerId = id ?? throw new ValueException("Player id must be set.");
        }

        /// <inheritdoc />
        internal override IGameMetadataEntity ToEntity()
        {
            return new GameMetadataPlayerIdEntity
            {
                PlayerId = _playerId
            };
        }
    }
}
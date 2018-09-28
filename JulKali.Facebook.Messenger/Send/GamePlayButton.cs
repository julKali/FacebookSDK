using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a Game Play button that can be used inside a message template.
    /// </summary>
    public class GamePlayButton : Button
    {
        private readonly string _title;
        private readonly string _payload;
        private readonly GameMetadata _metaData;

        /// <summary>
        /// Initializes a new <see cref="GamePlayButton"/> object.
        /// </summary>
        /// <param name="title">The text displayed on the button. Limited to 20 characters.</param>
        /// <param name="payload">The payload returned if the user clicks on the button.</param>
        /// <param name="gameMetadata">The game identifier.</param>
        public GamePlayButton(string title, string payload = null, GameMetadata gameMetadata = null)
        {
            if (title == null)
            {
                throw new ValueException("Title must be set.");
            }

            if (title.Length > 20)
            {
                throw new ValueException("Title must not exceed 20 characters.");
            }

            _title = title;
            _payload = payload;
            _metaData = gameMetadata;
        }

        /// <inheritdoc />
        internal override IButtonEntity ToEntity()
        {
            return new GamePlayButtonEntity
            {
                Title = _title,
                Payload = _payload,
                GameMetadata = _metaData.ToEntity()
            };
        }
    }
}
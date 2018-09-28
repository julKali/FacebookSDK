using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents an attachment ID to identify media inside a media template.
    /// </summary>
    public class AttachmentIdMediaIdentifier : MediaIdentifier
    {
        private readonly string _attachmentId;

        /// <summary>
        /// </summary>
        /// <param name="attachmentId">The attachment ID.</param>
        public AttachmentIdMediaIdentifier(string attachmentId)
        {
            _attachmentId = attachmentId ?? throw new ValueException("Attachment ID must be provided.");
        }

        /// <summary>
        /// Adds the attachment ID to the payload.
        /// </summary>
        /// <param name="payload">The media payload.</param>
        internal override void AddValuesToPayloadEntity(MediaPayloadEntity payload)
        {
            payload.AttachmentId = _attachmentId;
        }
    }
}
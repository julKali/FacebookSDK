using System;
using System.Collections.Generic;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a builder class used to build a media template.
    /// </summary>
    public class MediaTemplateBuilder : ITemplateBuildable
    {
        private readonly AttachmentMessage _message;

        private bool _shareable;
        private MediaElement _element;

        internal MediaTemplateBuilder(AttachmentMessage message)
        {
            _message = message;
        }

        /// <summary>
        /// Sets whether the native share button in Messenger is enabled.
        /// </summary>
        /// <param name="isShareable">True to enabled, False to disable. Defaults to false.</param>
        /// <returns></returns>
        public MediaTemplateBuilder SetShareable(bool isShareable)
        {
            _shareable = isShareable;

            return this;
        }

        /// <summary>
        /// Sets the element containing the media of the template.
        /// </summary>
        /// <param name="element">The media element.</param>
        /// <returns></returns>
        public MediaTemplateBuilder SetElement(MediaElement element)
        {
            _element = element ?? throw new ValueException("Element must be set.");

            return this;
        }


        /// <summary>
        /// Builds the template. Call this when finished specifying the template to return to the <see cref="AttachmentMessage"/> object.
        /// </summary>
        /// <returns></returns>
        public MessageOptionalElementSetter BuildTemplate()
        {
            if (_element == null)
            {
                throw new InvalidOperationException("Element must be set.");
            }

            var payload = new MediaTemplatePayloadEntity
            {
                Shareable = _shareable ? (bool?) true : null,
                Elements = new List<MediaElementEntity>
                {
                    _element.ToEntity()
                }
            };

            _message.MessageEntity.Attachment = new TemplateAttachmentEntity
            {
                Payload = payload
            };

            _message.TemplateBuilding = false;

            return new MessageOptionalElementSetter(_message);
        }
    }
}
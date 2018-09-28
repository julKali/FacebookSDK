using System;
using System.Collections.Generic;
using System.Linq;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a builder class used to build a button template.
    /// </summary>
    public class ButtonTemplateBuilder : ITemplateBuildable
    {
        private readonly AttachmentMessage _message;

        private string _text;
        private bool _shareable;
        private readonly IList<Button> _buttons = new List<Button>();

        internal ButtonTemplateBuilder(AttachmentMessage message)
        {
            _message = message;
        }

        /// <summary>
        /// Sets the message that is displayed above the buttons.
        /// </summary>
        /// <param name="text">The message text. Limited to 640 characters.</param>
        /// <returns></returns>
        public ButtonTemplateBuilder SetText(string text)
        {
            if (text == null)
            {
                throw new ValueException("Text must be set.");
            }

            if (text.Length > 640)
            {
                throw new ValueException("Text must not exceed 640 characters.");
            }

            _text = text;

            return this;
        }

        /// <summary>
        /// Sets whether the native share button in Messenger is enabled.
        /// </summary>
        /// <param name="isShareable">True to enabled, False to disable. Defaults to false.</param>
        /// <returns></returns>
        public ButtonTemplateBuilder SetShareable(bool isShareable)
        {
            _shareable = isShareable;

            return this;
        }

        /// <summary>
        /// Adds a button to the element. Must be called one to three times per template.
        /// </summary>
        /// <param name="button">The button instance.</param>
        /// <returns></returns>
        public ButtonTemplateBuilder AddButton(Button button)
        {
            if (_buttons.Count >= 3)
            {
                throw new InvalidOperationException("Only a maximum of 3 buttons is allowed.");
            }

            if (button == null)
            {
                throw new ValueException("Provided button object must not be null.");
            }

            _buttons.Add(button);

            return this;
        }

        /// <summary>
        /// Builds the template. Call this when finished specifying the template to return to the <see cref="AttachmentMessage"/> object.
        /// </summary>
        /// <returns></returns>
        public MessageOptionalElementSetter BuildTemplate()
        {
            var payload = new ButtonTemplatePayloadEntity
            {
                Text = _text,
                Shareable = _shareable ? (bool?) true : null
            };

            if (_buttons.Count < 1 || _buttons.Count > 3)
            {
                throw new InvalidOperationException("There must be exactly one, two or three buttons set.");
            }

            payload.Buttons = _buttons.Select(_ => _.ToEntity());

            _message.MessageEntity.Attachment = new TemplateAttachmentEntity
            {
                Payload = payload
            };

            _message.TemplateBuilding = false;

            return new MessageOptionalElementSetter(_message);
        }
    }
}
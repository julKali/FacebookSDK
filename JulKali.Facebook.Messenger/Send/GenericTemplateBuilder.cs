using System;
using System.Collections.Generic;
using System.Linq;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a builder class used to build a generic template.
    /// </summary>
    public class GenericTemplateBuilder : ITemplateBuildable
    {
        private readonly AttachmentMessage _message;

        private bool _shareable;
        private ImageAspectRatio _imageAspectRatio;
        private IList<Element> _elements;

        internal GenericTemplateBuilder(AttachmentMessage message)
        {
            _message = message;
        }

        /// <summary>
        /// Sets whether the native share button in Messenger is enabled.
        /// </summary>
        /// <param name="isShareable">True to enabled, False to disable. Defaults to false.</param>
        /// <returns></returns>
        public GenericTemplateBuilder SetShareable(bool isShareable)
        {
            _shareable = isShareable;

            return this;
        }

        /// <summary>
        /// Sets the image aspect ratio for element images. 
        /// </summary>
        /// <param name="imageAspectRatio">The image aspect ratio.</param>
        /// <returns></returns>
        public GenericTemplateBuilder SetImageAspectRation(ImageAspectRatio imageAspectRatio)
        {
            _imageAspectRatio = imageAspectRatio;

            return this;
        }

        /// <summary>
        /// Adds an element to the template. Can be called up to ten times per element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public GenericTemplateBuilder AddElement(Element element)
        {
            if (element == null)
            {
                throw new ValueException("Element must be set.");
            }

            AssureCreated(ref _elements);

            if (_elements.Count > 10)
            {
                throw new InvalidOperationException("Only a maximum of 10 elements is allowed.");
            }

            _elements.Add(element);

            return this;
        }

        /// <summary>
        /// Builds the template. Call this when finished specifying the template to return to the <see cref="AttachmentMessage"/> object.
        /// </summary>
        /// <returns></returns>
        public MessageOptionalElementSetter BuildTemplate()
        {
            var payload = new GenericTemplatePayloadEntity
            {
                Shareable = _shareable ? (bool?) true : null,
                Elements = _elements.Select(_ => _.ToEntity()).ToList()
            };

            switch (_imageAspectRatio)
            {
                case ImageAspectRatio.Horizontal:
                    break;

                case ImageAspectRatio.Square:
                    payload.ImageAspectRatio = "square";
                    break;

                default:
                    throw new ImageAspectRatioNotSupportedException(_imageAspectRatio);
            }

            _message.MessageEntity.Attachment = new TemplateAttachmentEntity
            {
                Payload = payload
            };

            _message.TemplateBuilding = false;

            return new MessageOptionalElementSetter(_message);
        }

        /// <summary>
        /// Makes sure that a list has been initialized to avoid NULL references.
        /// </summary>
        /// <typeparam name="T">The type of the list items.</typeparam>
        /// <param name="list">A reference of the list.</param>
        private static void AssureCreated<T>(ref IList<T> list)
        {
            if (list == null)
            {
                list = new List<T>();
            }
        }
    }
}
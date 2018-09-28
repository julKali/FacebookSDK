using System;
using System.Collections.Generic;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a builder class for the <see cref="Element"/> class.
    /// </summary>
    public class ElementBuilder
    {
        private readonly string _title;
        private string _subTitle;
        private Uri _imageUrl;
        private DefaultAction _defaultAction;
        private IList<Button> _buttons;

        internal ElementBuilder(string title)
        {
            _title = title;
        }

        /// <summary>
        /// Sets the element subtitle.
        /// </summary>
        /// <param name="subtitle">The element subtitle. Limited to 80 characters.</param>
        /// <returns></returns>
        public ElementBuilder SetSubTitle(string subtitle)
        {
            if (subtitle == null)
            {
                _subTitle = null;

                return this;
            }

            if (subtitle.Length > 80)
            {
                throw new ValueException("Subtitle must not exceed 80 characters.");
            }

            _subTitle = subtitle;

            return this;
        }

        /// <summary>
        /// Sets the URL of an image to be included by the element. 
        /// </summary>
        /// <param name="url">The absolute URI of the image.</param>
        /// <returns></returns>
        public ElementBuilder SetImageUrl(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                throw new ValueException("Parameter 'url' must be a valid absolute URI.");
            }

            _imageUrl = uri;

            return this;

        }

        /// <summary>
        /// Sets a default action which defines what happens when the user clicks on the element.
        /// </summary>
        /// <param name="action">The default action instance.</param>
        /// <returns></returns>
        public ElementBuilder SetDefaultAction(DefaultAction action)
        {
            if (_defaultAction != null)
            {
                throw new InvalidOperationException("A default action has already been set for this element.");
            }

            _defaultAction = action;

            return this;
        }

        /// <summary>
        /// Adds a button to the element. Can be called up to three times per element.
        /// </summary>
        /// <param name="button">The button instance.</param>
        /// <returns></returns>
        public ElementBuilder AddButton(Button button)
        {
            AssureCreated(ref _buttons);

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
        /// Builds the element and returns it. Call this when all needed settings have been set.
        /// </summary>
        /// <returns></returns>
        public Element Build()
        {
            if (_title == null)
            {
                throw new ValueException("Title must be set.");
            }

            if (_title.Length > 80)
            {
                throw new ValueException("Title must not exceed 80 characters.");
            }

            if (_subTitle == null && _imageUrl == null && _buttons == null && _defaultAction == null)
            {
                throw new InvalidOperationException("At least one other property must be set besides Text.");
            }

            if (_subTitle != null && _subTitle.Length > 80)
            {
                throw new ValueException("Subtitle must not exceed 80 characters.");
            }

            return new Element(_title, _subTitle, _imageUrl, _defaultAction, _buttons);
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
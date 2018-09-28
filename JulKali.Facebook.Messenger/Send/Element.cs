using System;
using System.Collections.Generic;
using System.Linq;
using JulKali.Facebook.Entities;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a template element.
    /// </summary>
    public class Element
    {
        private readonly string _title;
        private readonly string _subTitle;
        private readonly Uri _imageUrl;
        private readonly DefaultAction _defaultAction;
        private readonly IList<Button> _buttons;

        internal Element(string title, string subTitle, Uri imageUrl, DefaultAction defaultAction, IList<Button> buttons)
        {
            _title = title; 
            _subTitle = subTitle;
            _imageUrl = imageUrl;
            _defaultAction = defaultAction;
            _buttons = buttons;
        }

        /// <summary>
        /// Starts building a new Element.
        /// </summary>
        /// <returns></returns>
        public static ElementBuilderTextSetter StartBuilding()
        {
            return new ElementBuilderTextSetter();
        }

        /// <summary>
        /// Returns the element as an <see cref="ElementEntity"/> object.
        /// </summary>
        /// <returns></returns>
        internal ElementEntity ToEntity()
        {
            var entity = new ElementEntity
            {
                Title = _title,
                SubTitle = _subTitle,
                ImageUrl = _imageUrl?.ToString(),
                DefaultAction = _defaultAction?.ToEntity(),
                Buttons = _buttons?.Select(_ => _.ToEntity()).ToList()
            };

            return entity;
        }
    }
}
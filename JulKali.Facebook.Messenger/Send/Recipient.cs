﻿using JulKali.Facebook.Entities;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents the root class for all kinds of message recipients. Cannot be used in any other way but as a parent class.
    /// </summary>
    public abstract class Recipient
    {
        protected readonly string Identifier;

        protected Recipient(string identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Returns the recipient as a <see cref="RecipientEntity"/> object.
        /// </summary>
        /// <returns></returns>
        internal abstract RecipientEntity ToEntity();
    }
}

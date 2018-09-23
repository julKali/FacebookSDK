using JulKali.Facebook.Entities;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a recipient that is identified by PSID.
    /// </summary>
    public class PsidRecipient : Recipient
    {
        /// <summary>
        /// Initializes a new recipient using the PSID.
        /// </summary>
        /// <param name="psid">The PSID</param>
        public PsidRecipient(string psid)
            : base(psid)
        {
        }

        internal override RecipientEntity ToRecipientEntity()
        {
            return new RecipientEntity
            {
                Psid = Identifier
            };
        }
    }
}
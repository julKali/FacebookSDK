namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a routing class to choose the attachment template to be used.
    /// </summary>
    public class AttachmentTemplateRouter
    {
        private readonly AttachmentMessage _message;

        internal AttachmentTemplateRouter(AttachmentMessage message)
        {
            message.TemplateBuilding = true;
            _message = message;
        }

        /// <summary>
        /// Uses a generic template as the message attachment.
        /// </summary>
        /// <returns></returns>
        public GenericTemplateBuilder UseGenericTemplate()
        {
            return new GenericTemplateBuilder(_message);
        }

        /// <summary>
        /// Uses a list template as the message attachment.
        /// </summary>
        /// <returns></returns>
        public ListTemplateBuilder UseListTemplate()
        {
            return new ListTemplateBuilder(_message);
        }

        /// <summary>
        /// Uses a media template as the message attachment.
        /// </summary>
        /// <returns></returns>
        public MediaTemplateBuilder UseMediaTemplate()
        {
            return new MediaTemplateBuilder(_message);
        }

    }
}
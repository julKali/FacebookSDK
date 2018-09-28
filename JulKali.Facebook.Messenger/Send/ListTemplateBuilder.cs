namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a builder class used to build a list template.
    /// </summary>
    public class ListTemplateBuilder : ITemplateBuildable
    {
        private readonly AttachmentMessage _message;

        internal ListTemplateBuilder(AttachmentMessage message)
        {
            _message = message;
        }

        /// <summary>
        /// Builds the template. Call this when finished specifying the template to return to the <see cref="AttachmentMessage"/> object.
        /// </summary>
        /// <returns></returns>
        public MessageOptionalElementSetter BuildTemplate()
        {
            throw new System.NotImplementedException();
        }
    }
}
namespace JulKali.Facebook.Messenger.Send
{
    public interface ITemplateBuildable
    {
        /// <summary>
        /// Builds the template. Call this when finished specifying the template to return to the <see cref="AttachmentMessage"/> object.
        /// </summary>
        /// <returns></returns>
        MessageOptionalElementSetter BuildTemplate();
    }
}
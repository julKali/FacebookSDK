using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a builder class for the <see cref="Element"/> class that forces to set the title. Will then redirect to the <see cref="ElementBuilder"/> which provides all other settings.
    /// </summary>
    public class ElementBuilderTextSetter
    {
        internal ElementBuilderTextSetter()
        {
        }

        /// <summary>
        /// Sets the element title.
        /// </summary>
        /// <param name="title">The element title. Limited to 80 characters.</param>
        /// <returns></returns>
        public ElementBuilder SetTitle(string title)
        {
            if (title == null)
            {
                throw new ValueException("Title must be set.");
            }

            if (title.Length > 80)
            {
                throw new ValueException("Title must not exceed 80 characters.");
            }

            return new ElementBuilder(title);
        }
    }
}
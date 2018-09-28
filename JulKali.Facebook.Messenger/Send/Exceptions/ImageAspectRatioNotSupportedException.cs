using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if the specified <see cref="ImageAspectRatio"/> is not supported.
    /// </summary>
    public class ImageAspectRatioNotSupportedException : Exception
    {
        public ImageAspectRatioNotSupportedException(ImageAspectRatio ratio)
            : base($"Invalid image aspect ratio: {ratio.ToString()}")
        {
        }
    }
}
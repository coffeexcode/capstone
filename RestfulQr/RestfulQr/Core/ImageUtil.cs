using System;

namespace RestfulQr.Core
{
    /// <summary>
    /// Statically available methods for dealing with images
    /// </summary>
    public static class ImageUtil
    {
        /// <summary>
        /// Gets a MimeType / ContentType string based on a provided file extension.
        /// </summary>
        /// <param name="extension">The extension to find</param>
        /// <returns>
        /// The mimetype for the extension, otherwise throws a <see cref="NotSupportedException"/>
        /// </returns>
        public static string GetMimeTypeByExtension(string extension)
        {
            return extension switch
            {
                "png" => "image/png",
                _ => throw new NotSupportedException($"The extension '{extension}' is not supported"),
            };
        }
    }
}

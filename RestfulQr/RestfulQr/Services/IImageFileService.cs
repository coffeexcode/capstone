using RestfulQr.ViewModels;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace RestfulQr.Services
{
    /// <summary>
    /// Describes functionality for accessing files on the disk
    /// </summary>
    public interface IImageFileService
    {
        /// <summary>
        /// Returns the path where images are stored relative to the application content root.
        /// </summary>
        /// <returns></returns>
        public string GetImagePath();

        /// <summary>
        /// Reads an file from the filesystem as a byte array
        /// </summary>
        /// <param name="filename">The name of the file to read</param>
        /// <returns>
        /// The file, if found, as an array of bytes
        /// </returns>
        public Task<byte[]> GetFileAsBytesAsync(string filename);

        /// <summary>
        /// Checks if an image file exists. Will throw a FileNotFound exception if
        /// the file does not exist
        /// </summary>
        /// <param name="filename">The name of the file to check</param>
        public void EnsureExists(string filename);

        /// <summary>
        /// Writes a bitmap image to the filesystem
        /// </summary>
        /// <param name="filename">The name of the file to create</param>
        /// <param name="bmp">The bitmap file</param>
        /// <param name="codec">The image codec to use</param>
        /// <param name="encoderParameters">The encoding parameters to use</param>
        /// <returns></returns>
        public Task<CreateFileResult> WriteImageFileAsync(string filename, Bitmap bmp, ImageCodecInfo codec, EncoderParameters encoderParameters);

        /// <summary>
        /// Deletes a file from the filesystem
        /// </summary>
        /// <param name="filename">The name of the file to delete</param>
        public Task DeleteImageFileAsync(string filename);
    }
}

using System;
using System.Drawing;
using TwitterUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la publica en Twitter.
    /// </remarks>
    public class FilterPostOnTwitter : IFilter
    {
        private string _postText;

        public FilterPostOnTwitter(string postText) {
            this._postText = postText;
        }

        /// Un filtro que publica en Twitter la imagen recibida y la retorna sin alteraciones.
        /// </summary>
        /// <param name="image">La imagen a publicar.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            string imagePath = @"twitterImage.jpg";
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, imagePath);

            TwitterImage apiImagenes = new TwitterImage();
            apiImagenes.PublishToTwitter(this._postText, imagePath);
            
            Console.WriteLine($"Post {this._postText} uploaded!");
            return image;
        }
    }
}

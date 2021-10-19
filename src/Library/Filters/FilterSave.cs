using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la guarda en su estado actual.
    /// </remarks>
    public class FilterSave : IFilter
    {
        private string _filepath;

        public FilterSave(string filepath) {
            this._filepath = filepath;
        }

        /// Un filtro que imprime la imagen recibida y la retorna sin alteraciones.
        /// </summary>
        /// <param name="image">La imagen a guardar.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, this._filepath);
            return image;
        }
    }
}

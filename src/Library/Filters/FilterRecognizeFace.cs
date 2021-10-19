using System;
using System.Drawing;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y almacena un valor indicando si contiene una cara.
    /// </remarks>
    public class FilterRecognizeFace : IBooleanFilter
    {
        private bool _faceFound {get; set;}

        public bool Result {
            get {return this._faceFound;}
        }

        /// Un filtro que analiza una imagen en busca de una cara y la retorna sin alteraciones.
        /// </summary>
        /// <param name="image">La imagen a analizar.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            string imagePath = @"imageToAnalyze.jpg";
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, imagePath);

            CognitiveFace analyzer = new CognitiveFace(true, Color.Green);
            analyzer.Recognize(imagePath);
            this._faceFound = analyzer.FaceFound;

            return image;
        }
    }
}
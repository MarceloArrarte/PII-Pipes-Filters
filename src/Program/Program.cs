using System;
using System.Collections.Generic;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");
            
            IPipe fin = new PipeNull();
            IFilter post = new FilterPostOnTwitter();
            IPipe pipePostFinal = new PipeSerial(post, fin);

            IFilter negativo = new FilterNegative();
            IPipe pipeNegativo = new PipeSerial(negativo, pipePostFinal);

            IPipe pipePostIntermedio = new PipeSerial(post, pipeNegativo);

            IFilter guardar = new FilterSave(@"intermediate.jpg");
            IPipe pipeGuardar = new PipeSerial(guardar, pipePostIntermedio);

            IFilter greyscale = new FilterGreyscale();
            IPipe inicio = new PipeSerial(greyscale, pipeGuardar);

            IPicture resultado = inicio.Send(picture);

            provider.SavePicture(resultado, @"processed_image.jpg");
        }
    }
}

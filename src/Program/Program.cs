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
            IFilter negativo = new FilterNegative();
            IPipe pipeNegativo = new PipeSerial(negativo, fin);

            IFilter guardar = new FilterSave(@"intermediate.jpg");
            IPipe pipeGuardar = new PipeSerial(guardar, pipeNegativo);

            IFilter greyscale = new FilterGreyscale();
            IPipe inicio = new PipeSerial(greyscale, pipeGuardar);

            IPicture resultado = inicio.Send(picture);

            provider.SavePicture(resultado, @"processed_image.jpg");
        }
    }
}

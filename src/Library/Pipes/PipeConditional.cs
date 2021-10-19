using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        IPipe pipeIfTrue;
        IPipe pipeIfFalse;
        IBooleanFilter filter;
        
        /// <summary>
        /// La cañería se construye con un IBooleanFilter, y dos pipes que se ejecutan dependiendo
        /// del resultado del filtro booleano.
        /// </summary>
        /// <param name="filter">Filtro que se debe aplicar sobre la imagen.</param>
        /// <param name="pipeIfTrue">Cañería por la que se envía la imagen si el resultado de aplicar el filtro es True.</param>
        /// <param name="pipeIfFalse">Cañería por la que se envía la imagen si el resultado de aplicar el filtro es False.</param>
        public PipeConditional(IBooleanFilter filter, IPipe pipeIfTrue, IPipe pipeIfFalse) 
        {
            this.filter = filter;
            this.pipeIfTrue = pipeIfTrue;
            this.pipeIfFalse = pipeIfFalse;
        }
        
        /// <summary>
        /// La cañería recibe una imagen, y dependiendo del valor del resultado del filtro,
        /// la envía por una u otra cañería.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filter.Filter(picture);
            if (this.filter.Result) {
                return this.pipeIfTrue.Send(picture);
            }
            else {
                return this.pipeIfFalse.Send(picture);
            }
        }
    }
}
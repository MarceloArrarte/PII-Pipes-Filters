using System;

namespace CompAndDel
{
    /// <summary>
    /// Un filtro que recibe, procesa y retorna imágenes. El filtro puede retornar la misma imagen o una nueva imagen
    /// creada por él. Este filtro contiene un valor de retorno que permite bifurcación
    /// en un pipe condicional.
    /// </remarks>
    public interface IBooleanFilter : IFilter
    {
        /// <summary>
        /// Retorna un valor que indica el resultado del análisis del filtro.
        /// </summary>
        bool Result {get;}
    }
}

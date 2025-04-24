using System;
using System.Collections.Generic;
using System.Linq;

namespace OnePieceWorld.Helpers  // O OnePieceWorld.Utils si usas esa carpeta
{
    /// <summary>
    /// Clase que permite la paginación de listas. Divide una lista completa de elementos en páginas más pequeñas.
    /// Requiere una lista de elementos, un tamaño de página y un índice de página para crear una lista paginada.
    /// </summary>
    /// <typeparam name="T">Tipo de los elementos en la lista.</typeparam>
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        // Constructor que inicializa la lista paginada con los elementos correspondientes a la página.
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);  // Añade los elementos de la página actual a la lista
        }

        public bool HasPreviousPage => PageIndex > 1;  // Indica si hay una página anterior
        public bool HasNextPage => PageIndex < TotalPages;  // Indica si hay una página siguiente

        // Método estático que crea la lista paginada a partir de la lista completa.
        public static PaginatedList<T> Create(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count;  // Obtiene el número total de elementos
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();  // Extrae los elementos para la página
            return new PaginatedList<T>(items, count, pageIndex, pageSize);  // Retorna la lista paginada
        }
    }
}

using System;

namespace ChirimoyaLib
{
    public class InventoryCalculator
    {
        /// <summary>
        /// Obtiene el número óptimo de piezas a ordenar.
        /// </summary>
        /// <param name="D">Demanda anual en unidades del artículo en inventario.</param>
        /// <param name="Co">Costo por colocar cada orden.</param>
        /// <param name="Ch">Costo anual por almacenar por unidad.</param>
        /// <returns></returns>
        public static double GetEOQ(double D, decimal Co, decimal Ch)
        {
            if (D < 0.0 || Co < 0m || Ch < 0m)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Ch == 0m)
            {
                throw new DivideByZeroException();
            }
            return Math.Sqrt(2 * D * (double)Co / (double)Ch);
        }
    }
}
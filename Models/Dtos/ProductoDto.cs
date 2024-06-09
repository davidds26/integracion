using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class ProductoDto
    {
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioActual { get; set; }
        public string TextoPromocional { get; set; }
    }
}
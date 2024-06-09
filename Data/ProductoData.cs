using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Entidades;

namespace Data
{
    public static class ProductoData
    {
        public static List<Producto> listaProducto = new List<Producto>
        {
            new Producto { Id = 1, NombreProducto="Producto 1", CategoriaId=1, MarcaId=1, Precio=2000, Costo=1000},
            new Producto { Id = 2, NombreProducto="Producto 2", CategoriaId=1, MarcaId=1, Precio=2200, Costo=1200},
            new Producto { Id = 3, NombreProducto="Producto 3", CategoriaId=1, MarcaId=1, Precio=2350, Costo=1300},
            new Producto { Id = 4, NombreProducto="Producto 4", CategoriaId=1, MarcaId=1, Precio=2450,Costo=1400},
        };
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProductoDto>> GetProductos()
        {
            return ProductoData.listaProducto
                   .Select(p => new ProductoDto
                   {
                       NombreProducto = p.NombreProducto,
                       Categoria = p.Categoria,
                       Marca = p.Marca,
                       Precio = p.Precio,
                       Costo = p.Costo
                   }).ToList();
        }
    }
}
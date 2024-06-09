using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos()
        {
            var lista = await _context.Productos
                    .Include(c => c.Categoria)
                    .Include(m => m.Marca)
                    .Include(o => o.Promocion)
                    .Select(p => new ProductoDto
                    {
                        NombreProducto = p.NombreProducto,
                        Categoria = p.Categoria.Nombre,
                        Marca = p.Marca.Nombre,
                        Precio = p.Precio,
                        Costo = p.Costo,
                        PrecioActual = p.Promocion == null
                                                              ? p.Precio
                                                              : p.Promocion.NuevoPrecio,
                        TextoPromocional = p.Promocion == null
                                                              ? null
                                                              : p.Promocion.TextoPromocional

                    }).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var producto = await _context.Productos
                    .Include(c => c.Categoria)
                    .Include(m => m.Marca)
                    .Include(o => o.Promocion)
                    .FirstOrDefaultAsync(p => p.Id == id);

            if (producto is null)
                return NotFound("There is'n't a product");


            return Ok(new ProductoDto
            {
                NombreProducto = producto.NombreProducto,
                Categoria = producto.Categoria.Nombre,
                Marca = producto.Marca.Nombre,
                Precio = producto.Precio,
                Costo = producto.Costo,
                PrecioActual = producto.Promocion == null
                                                    ? producto.Precio
                                                    : producto.Promocion.NuevoPrecio,
                TextoPromocional = producto.Promocion == null
                                                    ? null
                                                    : producto.Promocion.TextoPromocional

            });
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            try
            {
                await _context.Productos.AddAsync(producto);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProducto", new { id = producto }, producto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
                return BadRequest("Action Not Allowed");

            var productoDB = await _context.Productos.FindAsync(id);

            if (productoDB is null)
                return NotFound();

            productoDB.NombreProducto = producto.NombreProducto;
            productoDB.CategoriaId = producto.CategoriaId;
            productoDB.MarcaId = producto.MarcaId;
            productoDB.Precio = producto.Precio;
            productoDB.Costo = producto.Costo;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DelecteProducto(int id)
        {
            if (id < 1)
                return BadRequest("Action Not Allowed");

            var productoDB = await _context.Productos.FindAsync(id);

            if (productoDB is null)
                return NotFound();

            _context.Remove(productoDB);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
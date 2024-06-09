using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entidades
{

    [Table("PrecioOferta")]
    public class PrecioOferta
    {
        [Key]
        [Column("PrecioOfertaId")]
        public int Id { get; set; }

        [Column(TypeName = "decimal(7, 2")]
        public decimal NuevoPrecio { get; set; }

        public string TextoPromocional { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

    }
}
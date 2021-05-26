using System.Collections.Generic;

namespace pc3teoria.Models
{
    public class Compra
    {

        public int Id { get; set; }

        public string NombreCompra { get; set; }

        public ICollection<Producto> Productos { get; set;}

        public ICollection<Usuario> Usuarios  { get; set;}

    }
}
namespace pc3teoria.Models
{
    public class Producto
    {
        
        public int id { get; set;}

        public string Nombre{ get; set;}

        public decimal Precio{ get; set;}

        public string Foto{ get; set;}

        public Categoria Categoria{ get; set;}

        public int CategoriaId{ get; set;}
    }
}
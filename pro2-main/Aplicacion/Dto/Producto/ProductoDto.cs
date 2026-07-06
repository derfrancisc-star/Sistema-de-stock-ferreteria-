namespace ProyectoUno.Aplicacion.Dto
{
    public class ProductoDto
    {
        // Propiedades de la clase ProductoDto
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}

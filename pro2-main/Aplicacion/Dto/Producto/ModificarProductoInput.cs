namespace ProyectoUno.Aplicacion.Dto
{
    public class ModificarProductoInput
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockMinimo { get; set; }
    }
}

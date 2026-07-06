using ProyectoUno.Dominio.Entidades;

namespace ProyectoUno.Aplicacion.Dto
{
    // Centraliza el mapeo Entidad -> DTO para que los servicios
    // no dependan unos de otros solo para reutilizar este código.
    public static class ProductoMapper
    {
        public static ProductoDto MapearADto(Producto producto)
        {
            return new ProductoDto()
            {
                Id = producto.Id,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Categoria = producto.Categoria,
                Marca = producto.Marca,
                PrecioCompra = producto.PrecioCompra,
                PrecioVenta = producto.PrecioVenta,
                StockActual = producto.StockActual,
                StockMinimo = producto.StockMinimo,
                Activo = producto.Activo,
                FechaAlta = producto.FechaAlta
            };
        }

        public static List<ProductoDto> MapearADto(List<Producto> productos)
        {
            var resultado = new List<ProductoDto>();

            for (int i = 0; i < productos.Count; i++)
            {
                resultado.Add(MapearADto(productos[i]));
            }

            return resultado;
        }
    }
}

using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ModificarProductoService
    {
        IRepositorioProducto _repositorioProducto;

        public ModificarProductoService(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto;
        }

        public void Ejecutar(int id, ModificarProductoInput input)
        {
            var modelo = _repositorioProducto.ObtenerProductoPorId(id);
            if (modelo == null)
            {
                throw new KeyNotFoundException("No existe el producto.");
            }

            modelo.EstablecerNombre(input.Nombre);
            modelo.EstablecerDescripcion(input.Descripcion);
            modelo.EstablecerCategoria(input.Categoria);
            modelo.EstablecerMarca(input.Marca);
            modelo.EstablecerPrecioCompra(input.PrecioCompra);
            modelo.EstablecerPrecioVenta(input.PrecioVenta);
            modelo.EstablecerStockMinimo(input.StockMinimo);

            _repositorioProducto.ActualizarProducto(modelo);
        }
    }
}

using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Entidades;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class CrearProductoService
    {
        IRepositorioProducto _repositorioProducto;

        public CrearProductoService(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto;
        }

        public int Ejecutar(CrearProductoInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Codigo))
            {
                throw new ArgumentException("El código es obligatorio.");
            }

            var existente = _repositorioProducto.ObtenerProductoPorCodigo(input.Codigo);
            if (existente != null)
            {
                throw new InvalidOperationException("Ya existe un producto con ese código.");
            }

            var nuevoProducto = new Producto(
                input.Codigo,
                input.Nombre,
                input.Descripcion,
                input.Categoria,
                input.Marca,
                input.PrecioCompra,
                input.PrecioVenta,
                input.StockMinimo
            );

            _repositorioProducto.AgregarProducto(nuevoProducto);

            return nuevoProducto.Id;
        }
    }
}

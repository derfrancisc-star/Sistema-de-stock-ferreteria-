using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class IngresarStockService
    {
        IRepositorioProducto _repositorioProducto;

        public IngresarStockService(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto;
        }

        public void Ejecutar(int id, IngresarStockInput input)
        {
            var modelo = _repositorioProducto.ObtenerProductoPorId(id);
            if (modelo == null)
            {
                throw new KeyNotFoundException("No existe el producto.");
            }

            modelo.IngresarStock(input.Cantidad);

            _repositorioProducto.ActualizarProducto(modelo);
        }
    }
}

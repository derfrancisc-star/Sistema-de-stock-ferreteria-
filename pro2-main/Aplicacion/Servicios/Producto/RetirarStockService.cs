using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class RetirarStockService
    {
        IRepositorioProducto _repositorioProducto;

        public RetirarStockService(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto;
        }

        public void Ejecutar(int id, RetirarStockInput input)
        {
            var modelo = _repositorioProducto.ObtenerProductoPorId(id);
            if (modelo == null)
            {
                throw new KeyNotFoundException("No existe el producto.");
            }

            modelo.RetirarStock(input.Cantidad);

            _repositorioProducto.ActualizarProducto(modelo);
        }
    }
}

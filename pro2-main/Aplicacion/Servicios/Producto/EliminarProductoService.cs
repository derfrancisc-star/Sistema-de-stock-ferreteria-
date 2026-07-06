using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class EliminarProductoService
    {
        IRepositorioProducto _repositorioProducto;

        public EliminarProductoService(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto;
        }

        public void Ejecutar(int id)
        {
            var modelo = _repositorioProducto.ObtenerProductoPorId(id);

            if (modelo == null)
            {
                throw new KeyNotFoundException("No existe el producto.");
            }

            _repositorioProducto.EliminarProducto(id);
        }
    }
}

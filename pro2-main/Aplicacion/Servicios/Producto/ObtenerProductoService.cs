using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Entidades;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ObtenerProductoService
    {
        IRepositorioProducto _repositorio;

        public ObtenerProductoService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public ProductoDto? Ejecutar(int id)
        {
            Producto? producto = _repositorio.ObtenerProductoPorId(id);

            if (producto == null)
                return null;

            return ProductoMapper.MapearADto(producto);
        }
    }
}

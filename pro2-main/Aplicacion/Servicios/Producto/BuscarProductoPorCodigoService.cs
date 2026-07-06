using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Entidades;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class BuscarProductoPorCodigoService
    {
        IRepositorioProducto _repositorio;

        public BuscarProductoPorCodigoService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public ProductoDto? Ejecutar(string codigo)
        {
            Producto? producto = _repositorio.ObtenerProductoPorCodigo(codigo);

            if (producto == null)
                return null;

            return ProductoMapper.MapearADto(producto);
        }
    }
}

using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ListarProductosService
    {
        IRepositorioProducto _repositorio;

        public ListarProductosService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public List<ProductoDto> Ejecutar()
        {
            var productos = _repositorio.ListarProductos();
            return ProductoMapper.MapearADto(productos);
        }
    }
}

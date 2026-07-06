using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class BuscarProductoPorNombreService
    {
        IRepositorioProducto _repositorio;

        public BuscarProductoPorNombreService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public List<ProductoDto> Ejecutar(string nombre)
        {
            var productos = _repositorio.ObtenerProductosPorNombre(nombre);
            var resultado = new List<ProductoDto>();

            for (int i = 0; i < productos.Count; i++)
            {
                resultado.Add(ProductoMapper.MapearADto(productos[i]));
            }

            return resultado;
        }
    }
}

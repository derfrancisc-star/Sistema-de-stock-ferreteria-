using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ListarProductosPorCategoriaService
    {
        IRepositorioProducto _repositorio;

        public ListarProductosPorCategoriaService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public List<ProductoDto> Ejecutar(string categoria)
        {
            var productos = _repositorio.ListarProductos();
            var resultado = new List<ProductoDto>();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                {
                    resultado.Add(ProductoMapper.MapearADto(productos[i]));
                }
            }

            return resultado;
        }
    }
}

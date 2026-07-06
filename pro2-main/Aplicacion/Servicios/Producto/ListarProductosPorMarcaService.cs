using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ListarProductosPorMarcaService
    {
        IRepositorioProducto _repositorio;

        public ListarProductosPorMarcaService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public List<ProductoDto> Ejecutar(string marca)
        {
            var productos = _repositorio.ListarProductos();
            var resultado = new List<ProductoDto>();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].Marca.Equals(marca, StringComparison.OrdinalIgnoreCase))
                {
                    resultado.Add(ProductoMapper.MapearADto(productos[i]));
                }
            }

            return resultado;
        }
    }
}

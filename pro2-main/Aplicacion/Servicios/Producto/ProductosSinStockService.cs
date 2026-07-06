using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ProductosSinStockService
    {
        IRepositorioProducto _repositorio;

        public ProductosSinStockService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public List<ProductoDto> Ejecutar()
        {
            var productos = _repositorio.ListarProductos();
            var resultado = new List<ProductoDto>();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].StockActual == 0)
                {
                    resultado.Add(ProductoMapper.MapearADto(productos[i]));
                }
            }

            return resultado;
        }
    }
}

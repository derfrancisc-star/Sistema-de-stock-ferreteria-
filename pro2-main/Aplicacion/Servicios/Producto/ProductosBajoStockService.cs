using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ProductosBajoStockService
    {
        IRepositorioProducto _repositorio;

        public ProductosBajoStockService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public List<ProductoDto> Ejecutar()
        {
            var productos = _repositorio.ListarProductos();
            var resultado = new List<ProductoDto>();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].StockActual > 0 && productos[i].StockActual <= productos[i].StockMinimo)
                {
                    resultado.Add(ProductoMapper.MapearADto(productos[i]));
                }
            }

            return resultado;
        }
    }
}

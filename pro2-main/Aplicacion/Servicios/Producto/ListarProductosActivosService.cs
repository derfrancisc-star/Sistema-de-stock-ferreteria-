using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ListarProductosActivosService
    {
        IRepositorioProducto _repositorio;

        public ListarProductosActivosService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public List<ProductoDto> Ejecutar()
        {
            var productos = _repositorio.ListarProductos();
            var resultado = new List<ProductoDto>();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].Activo)
                {
                    resultado.Add(ProductoMapper.MapearADto(productos[i]));
                }
            }

            return resultado;
        }
    }
}

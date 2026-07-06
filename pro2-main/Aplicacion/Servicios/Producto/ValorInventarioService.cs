using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Aplicacion.Servicios
{
    public class ValorInventarioService
    {
        IRepositorioProducto _repositorio;

        public ValorInventarioService(IRepositorioProducto repo)
        {
            _repositorio = repo;
        }

        public decimal Ejecutar()
        {
            var productos = _repositorio.ListarProductos();
            decimal valorTotal = 0;

            for (int i = 0; i < productos.Count; i++)
            {
                valorTotal += productos[i].PrecioVenta * productos[i].StockActual;
            }

            return Math.Round(valorTotal, 2);
        }
    }
}

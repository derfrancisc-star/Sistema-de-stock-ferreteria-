using ProyectoUno.Dominio.Entidades;
using ProyectoUno.Dominio.Interfaces;

namespace ProyectoUno.Persistencia.Repositorios
{
    public class RepositorioProductoEnMemoria : IRepositorioProducto
    {
        private readonly List<Producto> _productos = new List<Producto>();
        private int idIncremental = 1;

        public void AgregarProducto(Producto producto)
        {
            producto.Id = idIncremental++;
            _productos.Add(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            for (int i = 0; i < _productos.Count; i++)
            {
                if (_productos[i].Id == producto.Id)
                {
                    _productos[i] = producto; // Actualizar el producto en la lista
                    return; // Salir del método después de actualizar
                }
            }
        }

        public void EliminarProducto(int id)
        {
            int i = 0;
            while (i < _productos.Count)
            {
                if (_productos[i].Id == id)
                {
                    _productos.RemoveAt(i);
                    return;
                }

                i++;
            }
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            for (int i = 0; i < _productos.Count; i++)
            {
                if (_productos[i].Id == id)
                {
                    return _productos[i];
                }
            }

            return null;
        }

        public Producto? ObtenerProductoPorCodigo(string codigo)
        {
            for (int i = 0; i < _productos.Count; i++)
            {
                if (_productos[i].Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    return _productos[i];
                }
            }

            return null;
        }

        public List<Producto> ObtenerProductosPorNombre(string nombre)
        {
            List<Producto> resultado = new List<Producto>();

            for (int i = 0; i < _productos.Count; i++)
            {
                if (_productos[i].Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    resultado.Add(_productos[i]);
                }
            }

            return resultado;
        }

        public List<Producto> ListarProductos()
        {
            return _productos;
        }

        // Otros métodos para manejar los productos en memoria (actualizar, eliminar, etc.)
    }
}

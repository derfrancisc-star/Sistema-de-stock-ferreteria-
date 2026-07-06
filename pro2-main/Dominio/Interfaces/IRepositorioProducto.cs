using ProyectoUno.Dominio.Entidades;

namespace ProyectoUno.Dominio.Interfaces
{
    public interface IRepositorioProducto
    {
        // Método para agregar un producto al repositorio
        void AgregarProducto(Producto producto);

        // Método para obtener un producto por su ID
        Producto? ObtenerProductoPorId(int id);

        // Método para obtener un producto por su código
        Producto? ObtenerProductoPorCodigo(string codigo);

        // Método para obtener productos por nombre
        List<Producto> ObtenerProductosPorNombre(string nombre);

        // Método para actualizar un producto existente
        void ActualizarProducto(Producto producto);

        // Método para eliminar un producto por su ID
        void EliminarProducto(int id);

        // Método para listar todos los productos
        List<Producto> ListarProductos();
    }
}

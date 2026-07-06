namespace ProyectoUno.Dominio.Entidades
{
    public class Producto
    {
        // Propiedades de la clase Producto
        public int Id { get; set; }
        public string Codigo { get; private set; } = string.Empty;
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string Categoria { get; private set; } = string.Empty;
        public string Marca { get; private set; } = string.Empty;
        public decimal PrecioCompra { get; private set; }
        public decimal PrecioVenta { get; private set; }
        public int StockActual { get; private set; }
        public int StockMinimo { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaAlta { get; private set; }

        // Constructor de la clase Producto
        public Producto()
        {
        }

        public Producto(string codigo, string nombre, string descripcion, string categoria, string marca, decimal precioCompra, decimal precioVenta, int stockMinimo)
        {
            Id = 0;
            EstablecerCodigo(codigo);
            EstablecerNombre(nombre);
            Descripcion = descripcion;
            Categoria = categoria;
            Marca = marca;
            EstablecerPrecioCompra(precioCompra);
            EstablecerPrecioVenta(precioVenta);
            EstablecerStockMinimo(stockMinimo);
            StockActual = 0;
            Activo = true;
            FechaAlta = DateTime.Now;
        }

        public void EstablecerCodigo(string nuevoCodigo)
        {
            if (!string.IsNullOrWhiteSpace(nuevoCodigo))
            {
                Codigo = nuevoCodigo;
            }
            else
            {
                throw new ArgumentException("El código no puede estar vacío.");
            }
        }

        public void EstablecerNombre(string nuevoNombre)
        {
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                Nombre = nuevoNombre;
            }
            else
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
        }

        public void EstablecerDescripcion(string nuevaDescripcion)
        {
            Descripcion = nuevaDescripcion;
        }

        public void EstablecerCategoria(string nuevaCategoria)
        {
            Categoria = nuevaCategoria;
        }

        public void EstablecerMarca(string nuevaMarca)
        {
            Marca = nuevaMarca;
        }

        public void EstablecerPrecioCompra(decimal nuevoPrecioCompra)
        {
            if (nuevoPrecioCompra > 0)
            {
                PrecioCompra = Math.Round(nuevoPrecioCompra, 2);
            }
            else
            {
                throw new ArgumentException("El precio de compra debe ser mayor que cero.");
            }
        }

        public void EstablecerPrecioVenta(decimal nuevoPrecioVenta)
        {
            if (nuevoPrecioVenta > 0)
            {
                PrecioVenta = Math.Round(nuevoPrecioVenta, 2);
            }
            else
            {
                throw new ArgumentException("El precio de venta debe ser mayor que cero.");
            }
        }

        public void EstablecerStockMinimo(int nuevoStockMinimo)
        {
            if (nuevoStockMinimo >= 0)
            {
                StockMinimo = nuevoStockMinimo;
            }
            else
            {
                throw new ArgumentException("El stock mínimo no puede ser negativo.");
            }
        }

        public void Activar()
        {
            Activo = true;
        }

        public void Desactivar()
        {
            Activo = false;
        }

        // Método para ingresar stock al producto
        public void IngresarStock(int cantidad)
        {
            if (cantidad > 0)
            {
                StockActual += cantidad;
            }
            else
            {
                throw new ArgumentException("La cantidad a ingresar debe ser mayor que cero.");
            }
        }

        // Método para retirar stock del producto
        public void RetirarStock(int cantidad)
        {
            if (cantidad > 0)
            {
                if (StockActual >= cantidad)
                {
                    StockActual -= cantidad;
                }
                else
                {
                    throw new InvalidOperationException("No hay suficiente stock disponible para realizar el retiro.");
                }
            }
            else
            {
                throw new ArgumentException("La cantidad a retirar debe ser mayor que cero.");
            }
        }
    }
}

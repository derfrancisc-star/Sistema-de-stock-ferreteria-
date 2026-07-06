using Microsoft.AspNetCore.Mvc;
using ProyectoUno.Aplicacion.Dto;
using ProyectoUno.Aplicacion.Servicios;

namespace ProyectoUno.Presentacion.Controllers
{
    /// <summary>
    /// Expone las operaciones del Sistema de Gestión de Stock:
    /// alta, baja, modificación, búsquedas y control de inventario de productos.
    /// </summary>
    [ApiController] // Indica que es un controlador de API
    [Route("api/productos")] // Define la ruta (ej: api/productos)
    public class ProductoController : ControllerBase
    {

        /// <summary>
        /// Obtiene el listado completo de productos registrados.
        /// </summary>
        /// <returns>Lista de productos (puede estar vacía).</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        public ActionResult<List<ProductoDto>> Listar(ListarProductosService service)
        {
            return Ok(service.Ejecutar());
        }

        /// <summary>
        /// Obtiene un producto a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <param name="service">Servicio encargado de la búsqueda.</param>
        /// <returns>El producto solicitado.</returns>
        /// <remarks>Devuelve 404 Not Found si no existe un producto con ese Id.</remarks>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductoDto> ObtenerPorId(int id, ObtenerProductoService service)
        {
            var producto = service.Ejecutar(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        /// <summary>
        /// Busca un producto a partir de su código único.
        /// </summary>
        /// <param name="codigo">Código del producto a buscar.</param>
        /// <param name="service">Servicio encargado de la búsqueda.</param>
        /// <returns>El producto encontrado.</returns>
        /// <remarks>Devuelve 404 Not Found si no existe un producto con ese código.</remarks>
        [HttpGet("codigo/{codigo}")]
        [ProducesResponseType(typeof(ProductoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductoDto> ObtenerPorCodigo(string codigo, BuscarProductoPorCodigoService service)
        {
            var producto = service.Ejecutar(codigo);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        /// <summary>
        /// Busca productos cuyo nombre coincida total o parcialmente con el valor indicado.
        /// </summary>
        /// <param name="nombre">Texto a buscar dentro del nombre del producto.</param>
        /// <param name="service">Servicio encargado de la búsqueda.</param>
        /// <returns>Lista de productos coincidentes (puede estar vacía).</returns>
        [HttpGet("nombre/{nombre}")]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        public ActionResult<List<ProductoDto>> ObtenerPorNombre(string nombre, BuscarProductoPorNombreService service)
        {
            return Ok(service.Ejecutar(nombre));
        }

        /// <summary>
        /// Lista los productos cuyo stock actual está en o por debajo del stock mínimo.
        /// </summary>
        /// <returns>Lista de productos bajo stock (puede estar vacía).</returns>
        [HttpGet("bajostock")]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        public ActionResult<List<ProductoDto>> BajoStock(ProductosBajoStockService service)
        {
            return Ok(service.Ejecutar());
        }

        /// <summary>
        /// Lista los productos que no tienen stock disponible (stock actual igual a cero).
        /// </summary>
        /// <returns>Lista de productos sin stock (puede estar vacía).</returns>
        [HttpGet("sinstock")]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        public ActionResult<List<ProductoDto>> SinStock(ProductosSinStockService service)
        {
            return Ok(service.Ejecutar());
        }

        /// <summary>
        /// Lista únicamente los productos activos.
        /// </summary>
        /// <returns>Lista de productos activos (puede estar vacía).</returns>
        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        public ActionResult<List<ProductoDto>> Activos(ListarProductosActivosService service)
        {
            return Ok(service.Ejecutar());
        }

        /// <summary>
        /// Lista únicamente los productos inactivos.
        /// </summary>
        /// <returns>Lista de productos inactivos (puede estar vacía).</returns>
        [HttpGet("inactivos")]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        public ActionResult<List<ProductoDto>> Inactivos(ListarProductosInactivosService service)
        {
            return Ok(service.Ejecutar());
        }

        /// <summary>
        /// Lista los productos que pertenecen a una categoría específica.
        /// </summary>
        /// <param name="categoria">Nombre de la categoría a filtrar.</param>
        /// <param name="service">Servicio encargado del filtrado.</param>
        /// <returns>Lista de productos de esa categoría (puede estar vacía).</returns>
        [HttpGet("categoria/{categoria}")]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        public ActionResult<List<ProductoDto>> PorCategoria(string categoria, ListarProductosPorCategoriaService service)
        {
            return Ok(service.Ejecutar(categoria));
        }

        /// <summary>
        /// Lista los productos que pertenecen a una marca específica.
        /// </summary>
        /// <param name="marca">Nombre de la marca a filtrar.</param>
        /// <param name="service">Servicio encargado del filtrado.</param>
        /// <returns>Lista de productos de esa marca (puede estar vacía).</returns>
        [HttpGet("marca/{marca}")]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        public ActionResult<List<ProductoDto>> PorMarca(string marca, ListarProductosPorMarcaService service)
        {
            return Ok(service.Ejecutar(marca));
        }

        /// <summary>
        /// Calcula el valor total del inventario (suma de precio de venta por stock actual de cada producto).
        /// </summary>
        /// <returns>El valor monetario total del inventario.</returns>
        [HttpGet("valorinventario")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public ActionResult<decimal> ValorInventario(ValorInventarioService service)
        {
            return Ok(service.Ejecutar());
        }

        /// <summary>
        /// Crea un nuevo producto en el inventario.
        /// </summary>
        /// <param name="input">Datos del producto a crear.</param>
        /// <param name="crearProductoService">Servicio encargado de la creación.</param>
        /// <returns>El identificador del producto creado.</returns>
        /// <remarks>
        /// El código es obligatorio y único: si ya existe un producto con el mismo código
        /// se devuelve 409 Conflict. Si los datos no son válidos (por ejemplo, precios
        /// menores o iguales a cero, o código/nombre vacíos) se devuelve 400 Bad Request.
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<int> CrearProducto([FromBody] CrearProductoInput input, CrearProductoService crearProductoService)
        {
            var id = crearProductoService.Ejecutar(input);
            return CreatedAtAction(nameof(ObtenerPorId), new { id }, id);
        }

        /// <summary>
        /// Modifica los datos de un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto a modificar.</param>
        /// <param name="input">Nuevos datos del producto.</param>
        /// <param name="service">Servicio encargado de la modificación.</param>
        /// <returns>Sin contenido relevante en el cuerpo de la respuesta.</returns>
        /// <remarks>
        /// Devuelve 404 Not Found si el producto no existe, y 400 Bad Request
        /// si los datos enviados no son válidos.
        /// </remarks>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ModificarProducto(int id, [FromBody] ModificarProductoInput input, ModificarProductoService service)
        {
            service.Ejecutar(id, input);
            return Ok();
        }

        /// <summary>
        /// Elimina un producto del inventario.
        /// </summary>
        /// <param name="id">Identificador del producto a eliminar.</param>
        /// <param name="servicio">Servicio encargado de la eliminación.</param>
        /// <returns>Sin contenido relevante en el cuerpo de la respuesta.</returns>
        /// <remarks>Devuelve 404 Not Found si el producto no existe.</remarks>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id, EliminarProductoService servicio)
        {
            servicio.Ejecutar(id);
            return Ok();
        }

        /// <summary>
        /// Registra un ingreso de stock para un producto.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <param name="input">Cantidad a ingresar.</param>
        /// <param name="service">Servicio encargado del ingreso de stock.</param>
        /// <returns>Sin contenido relevante en el cuerpo de la respuesta.</returns>
        /// <remarks>
        /// Devuelve 404 Not Found si el producto no existe, y 400 Bad Request
        /// si la cantidad indicada no es mayor que cero.
        /// </remarks>
        [HttpPost("{id:int}/ingresar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult IngresarStock(int id, [FromBody] IngresarStockInput input, IngresarStockService service)
        {
            service.Ejecutar(id, input);
            return Ok();
        }

        /// <summary>
        /// Registra un retiro de stock para un producto.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <param name="input">Cantidad a retirar.</param>
        /// <param name="service">Servicio encargado del retiro de stock.</param>
        /// <returns>Sin contenido relevante en el cuerpo de la respuesta.</returns>
        /// <remarks>
        /// Devuelve 404 Not Found si el producto no existe, 400 Bad Request si la
        /// cantidad indicada no es mayor que cero, y 409 Conflict si se intenta
        /// retirar más unidades que las disponibles en stock.
        /// </remarks>
        [HttpPost("{id:int}/retirar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult RetirarStock(int id, [FromBody] RetirarStockInput input, RetirarStockService service)
        {
            service.Ejecutar(id, input);
            return Ok();
        }
    }
}

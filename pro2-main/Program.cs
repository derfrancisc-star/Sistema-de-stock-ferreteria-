using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ProyectoUno.Aplicacion.Servicios;
using ProyectoUno.Dominio.Interfaces;
using ProyectoUno.Persistencia.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sistema de Gestión de Stock",
        Version = "v1",
        Description = "Permite administrar productos, controlar el stock, realizar búsquedas y consultar el estado del inventario.",
        Contact = new OpenApiContact
        {
            Name = string.Empty, // TODO: completar con el nombre del desarrollador
            Email = string.Empty // TODO: completar con el email de contacto
        }
    });

    // Incorpora los comentarios XML (<summary>, <remarks>, <returns>) de los
    // Controllers a la documentación de Swagger. Requiere GenerateDocumentationFile
    // habilitado en el .csproj.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    }
});

// Los repositorios en memoria se registran como Singleton para que la lista
// interna persista durante la vida de la aplicación (antes esto se lograba
// con campos static, lo cual es una mala práctica). Cuando se migre a una
// base de datos real, estos repositorios pasarán a registrarse como Scoped.

builder.Services.AddSingleton<IRepositorioProducto, RepositorioProductoEnMemoria>();
builder.Services.AddScoped<CrearProductoService>();
builder.Services.AddScoped<ModificarProductoService>();
builder.Services.AddScoped<EliminarProductoService>();
builder.Services.AddScoped<ObtenerProductoService>();
builder.Services.AddScoped<ListarProductosService>();
builder.Services.AddScoped<ListarProductosActivosService>();
builder.Services.AddScoped<ListarProductosInactivosService>();
builder.Services.AddScoped<ListarProductosPorCategoriaService>();
builder.Services.AddScoped<ListarProductosPorMarcaService>();
builder.Services.AddScoped<BuscarProductoPorCodigoService>();
builder.Services.AddScoped<BuscarProductoPorNombreService>();
builder.Services.AddScoped<IngresarStockService>();
builder.Services.AddScoped<RetirarStockService>();
builder.Services.AddScoped<ProductosBajoStockService>();
builder.Services.AddScoped<ProductosSinStockService>();
builder.Services.AddScoped<ValorInventarioService>();

// Registrar servicios MVC / Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Traduce las excepciones que ya lanzan los Servicios/Dominio en respuestas HTTP
// correctas (400/404/409), sin tener que repetir try/catch en cada Controller
// ni modificar las validaciones existentes.
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        var (statusCode, title) = exception switch
        {
            ArgumentException => (StatusCodes.Status400BadRequest, "Datos inválidos."),
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Recurso no encontrado."),
            InvalidOperationException => (StatusCodes.Status409Conflict, "Conflicto con el estado actual del recurso."),
            _ => (StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.")
        };

        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(
            new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = exception?.Message
            },
            options: null,
            contentType: "application/problem+json");
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    
    app.UseSwaggerUI(c =>
    {
        // CORRECCIÓN: Se añade el endpoint explícito para que no falle el 'Fetch error'
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema de Gestión de Stock v1");
        
        c.DocumentTitle = "Sistema de Gestión de Stock Ferreteria";
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));
app.Run();
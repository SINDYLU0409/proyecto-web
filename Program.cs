using Microsoft.AspNetCore.Http.Json;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(options =>
options.SerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddCors();
var app = builder.Build();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapGet("/", () =>"Hello World!");

app.MapPost("/Registrarse/unirse", RegistrarseRequestHandler.Registrar);

app.MapPost("/Iniciarsesion/ingresar", IniciarSesionRequestHandler.Sesion);

app.MapPost ("/Contraseña/recuperar",OlvidoContraseñaRequestHandler.Recuperar);

app.MapPost ("/Categorias/agregar", CategoriasRequestHandler.Crear);

app.MapGet ("/Categorias/listar", CategoriasRequestHandler.Listar);

app.MapGet ("/lenguaje/{idCategoria}", LenguajeRequestHandler.ListarRegistros);
app.MapPost ("/lenguaje/CrearRegistro",LenguajeRequestHandler.CrearRegistro);
app.MapDelete ("/lenguaje/{id}",LenguajeRequestHandler.Eliminar);

app.MapGet("/lenguaje/buscar",LenguajeRequestHandler.Buscar);
app.Run();